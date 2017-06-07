using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RadialMenu.Customization
{
    public class MenuControl : ContentControl
    {
        /// <summary>
        /// Identifies the <see cref="MenuPosition"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MenuPositionProperty =
            DependencyProperty.Register("MenuPosition", typeof(Position), typeof(MenuControl), new PropertyMetadata(Position.Right));

        public Position MenuPosition
        {
            get
            {
                return (Position)this.GetValue(MenuPositionProperty);
            }
            set
            {
                this.SetValue(MenuPositionProperty, value);
            }
        }

        public MenuControl()
        {
            this.DefaultStyleKey = typeof(MenuControl);
            this.LayoutUpdated += MenuControl_LayoutUpdated;
        }

        void MenuControl_LayoutUpdated(object sender, object e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                PictureInfo viewModel = this.DataContext as PictureInfo;

                if (viewModel == null)
                {
                    return;
                }

                switch (this.MenuPosition)
                {
                    case Position.Right:
                        {
                            this.VerticalAlignment = VerticalAlignment.Center;
                            this.HorizontalAlignment = HorizontalAlignment.Right;
                            viewModel.MenuStartAngle = 90;
                        }
                        break;
                    case Position.Left:
                        {
                            this.VerticalAlignment = VerticalAlignment.Center;
                            this.HorizontalAlignment = HorizontalAlignment.Left;
                            viewModel.MenuStartAngle = 270;
                        }
                        break;
                    case Position.Top:
                        {
                            this.HorizontalAlignment = HorizontalAlignment.Center;
                            this.VerticalAlignment = VerticalAlignment.Top;
                            viewModel.MenuStartAngle = 180;
                        }
                        break;
                    case Position.Bottom:
                        {
                            this.HorizontalAlignment = HorizontalAlignment.Center;
                            this.VerticalAlignment = VerticalAlignment.Bottom;
                            viewModel.MenuStartAngle = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
