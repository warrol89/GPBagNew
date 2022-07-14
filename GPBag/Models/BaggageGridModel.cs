using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GPBag.Models
{
    public class BaggageGridModel
    {
        public string Name { get; set; }
        public string RackNo { get; set; }
        public string Bagsize { get; set; }
        public int NoOfBoxes { get; set; }
        public string RoomNo { get; set; }
        public DateTime? BaggageReceived { get; set; }
        public DateTime? BaggageReturned { get; set; }
        [Browsable(false)]
        public double CalculatedHours
        {
            get
            {
                TimeSpan days = TimeSpan.Zero;
                if (BaggageReturned.HasValue)
                {
                    days = BaggageReturned.Value - BaggageReceived.Value;
                }
                return Math.Floor(days.TotalHours);
            }
        }
        public double Price
        {
            get
            {
                var value = 0;
                if (this.CalculatedHours == 0) { return 0; }
                var calculatedDays = (CalculatedHours / 24);

                switch (this.Bagsize.ToLower())
                {
                    case "small":
                        value = NoOfBoxes * 10;
                        break;
                    case "medium":
                        value = NoOfBoxes * 20;
                        break;
                    case "large":
                        value = NoOfBoxes * 30;
                        break;
                    case "xlarge":
                        value = NoOfBoxes * 50;
                        break;
                    default:
                        value = NoOfBoxes * 0;
                        break;
                }
                return value * calculatedDays;
            }
        }
    }



    public enum BagSize
    {
        Small = 0,
        Medium,
        Large,
        XLarge

    }
}

