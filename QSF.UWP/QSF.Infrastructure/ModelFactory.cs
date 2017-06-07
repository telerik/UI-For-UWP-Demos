using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using QSF.Extensions;
using QSF.Infrastructure.Helpers;
using QSF.Infrastructure.Search;
using QSF.Model;

namespace QSF.Infrastructure
{
    /// <summary>
    /// A factory class with methods for creating different model objects.
    /// </summary>
    public static class ModelFactory
    {
        private static QuickStartData QuickStartDataInstance;
#if WINDOWS_UWP
        private const Enums.PlatformType PLATFORM = Enums.PlatformType.UWP;
#else
        private const Enums.PlatformType PLATFORM = Enums.PlatformType.WindowsUniversal;
#endif

        public static IQuickStartData GetQuickStartDataSingleton()
        {
            if (QuickStartDataInstance == null)
            {
                throw new InvalidOperationException("IQuickStartData instance should not be null here. Did InitializeQuickStartData() finish?");
            }
            return QuickStartDataInstance;
        }

        public static void InitializeQuickStartData(XElement element)
        {
            QuickStartData data = new QuickStartData();

            InitializeHomePageData(data, element);

            var controlsList = CreateControlInfos(element);
            data.AllControls = controlsList.OrderBy(c => c.Name);

            var examplesList = data.AllControls.SelectMany(c => c.Examples);
            data.Examples = examplesList;

            data.HighlightedControls = LoadHighlightedControls(controlsList, element);
            data.HighlightedExamples = LoadHighlightedExamples(examplesList, element);
            data.HighlightedApps = LoadHighlightedApps(element);

            QuickStartDataInstance = data;
        }

        private static List<AppHighlightInfo> LoadHighlightedApps(XElement element)
        {
            var highlightedApps = element.Element("HighlightedApps").Elements("HighlightedApp");
            var highlightedAppsObjects = new List<AppHighlightInfo>();

            foreach (XElement e in highlightedApps)
            {
                var highlightedApp = new AppHighlightInfo();
                highlightedApp.DetailedDescription = e.Attribute("detailedDescription").Value;
                highlightedApp.ShortDescription = e.Attribute("shortDescription").Value;
                highlightedApp.Link = e.Attribute("link").Value;
                highlightedApp.Name = e.Attribute("name").Value;
                highlightedApp.Thumbnail = string.Format("ms-appx:///{0}", e.Attribute("thumbnail").Value);
                highlightedApp.Icon = string.Format("ms-appx:///{0}", e.Attribute("icon") != null ?  e.Attribute("icon").Value : "");
                highlightedApp.Highlights = new List<HighlightInfo>();

                foreach(XElement highlight in e.Elements("Highlight"))
                {
                    HighlightInfo hl = new HighlightInfo();
                    hl.Image = string.Format("ms-appx:///{0}", highlight.Attribute("image").Value);

                    highlightedApp.Highlights.Add(hl);
                }

                highlightedAppsObjects.Add(highlightedApp);
            }

            return highlightedAppsObjects;
        }

        private static IControlInfo CreateControlInfo(XElement element)
        {
            ControlInfo info = new ControlInfo();

            System.Diagnostics.Debug.Assert(element != null, "Ported from old code, element purposedly should not be null.");

            var status = element.GetAttribute("status", null);
            info.Status = string.IsNullOrEmpty(status) ? Enums.StatusMode.Normal : (Enums.StatusMode)Enum.Parse(typeof(Enums.StatusMode), status, true);

            var platform = element.GetAttribute("platform", null);
            info.Platform = string.IsNullOrEmpty(platform) ? ModelFactory.PLATFORM : (Enums.PlatformType)Enum.Parse(typeof(Enums.PlatformType), platform, true);

            info.Name = element.GetAttribute("name", null);
            var text = element.GetAttribute("text", null);
            info.Text = string.IsNullOrEmpty(text) ? info.Name : text;
            info.Description = element.GetAttribute("description", null);
            info.Examples = new List<IExampleInfo>();
            info.ExampleGroups = CreateExampleGroups(info, element);
            info.Keywords = element.GetAttribute("keywords", null);

            foreach (var group in info.ExampleGroups)
            {
                info.Examples.AddRange(group.Examples);
            }

            return info;
        }

