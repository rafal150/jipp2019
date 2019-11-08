using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace applicationWpf
{
    abstract class BasicConverter
    {
        protected double value;
        protected double convertedValue = double.NaN; 
        protected int fromIndex;
        protected int toIndex;

        protected string converterName;

        protected string[] indexes;

        protected string[] suffix;

        public BasicConverter(double value, int fromIndex, int toIndex)
        {
            this.value = value;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        public BasicConverter()
        {
            this.value = 0;
            this.fromIndex = 0;
            this.toIndex = 0;
        }

        public string GetConvertedString()
        {
            if (convertedValue != double.NaN)
                return $"{convertedValue} {suffix[toIndex]}";
            else return "NaN";
        }

        protected void AddDbEntry()
        {
            MainWindow.repo.AddStatistic(new StatisticsDTO()
            {
                Date = DateTime.Now,
                SourceUnit = suffix[fromIndex],
                SourceValue = value,
                ConvertedUnit = suffix[toIndex],
                ConvertedValue = convertedValue,
                Type = converterName
            });
        }

        public abstract void Convert();
    }
}
