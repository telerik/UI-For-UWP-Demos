using System;
using System.IO;
using System.Linq;
using System.Reflection;
using QSF.Model;
using Windows.UI.Xaml.Controls;

namespace QSF.Infrastructure.Helpers
{
    /// <summary>
    /// Handles example creation and instantiation as an UserControl from an assembly.
    /// </summary>
    public class ExampleLoader
    {
        /// <summary>
        /// Loads the content of example, using an <see cref="QSF.Model.IExampleInfo">example info</see>.
        /// </summary>
        /// <param name="example">The example info.</param>
        /// <returns>Returns an UserControl with the contents of the example.</returns>
        public static UserControl LoadExampleContent(IExampleInfo example)
        {
            InitializeDescription(example);

            string controlName = example.PackageName ?? example.ExampleGroup.Control.Name;
            var exampleUserControl = LoadExampleContent(controlName, example.Name);
            return exampleUserControl;
        }

        /// <summary>
        /// initializes the Description property of an <see cref="QSF.Model.ExampleInfo">example info</see> 
        /// </summary>
        /// <param name="exampleInfo"> The example info to initialize</param>
        private static void InitializeDescription(IExampleInfo exampleInfo)
        {
            var info = exampleInfo as ExampleInfo;
            
            if (info != null)
            {
                var controlName = string.IsNullOrEmpty(info.PackageName) ? info.ControlName : exampleInfo.PackageName;
                var controlAssembly = AssemblyCache.GetInstance()[controlName];

                // Description resource name is formed like: 
                // path to example folder + Description.txt
                // e.g.: Chart.Gallery.Bar.Description.txt
                var descriptionName = string.Concat(info.Name.Substring(0, info.Name.LastIndexOf('.')), ".Description.txt"); 

                if (descriptionName != null)
                {
                    using (var stream = controlAssembly.GetManifestResourceStream(descriptionName))
                    {
                        if (stream != null)
                        {
                            using (StreamReader streamReader = new StreamReader(stream))
                            {
                                info.Description = streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        private static object InstantiateExample(Assembly assembly, string exampleName)
        {
            Type type = Type.GetType(string.Format("{0}, {1}", exampleName, assembly.FullName));
            if (type == null)
            {
                return null;
            }
            object instance = Activator.CreateInstance(type);
            return instance;
        }

        /// <summary>
        /// Loads the content of an example, using the names of the control name and example.
        /// </summary>
        /// <param name="controlName">The control name.</param>
        /// <param name="exampleName">The example name.</param>
        /// <returns>Returns an UserControl with the contents of the example.</returns>
        private static UserControl LoadExampleContent(string controlName, string exampleName)
        {
            Assembly assembly = AssemblyCache.GetInstance()[controlName];
            object exampleObject = InstantiateExample(assembly, exampleName);
            UserControl exampleUserControl = exampleObject as UserControl;

            return exampleUserControl;
        }
    }
}