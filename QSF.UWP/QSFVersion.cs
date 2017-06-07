using System;
using System.Linq;
using Windows.ApplicationModel;

namespace QSF
{
    public static class QSFVersion
    {
        /// <summary>
        /// Shows if the QSF is being released as Beta (true) or else (false).
        /// </summary>
        /// This can be refactored as enum later if needed.
        public const bool IsBeta = false;

        /// <summary>
        /// Gets the version of the QSF based on the package's appx manifest version.
        /// </summary>
        public static string GetVersionFromPackageAppx()
        {
            var version = Package.Current.Id.Version;
            String versionName = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            return versionName;
        }
  
        /// <summary>
        /// Gets the version of the QSF based on RadControls' assembly. Use this if QSF's package version is newer, but controls are older.
        /// </summary>
        public static string GetVersionFromControlsAssembly()
        {
            //var asmName = typeof(Telerik.UI.Xaml.Controls.RadControl).AssemblyQualifiedName;
            //var versionExpression = new System.Text.RegularExpressions.Regex("Version=(?<version>[0-9.]*)");
            //var m = versionExpression.Match(asmName);
            //string version = String.Empty;
            //if (m.Success)
            //{
            //    version = m.Groups["version"].Value;
            //}
            //return version;

            return string.Empty;
        }

        /// <summary>
        /// Gets the version of the QSF based on RadControls' assembly. Use this if QSF's package version is newer, but controls are older.
        /// </summary>
        public static string GetReleaseVersion()
        {
            var packageVersion = Package.Current.Id.Version;
            var version = string.Concat("Q", packageVersion.Minor, " ", packageVersion.Major);

            if (IsBeta && packageVersion.Revision == 0)
            {
                version += " Beta";
            }
            else if (packageVersion.Revision > 0)
            {
                version += " Service Pack " + packageVersion.Revision;
            }

            return version;
        }
    }
}
