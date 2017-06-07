using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Telerik.Core;

namespace Grid.Editing.Data
{
    public class EditingViewModel : ViewModelBase
    {
        public EditingViewModel()
        {
            this.Data = this.LoadData();
        }

        private ObservableCollection<TaskData> LoadData()
        {
            var data = new ObservableCollection<TaskData>();
            var path = "Grid.Editing.Data.Data.xml";

            Action<XElement, TaskData> childElementAction = (el, a) =>
                {
                    string value = el.Value;

                    switch (el.Name.LocalName)
                    {
                        case "Id":
                            a.Id = int.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "Task":
                            a.TaskName = value;
                            break;
                        case "Effort":
                            a.Effort = int.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "Role":
                            a.Role = value;
                            break;
                        case "StartDate":
                            if (!string.IsNullOrEmpty(value))
                            {
                                a.StartDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
                            }
                            break;
                        case "EndDate":
                            if (!string.IsNullOrEmpty(value))
                            {
                                a.EndDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
                            }
                            break;
                        case "Cost":
                            a.Cost = int.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "Group":
                            a.Group = int.Parse(value, CultureInfo.InvariantCulture);
                            break;
                    }
                };

            Action<TaskData> elementAction = (q) =>
            {
                data.Add(q);
            };

            XmlDataParser.Parse<TaskData>(path, elementAction, childElementAction);

            return data;
        }

        public ObservableCollection<TaskData> Data { get; set; }
    }
}
