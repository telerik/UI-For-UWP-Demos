using System;
using System.Collections.Generic;
using System.Linq;
using Debug = System.Diagnostics.Debug;

namespace QSF.Model
{
    public class ControlInfo : IControlInfo
    {
        private IExampleInfo defaultExample;

        public ControlInfo()
        {
            this.UniqueId = Guid.NewGuid();
        }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public Enums.StatusMode Status { get; internal set; }

        public Enums.PlatformType Platform { get; internal set; }

        public List<IExampleGroupInfo> ExampleGroups { get; internal set; }

        public List<IExampleInfo> Examples { get; internal set; }

        public IExampleInfo DefaultExample
        {
            get
            {
                if (this.defaultExample != null)
                {
                    return this.defaultExample;
                }

                Debug.Assert(this.Examples != null && this.Examples.Count != 0, "this.Examples should be initialized by now");

                try
                {
                    this.defaultExample = this.Examples.First(e => e.IsDefault);
                }
                catch
                {
                    this.defaultExample = this.Examples.First();
                }

                return this.defaultExample;
            }
        }

        public string PinnedImage
        {
            get
            {
                return string.Format("ms-appx:///{0}/Assets/{0}_Pinned.png", this.Name);
            }
        }

        public string SmallImage
        {
            get
            {
                return string.Format("ms-appx:///{0}/Assets/{0}_Small.png", this.Name);
            }
        }



        public Windows.UI.Xaml.Media.ImageSource SmallImage1
        {
            get
            {
                return new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(this.SmallImage, UriKind.Absolute)) { DecodePixelWidth = 32, DecodePixelHeight = 32 };

            }
        }


        public string MediumImage
        {
            get
            {
                return string.Format("ms-appx:///{0}/Assets/{0}_Medium.png", this.Name);
            }
        }

        public string LargeImage
        {
            get
            {
                return string.Format("ms-appx:///{0}/Assets/{0}_Large.png", this.Name);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ControlInfo c = obj as ControlInfo;
            if (c == null)
            {
                return false;
            }
            else
            {
                return this.Name == c.Name;
            }
        }

        public string Keywords { get; internal set; }

        public Guid UniqueId { get; private set; }

        public string GetReadableName()
        {
            return this.Name;
        }
    }
}
