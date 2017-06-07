using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grid
{
    public static class XmlDataParser
    {
        public static void Parse<T>(string filePath, Action<T> elementAction, Action<XElement, T> childElementAction) where T : class, new()
        {
            var assembly = typeof(XmlDataParser).GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(filePath))
            {
                XDocument document = XDocument.Load(stream);
                foreach (XElement element in document.Root.Elements())
                {
                    T instance = new T();

                    foreach (var childElement in element.Elements())
                    {
                        childElementAction(childElement, instance);
                    }

                    elementAction(instance);
                }
            }
        }
    }
}
