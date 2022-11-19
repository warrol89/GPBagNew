using GPBag.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using GPBag.Data.Models;
using GpBag.Service.Utility;

namespace GpBag.Service
{
    public class GpGridService
    {
        public readonly GPContext context;
        public GpGridService()
        {
            context = new GPContext();
        }

        public List<BaggageGridModel> GetBaggageDetails()
        {
           return context.BaggageGridModel.ToList();
        }

        public List<BaggageGridModelArchive> GetBaggageArchiveDetails()
        {
            return context.BaggageGridModelArchive.ToList();
        }

        public bool AddBaggageDetails(BaggageGridModel baggageDetails)
        {
             context.Add(baggageDetails);
            var val = context.SaveChanges() > 0;
            return val;
        }

        public bool AddBaggageArchiveDetails(BaggageGridModelArchive baggageDetails)
        {
            context.Add(baggageDetails);
            var val = context.SaveChanges() > 0;
            return val;
        }

        public bool UpdateValues(BaggageGridModel details)
        {
            context.Update(details);
            var val = context.SaveChanges() > 0;
            return val;
        }

        public bool AddRangeBaggageDetails(List<BaggageGridModel> listToAdd)
        {
            context.BaggageGridModel.AddRange(listToAdd);
            var val = context.SaveChanges() > 0;
            return val;
        }

        public bool CheckoutCurrentBaggage()
        {
            List<BaggageGridModelArchive> details = new List<BaggageGridModelArchive>();
            foreach(var value in GetBaggageDetails())
            {
                details.Add(value.ToArchive());
               //AddBaggageArchiveDetails(value.ToArchive());
            }
            context.BaggageGridModelArchive.AddRange(details);
            context.BaggageGridModel.RemoveRange(GetBaggageDetails().Where(t=>t.Price >0));
            return  context.SaveChanges() > 0;
        }
    }
}
