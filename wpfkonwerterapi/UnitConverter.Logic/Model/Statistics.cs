﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFKonwerter.Model
{
    public class Statistics
    {
        public int Id { get; set; }
        public DateTime ConversionDT { get; set; }
        public string CategoryType { get; set; }
        public string UnitFrom { get; set; }
        public string ValueFrom { get; set; }
        public string UnitTo { get; set; }
        public string ValueTo { get; set; }

    }
}
