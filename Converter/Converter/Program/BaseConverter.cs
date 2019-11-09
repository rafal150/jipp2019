//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Converter.Program
{
    public abstract class BaseConverter
    {
        public BaseConverter(string fromUnit, string toUnit, double value, DateTime convertingTime , string physicalProperty)
        {
            this.FromUnit = fromUnit;
            this.ToUnit = toUnit;
            this.Value = value;
            this.PhysicalProperty = physicalProperty;
            this.ConvertingTime = convertingTime;
        }

        public BaseConverter()
        {

        }

        public int Id { get; set; }
        private string fromUnit;
        public string FromUnit
        {
            get
            {
                return this.fromUnit;
            }
            set
            {
                this.fromUnit = value;
            }
        }

        private string toUnit;
        public string ToUnit
        {
            get
            {
                return this.toUnit;
            }
            set
            {
                this.toUnit = value;
            }
        }

        private double result;
        public double Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }

        private double value;
        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        private DateTime convertingTime;
        public DateTime ConvertingTime
        {
            get
            {
                return this.convertingTime;
            }
            set
            {
                this.convertingTime = value;
            }
        }

        private string physicalProperty;
        public string PhysicalProperty
        {
            get
            {
                return this.physicalProperty;
            }
            set
            {
                this.physicalProperty = value;
            }
        }

        public abstract void Convert();
    }
}