using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace GPBag.Models
{
    public class BaggageGridModel
    {
        private static readonly List<StorageRate> rate;

        static BaggageGridModel()
        {
            rate = new List<StorageRate>();
            rate.Add(new StorageRate { Size = "Small", Rate_1Day = 10, Rate_2_14Day = 8, Rate_15_30Day = 6 });
            rate.Add(new StorageRate { Size = "Medium", Rate_1Day = 20, Rate_2_14Day = 16, Rate_15_30Day = 14 });
            rate.Add(new StorageRate { Size = "Large", Rate_1Day = 30, Rate_2_14Day = 26, Rate_15_30Day = 24 });
            rate.Add(new StorageRate { Size = "XLarge", Rate_1Day = 50, Rate_2_14Day = 45, Rate_15_30Day = 40 });
        }



        public string Name { get; set; }
        public string RackNo { get; set; }
        public string Bagsize { get; set; }
        public int NoOfBoxes { get; set; }
        [Browsable(false)]
        public string RoomNo { get; set; }
        public DateTime? BaggageReceived { get; set; }
        public DateTime? BaggageReturned { get; set; }
        [Browsable(false)]
        public double CalculatedDays
        {
            get
            {
                TimeSpan days = TimeSpan.Zero;
                if (BaggageReturned.HasValue)
                {
                    days = BaggageReturned.Value - BaggageReceived.Value;
                }
                return Math.Floor(days.TotalDays);
            }
        }
        public double Price
        {
            get
            {
                double value = 0;
                if (this.CalculatedDays == 0) { return 0; }


                value = this.CalculateValue(rate.Where(t => t.Size.ToLower() == this.Bagsize.ToLower()).FirstOrDefault(), CalculatedDays);

                return value * NoOfBoxes;
            }
        }

        private  double CalculateValue(StorageRate rateDetails, double days)
        {
            if (days < 2)
            {
                return rateDetails.Rate_1Day * days;
            }
            if (days >= 2 && days <= 14)
            {
                return rateDetails.Rate_2_14Day * days;
            }
            if (days >= 15 && days <= 30)
            {
                return rateDetails.Rate_15_30Day * days;
            }
            return 0;

        }
    }



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

