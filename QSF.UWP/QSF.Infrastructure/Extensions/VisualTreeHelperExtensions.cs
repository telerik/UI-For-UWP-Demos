using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace QSF.Infrastructure.Extensions
{
    public static class VisualTreeHelperExtensions
    {
        public static FrameworkElement GetChildByName(DependencyObject root, String name)
        {
            FrameworkElement control = null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);

                string childName = child.GetValue(FrameworkElement.NameProperty) as string;
                control = child as FrameworkElement;

                if (childName == name)
                {
                    return control;
                }
                else
                {
                    control = GetChildByName(child, name);

                    if (control != null)
                    {
                        return control;
                    }
                }
            }

            return control;
        }

        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform visualTransform = element.TransformToVisual(Window.Current.Content);
            Point point = visualTransform.TransformPoint(new Point(0, 0));
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
    }
}
