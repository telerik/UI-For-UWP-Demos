using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QSF.Infrastructure.Helpers;
using QSF.Infrastructure.Model;
using QSF.Model;
using QSF.Common.Examples;

namespace QSF.Infrastructure.CodeView
{
    public class ExampleSourceCodeHelper
    {
        private static readonly string[] DataFiles = { ".csv", ".txt", ".xml" };

        /// <summary>
        /// Gets the code text for each example XAML or CS file in the example info.
        /// </summary>
        /// <param name="example">Example whose files' code to retrieve.</param>
        /// <returns>Returns a dictionary&lt;filename, code text&gt;.</returns>
        public static List<CodeFileInfo> GetCodeFilesForExample(IExampleInfo example)
        {
            List<CodeFileInfo> codeFilesList = new List<CodeFileInfo>();

            var exampleInfo = example as ExampleInfo;
            if (exampleInfo == null)
            {
                throw new ArgumentException("Something went wrong. Example should be an ExampleInfo.");
            }
            else
            {
                var controlAssembly = GetControlAssembly(exampleInfo);
                string[] resourceNamesInAssembly = controlAssembly.GetManifestResourceNames();
                var textToMatch = exampleInfo.Name.Substring(0, exampleInfo.Name.LastIndexOf('.') + 1);
                var resourcesWithCode = resourceNamesInAssembly.Where(r => !r.Contains("AssemblyInfo.cs") && r.StartsWith(textToMatch) && !IsDataFile(r));

                foreach (var resourceName in resourcesWithCode)
                {
                    using (var stream = controlAssembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            var codeText = streamReader.ReadToEnd();
                            codeFilesList.Add(new CodeFileInfo { FileName = resourceName, CodeContent = codeText });
                        }
                    }
                }
            }

            return codeFilesList;
        }

        public static List<CodeFileInfo> GetCodeFilesForExample(ISubExample example)
        {
            List<CodeFileInfo> codeFilesList = new List<CodeFileInfo>();

            var exampleInfo = example as ISubExample;
            if (exampleInfo == null)
            {
                throw new ArgumentException("Something went wrong. Example should be an ExampleInfo.");
            }
            else
            {
                var controlAssembly = GetControlAssembly(exampleInfo);
                string[] resourceNamesInAssembly = controlAssembly.GetManifestResourceNames();
                var textToMatch = exampleInfo.Name.Substring(0, exampleInfo.Name.LastIndexOf('.') + 1);
                var resourcesWithCode = resourceNamesInAssembly.Where(r => !r.Contains("AssemblyInfo.cs") && r.StartsWith(textToMatch) && !IsDataFile(r));

                foreach (var resourceName in resourcesWithCode)
                {
                    using (var stream = controlAssembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            var codeText = streamReader.ReadToEnd();
                            codeFilesList.Add(new CodeFileInfo { FileName = resourceName, CodeContent = codeText });
                        }
                    }
                }
            }

            return codeFilesList;
        }

        /// <summary>
        /// Gets the code text for each example XAML or CS file in the example info.
        /// </summary>
        /// <param name="example">Example whose files' code to retrieve.</param>
        /// <returns>Returns a dictionary&lt;filename, code text&gt;.</returns>
        public static IDictionary<string, string> GetCodeForAllExampleFiles(IExampleInfo example)
        {
            // K: filename ("Chart.FirstLook.Example.xaml.cs")
            // V: code text for filename
            Dictionary<string, string> codeTextForFiles = new Dictionary<string, string>();

            List<CodeFileInfo> codeFilesList = new List<CodeFileInfo>();

            var exampleInfo = example as ExampleInfo;
            if (exampleInfo == null)
            {
                throw new ArgumentException("Something went wrong. Example should be an ExampleInfo.");
            }
            else
            {
                var controlAssembly = GetControlAssembly(exampleInfo);
                string[] resourceNamesInAssembly = controlAssembly.GetManifestResourceNames();
                var textToMatch = exampleInfo.Name.Substring(0, exampleInfo.Name.LastIndexOf('.') + 1);
                var resourcesWithCode = resourceNamesInAssembly.Where(r => !r.Contains("AssemblyInfo.cs") && r.StartsWith(textToMatch) && !IsDataFile(r));

                foreach (var resourceName in resourcesWithCode)
                {
                    using (var stream = controlAssembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            var codeText = streamReader.ReadToEnd();
                            codeTextForFiles.Add(resourceName, codeText);
                            codeFilesList.Add(new CodeFileInfo { FileName = resourceName, CodeContent = codeText });
                        }
                    }
                }
            }

            return codeTextForFiles;
        }

        //public static IDictionary<string, string> GetCodeForAllExampleFiles(ISubExample example)
        //{
        //    // K: filename ("Chart.FirstLook.Example.xaml.cs")
        //    // V: code text for filename
        //    Dictionary<string, string> codeTextForFiles = new Dictionary<string, string>();

        //    List<CodeFileInfo> codeFilesList = new List<CodeFileInfo>();

        //    var exampleInfo = example as ISubExample;
        //    if (exampleInfo == null)
        //    {
        //        throw new ArgumentException("Something went wrong. Example should be an ExampleInfo.");
        //    }
        //    else
        //    {
        //        var controlAssembly = GetControlAssembly(exampleInfo);
        //        string[] resourceNamesInAssembly = controlAssembly.GetManifestResourceNames();
        //        var textToMatch = exampleInfo.Name.Substring(0, exampleInfo.Name.LastIndexOf('.') + 1);
        //        var resourcesWithCode = resourceNamesInAssembly.Where(r => !r.Contains("AssemblyInfo.cs") && r.StartsWith(textToMatch) && !IsDataFile(r));

        //        foreach (var resourceName in resourcesWithCode)
        //        {
        //            using (var stream = controlAssembly.GetManifestResourceStream(resourceName))
        //            {
        //                using (StreamReader streamReader = new StreamReader(stream))
        //                {
        //                    var codeText = streamReader.ReadToEnd();
        //                    codeTextForFiles.Add(resourceName, codeText);
        //                    codeFilesList.Add(new CodeFileInfo { FileName = resourceName, CodeContent = codeText });
        //                }
        //            }
        //        }
        //    }

        //    return codeTextForFiles;
        //}

        private static System.Reflection.Assembly GetControlAssembly(ExampleInfo exampleInfo)
        {
            var controlName = string.IsNullOrEmpty(exampleInfo.PackageName) ? exampleInfo.ControlName : exampleInfo.PackageName;
            var controlAssembly = AssemblyCache.GetInstance()[controlName];
            return controlAssembly;
        }

        private static System.Reflection.Assembly GetControlAssembly(ISubExample exampleInfo)
        {
            var controlName = exampleInfo.PackageName;
            var controlAssembly = AssemblyCache.GetInstance()[controlName];
            return controlAssembly;
        }

        private static bool IsDataFile(string resourceName)
        {
            int index = resourceName.LastIndexOf('.');
            string fileExt = resourceName.Substring(index, resourceName.Length - index);
            foreach (string dataFile in DataFiles)
            {
                if (fileExt.ToLower() == dataFile)
                {
                    return true;
                }
            }

            return false;
        }
    }
}