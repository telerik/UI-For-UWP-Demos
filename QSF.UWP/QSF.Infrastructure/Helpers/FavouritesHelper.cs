using System;
using System.Collections.Generic;
using System.Linq;
using QSF.Model;
using Windows.Storage;

namespace QSF.Infrastructure.Helpers
{
    /// <summary>
    /// Currently this class is obsolete and can be deleted because favourites are no longer supported. 
    /// Instead example can be pinned now.
    /// </summary>
    public class FavouritesHelper
    {
        private static List<string> allFavouritesNames = new List<string>();

        static FavouritesHelper()
        {
            Initialize();
        }

        public static void ClearAllFavourites()
        {
            ApplicationData.Current.RoamingSettings.Values.Clear();
        }

        public static void ToggleFavourite(IExampleInfo exampleInfo)
        {
            var favorites = ApplicationData.Current.RoamingSettings.Values;

            string exampleName = exampleInfo.Name;
            string controlName = exampleInfo.ExampleGroup.Control.Name;
            string exampleUniqueKey = controlName + "|" + exampleName;

            if (favorites[exampleUniqueKey] != null)
            {
                // there is an example here added with that name and control, so remove it
                favorites.Remove(exampleUniqueKey);
                return;
            }

            ApplicationDataCompositeValue compositeValue = new ApplicationDataCompositeValue();
            compositeValue["ExampleName"] = exampleName;
            compositeValue["ControlName"] = controlName;
            favorites[exampleUniqueKey] = compositeValue;
        }

        public static bool IsExampleFavourite(IExampleInfo exampleInfo)
        {
            return allFavouritesNames.Contains(exampleInfo.Name);
        }

        private static void Initialize()
        {
            var roamingSettings = ApplicationData.Current.RoamingSettings.Values;

            if (roamingSettings == null || roamingSettings.Count == 0)
            {
                return;
            }

            var list = new List<string>();

            foreach (ApplicationDataCompositeValue value in roamingSettings.Values.OfType<ApplicationDataCompositeValue>())
            {
                string exampleName = value["ExampleName"].ToString();

                list.Add(exampleName);
            }

            allFavouritesNames = list;
        }
    }
}