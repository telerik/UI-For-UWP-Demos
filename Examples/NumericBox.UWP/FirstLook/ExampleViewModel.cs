using System.Collections;
using Telerik.Core;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace NumericBox.FirstLook
{
    public class ExampleViewModel : ViewModelBase
    {
        private Brush background;
        private Brush foreground;
        private NamedColor foregroundColor;
        private byte alpha;
        private byte red;
        private byte green;
        private byte blue;
        private double fontSize;
        private bool updating;

        public ExampleViewModel()
        {
            this.fontSize = 20;
            this.foregroundColor = new NamedColor() { Color = Colors.White, Name = "White" };
            this.foreground = new SolidColorBrush(Colors.White);
        }

        public IEnumerable AvailableColors
        {
            get
            {
                return new NamedColor[]
                {
                    new NamedColor() { Color = Colors.White, Name = "White" },
                    new NamedColor() { Color = Colors.Black, Name = "Black" },
                    new NamedColor() { Color = Colors.Gray, Name = "Gray" }
                };
            }
        }

        public double FontSize
        {
            get
            {
                return this.fontSize;
            }
            set
            {
                this.fontSize = value;
                this.OnPropertyChanged();
            }
        }

        public Brush Background
        {
            get
            {
                return this.background;
            }
            set
            {
                this.background = value;
                this.UpdateArgb();
                this.OnPropertyChanged();
            }
        }

        public Brush Foreground
        {
            get
            {
                return this.foreground;
            }
            set
            {
                this.foreground = value;
                this.OnPropertyChanged();
            }
        }

        public NamedColor ForegroundColor
        {
            get
            {
                return this.foregroundColor;
            }
            set
            {
                this.foregroundColor = value;
                this.OnPropertyChanged();
                this.Foreground = new SolidColorBrush(value.Color);
            }
        }

        public double Red
        {
            get
            {
                return this.red;
            }
            set
            {
                this.red = (byte)value;
                this.BuildBrush();
                this.OnPropertyChanged();
            }
        }

        public double Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = (byte)value;
                this.BuildBrush();
                this.OnPropertyChanged();
            }
        }

        public double Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = (byte)value;
                this.BuildBrush();
                this.OnPropertyChanged();
            }
        }

        public double Alpha
        {
            get
            {
                return this.alpha;
            }
            set
            {
                this.alpha = (byte)value;
                this.BuildBrush();
                this.OnPropertyChanged();
            }
        }

        private void BuildBrush()
        {
            if (this.updating)
            {
                return;
            }

            var brush = new SolidColorBrush(Color.FromArgb(this.alpha, this.red, this.green, this.blue));
            this.Background = brush;
        }

        private void UpdateArgb()
        {
            var solidColorBrush = this.background as SolidColorBrush;
            if (solidColorBrush == null)
            {
                return;
            }

            this.updating = true;

            var color = solidColorBrush.Color;

            this.Alpha = color.A;
            this.Red = color.R;
            this.Green = color.G;
            this.Blue = color.B;

            this.updating = false;
        }
    }

    public class NamedColor
    {
        public Color Color
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return this.Color.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var namedColor = obj as NamedColor;
            if (namedColor == null)
            {
                return false;
            }

            return namedColor.Color == this.Color;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
