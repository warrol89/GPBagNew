using GPBag.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace GPBag.Data
{
    public class GPContext: DbContext
    {
        private string DbPath;
        public GPContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "GpDb.db");
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Gpbag;trusted_connection=true;");
        //    //optionsBuilder.UseInMemoryDatabase(databaseName: "GpDB");
        //    optionsBuilder.UseSqlite(DbPath);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"DataSource={DbPath}");

        public DbSet<BaggageGridModel> BaggageGridModel { get; set; }
        public DbSet<BaggageGridModelArchive> BaggageGridModelArchive { get; set; }

    }
}
