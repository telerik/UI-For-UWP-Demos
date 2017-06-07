using System.Collections.Generic;
using System.Reflection;
using QSF.Infrastructure.Exceptions;

namespace QSF.Infrastructure.Helpers
{
    /// <summary>
    /// A cache that holds loaded in memory assemblies. Their name is used as a key to access them.
    /// </summary>
    public class AssemblyCache
    {
        /// <summary>
        /// Key is the assembly name, value is the loaded Assembly.
        /// </summary>
        private static Dictionary<string, Assembly> LoadedAssemblies = new Dictionary<string, Assembly>();
        private static readonly AssemblyCache instance = new AssemblyCache();

        private AssemblyCache()
        {
        }

        public static AssemblyCache GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Loads an assembly into memory and adds it to the cache. Throws an ExampleNotLoadedException if the assembly does not exist.
        /// </summary>
        /// <param name="assemblyName">Name for the assembly to load.</param>
        public void Load(string assemblyName)
        {
            try
            {
                Assembly loadedAssembly = Assembly.Load(new AssemblyName(assemblyName));
                this.Add(assemblyName, loadedAssembly);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new ExampleNotLoadedException("Assembly with name " + assemblyName + " not found in application folder.", ex);
            }
        }

        /// <summary>
        /// Adds an assembly to the cache. If an assembly with the same name exists, the assembly is NOT replaced with the new one.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly to add. This is also the key to use for locating it later.</param>
        /// <param name="assembly">Assembly to load.</param>
        public void Add(string assemblyName, Assembly assembly)
        {
            if (LoadedAssemblies.ContainsKey(assemblyName))
            {
                return;
            }

            LoadedAssemblies.Add(assemblyName, assembly);
        }

        /// <summary>
        /// Gets the <see cref="System.Reflection.Assembly">assembly</see> with the specified assembly name.
        /// </summary>
        public Assembly this[string assemblyName]
        {
            get 
            {
                if (!LoadedAssemblies.ContainsKey(assemblyName))
                {
                    this.Load(assemblyName);
                }

                return LoadedAssemblies[assemblyName];
            }
        }
    }
}
