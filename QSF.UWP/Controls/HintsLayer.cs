using System;
using System.Linq;
using QSF.Common;
using QSF.Infrastructure.Extensions;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace QSF.Controls
{
    public class HintsLayer : Control
    {
        // Using a DependencyProperty as the backing store for BottomHintStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BottomHintStyleProperty =
            DependencyProperty.Register("BottomHintStyle", typeof(Style), typeof(HintsLayer), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for HintsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HintsSourceProperty =
            DependencyProperty.Register("HintsSource", typeof(HintsCollection), typeof(HintsLayer), new PropertyMetadata(null, OnHintsSourcePropertyChanged));

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(HintsLayer), new PropertyMetadata(false, OnIsOpenPropertyChanged));

        // Using a DependencyProperty as the backing store for LeftHintStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftHintStyleProperty =
            DependencyProperty.Register("LeftHintStyle", typeof(Style), typeof(HintsLayer), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for RightHintStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightHintStyleProperty =
            DependencyProperty.Register("RightHintStyle", typeof(Style), typeof(HintsLayer), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for TopHintStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TopHintStyleProperty =
            DependencyProperty.Register("TopHintStyle", typeof(Style), typeof(HintsLayer), new PropertyMetadata(null));

        //Canvas canvas;
        Windows.UI.Xaml.Controls.Grid rootPanel;

        public HintsLayer()
        {
            this.IsHitTestVisible = false;
            this.Visibility = Visibility.Collapsed;

            this.DefaultStyleKey = typeof(HintsLayer);
        }

        public Style BottomHintStyle
        {
            get
            {
                return (Style)this.GetValue(BottomHintStyleProperty);
            }
            set
            {
                this.SetValue(BottomHintStyleProperty, value);
            }
        }

        public HintsCollection HintsSource
        {
            get
            {
                return (HintsCollection)this.GetValue(HintsSourceProperty);
            }
            set
            {
                this.SetValue(HintsSourceProperty, value);
            }
        }

        public bool IsOpen
        {
            get
            {
                return (bool)this.GetValue(IsOpenProperty);
            }
            set
            {
                this.SetValue(IsOpenProperty, value);
            }
        }

        public Style LeftHintStyle
        {
            get
            {
                return (Style)this.GetValue(LeftHintStyleProperty);
            }
            set
            {
                this.SetValue(LeftHintStyleProperty, value);
            }
        }

        public Style RightHintStyle
        {
            get
            {
                return (Style)this.GetValue(RightHintStyleProperty);
            }
            set
            {
                this.SetValue(RightHintStyleProperty, value);
            }
        }

        public Style TopHintStyle
        {
            get
            {
                return (Style)this.GetValue(TopHintStyleProperty);
            }
            set
            {
                this.SetValue(TopHintStyleProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.rootPanel = this.GetTemplateChild("PART_Root") as Windows.UI.Xaml.Controls.Grid;
            
            if (this.IsOpen)
            {
                this.RefreshChildren();
            }
        }

        protected override void OnTapped(Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            base.OnTapped(e);
            this.IsOpen = false;
        }

        private static void OnHintsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newHints = e.NewValue as HintsCollection;
            HintsLayer thisInstance = (d as HintsLayer);
            if (thisInstance.IsOpen)
            {
                thisInstance.RefreshChildren();
            }
        }
  
        private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool visible = (bool)e.NewValue;
            HintsLayer thisInstance = (d as HintsLayer);

            if (visible)
            {
                thisInstance.IsHitTestVisible = true;
                thisInstance.Visibility = Visibility.Visible;
                thisInstance.RefreshChildren();
            }
            else
            {
                thisInstance.IsHitTestVisible = false;
                thisInstance.Visibility = Visibility.Collapsed;
                thisInstance.ClearChildren();
            }
        }

        private void ClearChildren()
        {
            if (this.rootPanel != null)
            {
                this.rootPanel.Children.Clear();
            }
        }

        private ContentControl GenerateHintItem(Hint hint)
        {
            var container = new ContentControl();
            
            var element = VisualTreeHelperExtensions.GetChildByName(Window.Current.Content as Control, hint.PlacementTargetName);
            Rect elementRect = VisualTreeHelperExtensions.GetElementRect(element);
            PlacementMode placement = hint.Placement;

            container.Width = hint.Width != 0 ? hint.Width : 50;
            container.Height = hint.Height != 0 ? hint.Height : 50; 
            container.Content = hint.Content;

            double left = 0;
            double top = 0;
            Style style = null;

            switch (placement)
            {
                case PlacementMode.Bottom:
                    {
                        left = elementRect.Left + elementRect.Width / 2 - container.Width / 2;
                        top = elementRect.Top + elementRect.Height;
                        style = this.BottomHintStyle;
                    }
                    break;
                case PlacementMode.Top:
                    {
                        left = elementRect.Left + elementRect.Width / 2 - container.Width / 2;
                        top = elementRect.Top - container.Height;
                        style = this.TopHintStyle;
                    }
                    break;
                case PlacementMode.Left:
                    {
                        left = elementRect.Left - container.Width;
                        top = elementRect.Top + elementRect.Height / 2 - container.Height / 2;
                        style = this.LeftHintStyle;
                    }
                    break;
                case PlacementMode.Right:
                    {
                        left = elementRect.Left + elementRect.Width;
                        top = elementRect.Top + elementRect.Height / 2 - container.Height / 2;
                        style = this.RightHintStyle;
                    }
                    break;
            }

            container.Margin = new Thickness(left, top, 0, 0);
            container.SetValue(ToolTip.StyleProperty, style);

            return container;
        }

        private void RefreshChildren()
        {
            if (this.HintsSource == null || this.rootPanel == null)
            {
                return;
            }

            this.ClearChildren();

            foreach (var hint in this.HintsSource)
            {
                var tooltip = this.GenerateHintItem(hint);
                
                this.rootPanel.Children.Add(tooltip);
            }
        }
    }
}