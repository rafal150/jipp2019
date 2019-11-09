using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Unit
    {
        protected double value_start = 0;
        protected double value_base = 0;
        protected double value_end = 0;
        public double value_temp = 0;



        public void Set_ValueStart(double InputValue)
        {
            value_start = InputValue;
        }

        public void Set_ValueBase(double InputValue)
        {
            value_base = InputValue;
        }

        public void Set_Values(double input1, double input2)
        {
            Set_ValueStart(input1);
            Set_ValueBase(input2);
        }


        public double Get_ValueEnd()
        {
            return Math.Round(value_end,4); 
        }

        public void ConvertToBase()
        {
            value_temp = value_start * value_base;
        }

        public void ConvertToEnd()
        {
            value_end = value_temp / value_base;
        }


    }
}
