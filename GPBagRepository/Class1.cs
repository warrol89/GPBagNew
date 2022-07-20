using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace GPBagRepository
{
    public class GPBagContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=GPBag;Integrated Security=True;");
        }

        public DbSet<BaggageGridModel> BaggageGridModels { get; set; }


    }
}
