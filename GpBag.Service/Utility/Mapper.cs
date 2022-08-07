using GPBag.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GpBag.Service.Utility
{
     public static class Mapper
    {
        public static BaggageGridModelArchive ToArchive(this BaggageGridModel detail)
        {
            BaggageGridModelArchive mappedValue = new BaggageGridModelArchive();
            mappedValue.BaggageReceived = detail.BaggageReceived;
            mappedValue.BaggageReturned = detail.BaggageReturned;
            mappedValue.Bagsize = detail.Bagsize;
            mappedValue.Bagtype = detail.Bagtype;
            mappedValue.Name = detail.Name;
            mappedValue.NoOfBoxes = detail.NoOfBoxes;
            mappedValue.RackNo = detail.RackNo;
            mappedValue.RoomNo = detail.RoomNo;
            mappedValue.Id = 0;

            return mappedValue;
        }
    }
}
