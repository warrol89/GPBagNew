using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace GPBag.Models
{
  

    public enum BagSize
    {
        Small = 0,
        Medium,
        Large,
        XLarge

    }

    public class StorageRate
    {
        public string Size { get; set; }
        public int Rate_1Day { get; set; }
        public int Rate_2_14Day { get; set; }
        public int Rate_15_30Day { get; set; }
    }
}

