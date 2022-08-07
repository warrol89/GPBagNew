using GPBag.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace GPBag.Data
{
    public class GPContext: DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Gpbag;trusted_connection=true;");
        }

        public DbSet<BaggageGridModel> BaggageGridModel { get; set; }
        public DbSet<BaggageGridModelArchive> BaggageGridModelArchive { get; set; }

    }
}
