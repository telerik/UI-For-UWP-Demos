using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QSF.Model
{
	public class ExampleInfo : INotifyPropertyChanged, IExampleInfo
	{
		private string description;
		private bool isFavourite;

		public ExampleInfo()
		{
			this.UniqueId = Guid.NewGuid();
		}

		public ExampleInfo(Guid id)
		{
			this.UniqueId = id;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public IEnumerable<ExampleHighlightInfo> Highlights { get; set; }

		public IExampleGroupInfo ExampleGroup { get; internal set; }

		public string Text { get; internal set; }

		public string Name { get; internal set; }

        public bool IsExampleFullScreen { get; set; }

		public Enums.StatusMode Status { get; internal set; }

		public Enums.PlatformType Platform { get; internal set; }

		public bool IsDefault { get; internal set; }

		public bool IsFavourite
		{
			get 
			{
				return this.isFavourite;
			}
			set
			{
				this.isFavourite = value;
				this.OnPropertyChanged("IsFavourite");
			}
		}

		public string PackageName { get; internal set; }

		public string Keywords { get; internal set; }

		public Enums.ExampleType Type { get; internal set; }

		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				if (this.description != value)
				{
					this.description = value;
					this.OnPropertyChanged("Description");
				}
			}
		}

		public List<string> CommonFolders { get; internal set; }

		public string PinnedImage
		{
			get
			{
				return this.ExampleGroup.Control.PinnedImage;
			}
		}
        
		public string SmallImage
		{
			get
			{
				return this.ExampleGroup.Control.SmallImage;
			}
		}

		public string MediumImage
		{
			get
			{
				return this.ExampleGroup.Control.MediumImage;
			}
		}

		public string LargeImage
		{
			get
			{
				return this.ExampleGroup.Control.LargeImage;
			}
		}

		public Guid UniqueId { get; private set; }

		public string HeaderText { get; internal set; }

		public bool CanPinToDesktop { get; internal set; }

		/// <summary>
		/// Short name of the example. If the name is Chart.FirstLook.Example, the short name should be "FirstLook".
		/// </summary>
		internal string ShortName { get; set; }

		/// <summary>
		/// A shorthand property for control name of the example. <br/>
		/// </summary>
		internal string ControlName { get; set; }

		public override int GetHashCode()
		{
			return this.Name == null ? 0 : this.Name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ExampleInfo e = obj as ExampleInfo;
			if (e == null)
			{
				return false;
			}
			else
			{
				return this.Name == e.Name && this.ExampleGroup.Name == e.ExampleGroup.Name && this.ExampleGroup.Control == e.ExampleGroup.Control && this.PackageName == e.PackageName;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		public string GetReadableName()
		{
			if (!string.IsNullOrEmpty(this.ShortName))
			{
				return this.ShortName;
			}
			else
			{
				return this.Name;
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}