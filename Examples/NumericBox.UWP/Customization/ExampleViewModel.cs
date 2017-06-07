using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;

namespace NumericBox.Customization
{
    public class ExampleViewModel : ViewModelBase
    {
        private double currentUsd;
        private double currentEur;
        private double currentGbp;
        private double currentJpy;
        private bool updatingValues;

        public ExampleViewModel()
        {
            this.UsdValue = 30;
        }

        public double Maximum
        {
            get
            {
                return double.MaxValue;
            }
        }

        public double UsdToEurCoefficient
        {
            get
            {
                return 0.77;
            }
        }

        public double UsdToGbpCoefficient
        {
            get
            {
                return 0.6504;
            }
        }

        public double UsdToJpyCoefficient
        {
            get
            {
                return 101.6045;
            }
        }

        public double EurToUsdCoefficient
        {
            get
            {
                return 1 / this.UsdToEurCoefficient;
            }
        }

        public double UsdValue
        {
            get
            {
                return this.currentUsd;
            }
            set
            {
                this.currentUsd = value;
                this.OnPropertyChanged();
            }
        }

        public double EurValue
        {
            get
            {
                return this.currentEur;
            }
            set
            {
                this.currentEur = value;
                this.OnPropertyChanged();
            }
        }

        public double GbpValue
        {
            get
            {
                return this.currentGbp;
            }
            set
            {
                this.currentGbp = value;
                this.OnPropertyChanged();
            }
        }

        public double JpyValue
        {
            get
            {
                return this.currentJpy;
            }
            set
            {
                this.currentJpy = value;
                this.OnPropertyChanged();
            }
        }

        protected override void PropertyChangedOverride(string changedPropertyName)
        {
            if (!this.updatingValues)
            {
                this.updatingValues = true;

                switch (changedPropertyName)
                {
                    case "UsdValue":
                        this.EurValue = this.currentUsd * this.UsdToEurCoefficient;
                        this.GbpValue = this.currentUsd * this.UsdToGbpCoefficient;
                        this.JpyValue = this.currentUsd * this.UsdToJpyCoefficient;
                        break;
                    case "GbpValue":
                        this.UsdValue = this.currentGbp / this.UsdToGbpCoefficient;
                        this.EurValue = this.currentUsd * this.UsdToEurCoefficient;
                        this.JpyValue = this.currentUsd * this.UsdToJpyCoefficient;
                        break;
                    case "EurValue":
                        this.UsdValue = this.currentEur / this.UsdToEurCoefficient;
                        this.GbpValue = this.currentUsd * this.UsdToGbpCoefficient;
                        this.JpyValue = this.currentUsd * this.UsdToJpyCoefficient;
                        break;
                    case "JpyValue":
                        this.UsdValue = this.currentJpy / this.UsdToJpyCoefficient;
                        this.GbpValue = this.currentUsd * this.UsdToGbpCoefficient;
                        this.EurValue = this.currentUsd * this.UsdToEurCoefficient;
                        break;
                }

                this.updatingValues = false;
            }

            base.PropertyChangedOverride(changedPropertyName);
        }
    }
}