        private static IExampleGroupInfo CreateExampleGroupInfo(IControlInfo control, XElement element)
        {
            ExampleGroupInfo info = new ExampleGroupInfo();
            System.Diagnostics.Debug.Assert(element != null, "Ported from old code, element purposedly should not be null.");
            info.Control = control;
            info.Name = element.GetAttribute("name", null);
            info.Examples = new List<IExampleInfo>();
            LoadExamplesData(info, element);

            return info;
        }

        private static IExampleInfo CreateExampleInfo(IExampleGroupInfo exampleGroup, XElement element)
        {
            ExampleInfo info = new ExampleInfo();
            System.Diagnostics.Debug.Assert(element != null, "Ported from old code, element purposedly should not be null.");
            info.ExampleGroup = exampleGroup;
            var status = element.GetAttribute("status", null);
            info.Status = string.IsNullOrEmpty(status) ? Enums.StatusMode.Normal : (Enums.StatusMode)Enum.Parse(typeof(Enums.StatusMode), status, true);

            var platform = element.GetAttribute("platform", null);
            info.Platform = string.IsNullOrEmpty(platform) ? ModelFactory.PLATFORM : (Enums.PlatformType)Enum.Parse(typeof(Enums.PlatformType), platform, true);

            info.Text = element.GetAttribute("text", null);
            info.Name = element.GetAttribute("name", null);
            //info.Description = element.GetAttribute("description", null);
            info.IsDefault = element.GetAttribute("isDefault", false);
            var type = element.GetAttribute("type", null);
            info.Type = string.IsNullOrEmpty(type) ? Enums.ExampleType.Normal : (Enums.ExampleType)Enum.Parse(typeof(Enums.ExampleType), type, true);
            info.PackageName = element.GetAttribute("packageName", null);
            info.Keywords = element.GetAttribute("keywords", null);
            info.IsExampleFullScreen = element.GetAttribute("isExampleFullScreen", false);
            info.CommonFolders = new List<string>(element.GetAttribute("commonFolders", null).Split(';'));
            info.ControlName = exampleGroup.Control.Name;
            info.HeaderText = element.GetAttribute("headerText", null);
            info.Highlights = element.Elements("Highlight").Select(e => ModelFactory.CreateExampleHighlightInfo(e));
            if (!string.IsNullOrEmpty(info.PackageName))
            {
                info.ShortName = info.Name.GetTextAfterLastOccurence(info.PackageName, true).Replace(".Example", string.Empty);
            }
            else
            {
                info.ShortName = info.Name.GetTextAfterLastOccurence(info.ControlName, true).Replace(".Example", string.Empty);
            }

            info.IsFavourite = FavouritesHelper.IsExampleFavourite(info);
            info.CanPinToDesktop = element.GetAttribute("canPinToDesktop", true);

            return info;
        }

        private static HomePageInfo CreateHomePageInfo(XElement element)
        {
            HomePageInfo info = new HomePageInfo();

            if (element != null)
            {
                info.Headline = CreateHeadlineData(element);
                info.Highlights = CreateHighlightsData(element);
            }

            return info;
        }

        private static HighlightInfo CreateHighlightInfo(XElement element)
        {
            HighlightInfo info = new HighlightInfo();
            System.Diagnostics.Debug.Assert(element != null, "Ported from old code, element purposedly should not be null.");
            info.Text = element.GetAttribute("text", null);
            info.Description = element.GetAttribute("description", null);
            info.Image = element.GetAttribute("image", null);

            return info;
        }

        private static ExampleHighlightInfo CreateExampleHighlightInfo(XElement element)
        {
            var baseInfo = CreateHighlightInfo(element);
            ExampleHighlightInfo info = new ExampleHighlightInfo();

            info.Image = string.Format("ms-appx:///{0}", baseInfo.Image);
            info.Description = baseInfo.Description;
            info.Text = baseInfo.Text;

            int heightMultiplier;
            Int32.TryParse(element.GetAttribute("heightMultiplier", null), out heightMultiplier);
            info.HeightMultiplier = heightMultiplier;

            int widthMultiplier;
            Int32.TryParse(element.GetAttribute("widthMultiplier", null), out widthMultiplier);
            info.WidthMultiplier = widthMultiplier;

            return info;
        }

