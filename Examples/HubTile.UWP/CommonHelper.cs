using System;
using System.Collections;
using System.Collections.Generic;

namespace HubTile
{
    public static class CommonHelper
    {
        private const string AbsolutePath = "ms-appx:///HubTile/Assets/Images/";

        public static IEnumerable LoadMosaicImages()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return AbsolutePath + "contacts-" + i + ".jpg";
            }
        }

        public static IEnumerable LoadCompaniesImages()
        {
            for (int i = 1; i <= 4; i++)
            {
                yield return AbsolutePath + "companies-" + i + ".png";
            }
        }

        public static IEnumerable LoadStatisticsImages()
        {
            yield return AbsolutePath + "activities-1.png";
            yield return AbsolutePath + "closed-wins-1.png";
            yield return AbsolutePath + "open-tasks-1.png";
            yield return AbsolutePath + "opportunities-1.png";
        }
    }
}
