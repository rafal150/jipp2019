using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MójKonwerterJednostek.Jednostki;


namespace MójKonwerterJednostek.Konwertery
{
    class MyConverter
    {
        public bool RecordSaved { get; private set; }
        public double myInputValue { get; private set; }
        public double myOutputValue { get; private set; }

        public UnitTypes myInput { get; private set; }
        public UnitTypes myOutput { get; private set; }

        private string myOutputValueString;

        public MyConverter(UnitTypes Input, string InputValue, UnitTypes Output)
        { this.ChangeValue(Input, InputValue, Output); }
        public string provideOutput() { return myOutputValueString; }
        public void ChangeValue(UnitTypes Input, string InputValue, UnitTypes Output)
        {
            try { myInputValue = Double.Parse(InputValue); }
            catch (FormatException)
            { myOutputValueString = "Złe Dane"; }

            if (myOutputValueString != "Złe Dane")
            {
                Unit Input1;

                if (Input.GetEnumDescription() == "Length")
                    Input1 = new LengthUnit(myInputValue, Input);
                else if (Input.GetEnumDescription() == "Weight")
                    Input1 = new WeightUnit(myInputValue, Input);
                else // if (Input.GetEnumDescription() == "Temperature")
                    Input1 = new TemperatureUnit(myInputValue, Input);

                myOutputValue = Math.Round(Input1.ConvertUnit(Output), 4);
                myOutputValueString = myOutputValue.ToString();
                this.myInput = Input;
                this.myOutput = Output;

                
                
            }

            
        }

    }

}
