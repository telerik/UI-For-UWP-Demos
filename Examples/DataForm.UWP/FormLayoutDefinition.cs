using System;
using System.Collections.Generic;
using System.Text;
using Telerik.UI.Xaml.Controls.Data.DataForm;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DataForm;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using Telerik.UI.Xaml.Controls.Primitives;

namespace DataForm.FirstLook
{
    public class FormLayoutDefinition : StackDataFormLayoutDefinition
    {
        public Brush ImportantGroupBackground { get; set; }

        public Style ImportantGroupStyle { get; set; }


        protected override Windows.UI.Xaml.Controls.Panel CreateGroupLayoutPanel(string groupKey)
        {
            if (groupKey == "TABLE DETAILS")
            {
#if WINDOWS_APP
                Grid grid = new Grid() { Width = 600, HorizontalAlignment = HorizontalAlignment.Left };
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                return grid;
#else
                return new StackPanel() { Background = this.ImportantGroupBackground };
#endif
            }

            return base.CreateGroupLayoutPanel(groupKey);
        }

        protected override void SetEditorArrangeMetadata(Telerik.UI.Xaml.Controls.Data.EntityPropertyControl editorElement, Telerik.Data.Core.EntityProperty entityProperty, Panel parentPanel)
        {
#if WINDOWS_APP
            if (entityProperty.PropertyName == "Section")
            {
                editorElement.SetValue(Grid.ColumnProperty, 0);
            }
            if (entityProperty.PropertyName == "TableNumber")
            {
                editorElement.SetValue(Grid.ColumnProperty, 1);
            }
            if (entityProperty.PropertyName == "Origin")
            {
                editorElement.Width = 600;
                editorElement.HorizontalAlignment = HorizontalAlignment.Left;
            }
#endif

        }

        protected override void SetEditorElementsArrangeMetadata(Telerik.UI.Xaml.Controls.Data.EntityPropertyControl editorElement, Telerik.Data.Core.EntityProperty entityProperty)
        {
//#if WINDOWS_APP
            base.SetEditorElementsArrangeMetadata(editorElement, entityProperty);

            if (entityProperty.PropertyName == "Name")
            {
                editorElement.RowCount = 0;
                editorElement.ColumnCount = 0;
            }

//#endif
        }

        protected override void SetGroupArrangeMetadata(UIElement groupVisual, string groupName)
        {
            base.SetGroupArrangeMetadata(groupVisual, groupName);

            var groupControl = groupVisual as RadExpanderControl;

#if WINDOWS_APP
            if (groupName == "RESERVATION INFORMATION")
            {
                groupControl.Width = 600;
                groupControl.HorizontalAlignment = HorizontalAlignment.Left;
            }
#endif

            if (groupName == "TABLE DETAILS")
            {
                groupControl.Style = this.ImportantGroupStyle;
            }

#if WINDOWS_PHONE_APP
         //   groupControl.Padding = new Thickness(10, 0, 10, 0);
#endif
        }
    }
}
