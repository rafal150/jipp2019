//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Plugins;

namespace Converter.WindowHandler
{
    class WindowProperties
    {
        public static List<string> listOfProperty = 
            new List<string> {General.distance,General.temperature,General.weight,General.voltage};
        /*public List<string> ListOfProperty
        {
            get
            {
                return this.listOfProperty;
            }
        }*/

        public static List<string> listOfTemperatureUnits = 
            new List<string> { Temperature.C, Temperature.F, Temperature.R, Temperature.K };
        /*public List<string> ListOfTemperatureUnits
        {
            get
            {
                return this.listOfTemperatureUnits;
            }
        }*/

        public static List<string> listOfWeightUnits = 
            new List<string> { Weight.ct,Weight.dkg,Weight.g,Weight.kg,Weight.lbs,Weight.mg,Weight.oz,Weight.q,Weight.T };
        /*public List<string> ListOfWeightUnits
        {
            get
            {
                return this.listOfWeightUnits;
            }
        }*/

        public static List<string> listOfDistanceUnits = 
            new List<string> { Distance.cabel,Distance.cm,Distance.dm,Distance.ft,Distance.inch,Distance.km,Distance.m,Distance.mile,Distance.nauticalMile,Distance.mm, Distance.yard };
        /*public List<string> ListOfDistanceUnits
        {
            get
            {
                return this.listOfDistanceUnits;
            }
        }*/

        public static List<string> listOfVoltageUnits =
        new List<string> { Voltage.v,Voltage.mv,Voltage.kv};


        public static double StringToDouble(string value)
        {
            double result;
            try
            {
                return result = Double.Parse(value);
            }
            catch(FormatException)
            {
                return 0;
            }
            
        }
        public static string DoubleToString(double value)
        {
            return value.ToString();
        }
    }
}