        private static HomePageExampleHighlightInfo CreateHomePageExampleHighlightInfo(XElement element)
        {
            var baseInfo = CreateExampleHighlightInfo(element);
            var info = new HomePageExampleHighlightInfo();

            info.Image = baseInfo.Image;
            info.Description = baseInfo.Description;
            info.Text = baseInfo.Text;
            info.HeightMultiplier = baseInfo.HeightMultiplier;
            info.WidthMultiplier = baseInfo.WidthMultiplier;

            return info;
        }

        public static ISearchStrategy CreateDefaultSearchStrategy()
        {
            ISearchStrategy strategy = new DefaultSearchStrategy();
            return strategy;
        }

        /* IQuickStartData */

        private static void InitializeHomePageData(QuickStartData data, XElement element)
        {
            var homepage = element.Element("HomepageInfo");
            if (homepage != null)
            {
                data.HomePage = ModelFactory.CreateHomePageInfo(homepage);
            }
        }

        private static List<IControlInfo> CreateControlInfos(XElement element)
        {
            List<IControlInfo> controlsList = new List<IControlInfo>();

            var controls = element.Element("Controls");
            if (controls != null)
            {
                foreach (var item in controls.Elements("Control").Select(e => ModelFactory.CreateControlInfo(e)))
                {
                    if (item.Status != Enums.StatusMode.Obsolete)
                    {
                        if (item.Platform != ModelFactory.PLATFORM)
                        {
                            // Don't add the control to the QSF if not for the current platform.
                            continue;
                        }

                        controlsList.Add(item);
                    }
                }
            }

            return controlsList;
        }

        private static IEnumerable<IControlInfo> LoadHighlightedControls(List<IControlInfo> controlsList, XElement element)
        {
            var highlightedControls = element.Element("HighlightedControls").Elements("HighlightedControl").Where(n =>
            {
                var platform = n.GetAttribute("platform", null);
                if (string.IsNullOrEmpty(platform))
                {
                    return true;
                }

                return (Enums.PlatformType)Enum.Parse(typeof(Enums.PlatformType), platform, true) == ModelFactory.PLATFORM;
            });

            return highlightedControls.Select(node => controlsList.FirstOrDefault(ici => node.Attribute("name").Value == ici.Name));
        }

        private static IEnumerable<HomePageExampleHighlightInfo> LoadHighlightedExamples(IEnumerable<IExampleInfo> examplesList, XElement element)
        {
            var highlightedExamplesElement = element.Element("HighlightedExamples");
            if (highlightedExamplesElement == null)
                return null;
            
            var highlightedExamples = highlightedExamplesElement.Elements("HighlightedExample");
            if (highlightedExamplesElement == null)
                return null;

            return highlightedExamples.Select(node =>
            {
                var info = CreateHomePageExampleHighlightInfo(node);
                info.Example = examplesList.FirstOrDefault(e => e.Name == node.GetAttribute("name", null));
                return info;
            });
        }

        /* IControlInfo */

        private static List<IExampleGroupInfo> CreateExampleGroups(ControlInfo info, XElement element)
        {
            var result = new List<IExampleGroupInfo>();
            var exampleGroups = element.Elements("Group");

            if (exampleGroups != null)
            {
                foreach (var groupElement in exampleGroups)
                {
                    result.Add(ModelFactory.CreateExampleGroupInfo(info, groupElement));
                }
            }

            return result.Where(eg => ((ExampleGroupInfo)eg).IsEmpty == false).ToList();
        }

        private static void LoadExamplesData(ExampleGroupInfo info, XElement element)
        {
            foreach (var item in element.Elements("Example"))
            {
                var newExample = ModelFactory.CreateExampleInfo(info, item);
                if (newExample.Platform != ModelFactory.PLATFORM)
                {
                    // Don't load the example if not for the current platform.
                    continue;
                }

                info.Examples.Add(newExample);
            }
        }

        private static HighlightInfo CreateHeadlineData(XElement element)
        {
            return element.Elements("Headline").Select(e => ModelFactory.CreateHighlightInfo(e)).FirstOrDefault();
        }

        private static IList<HighlightInfo> CreateHighlightsData(XElement element)
        {
            var result = new List<HighlightInfo>();
            var highlights = element.Element("Highlights");
            if (highlights != null)
            {
                result.AddRange((highlights.Elements("Highlight").Select(e => ModelFactory.CreateHighlightInfo(e))));
            }

            return result;
        }
    }
}