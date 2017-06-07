using System;
using System.Linq;
using Windows.Storage;

namespace QSF.Infrastructure.Helpers
{
    /// <summary>
    /// A class that provides helper functionality for knowing which examples have displayed hints
    /// </summary>
    public static class HintsHelper
    {
        /// <summary>
        /// Adds an example that has already shown hints to the app storage
        /// </summary>
        /// <param name="exampleName"></param>
        public static void AddOpenedHint(string exampleName)
        {
            if (!ApplicationData.Current.RoamingSettings.Values.ContainsKey(exampleName))
            {
                ApplicationData.Current.RoamingSettings.Values.Add(exampleName, true);
            }
        }

        /// <summary>
        /// Checks if the example hints have already been seen
        /// </summary>
        /// <param name="exampleName"></param>
        /// <returns></returns>
        public static bool CheckHintHasAlreadyBeenSeen(string exampleName)
        {
            bool hintHasShownOnce = ApplicationData.Current.RoamingSettings.Values.ContainsKey(exampleName);    

            return hintHasShownOnce;
        }
    }
}
