using GPBag.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using System.Linq;

namespace GPBag.Utility
{
    public class CSV_Read_Write<T>
    {
        private const string csvPath = "bagdata.csv";
        public static void WriteDataToCSV(BaggageGridModel model, string fileName = "bagdata.csv" )
        {


            //using (var stream = File.Open("bagdata.csv", FileMode.Append))
            using (var writer = new StreamWriter(fileName, true))
            {
               

                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecord(model);
                    writer.Write("\n");
                }
            }
           
        }

        public static List<T> ReadDataFromCSV(string fileName = "bagdata.csv")
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
           if(!File.Exists(csvPath))
            {
                File.Create(csvPath);
            }

            using (var stream = File.Open(fileName, FileMode.Open))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, configPersons))
            {
                var data = csv.GetRecords<T>();
                return data.ToList();
            }
         
        }

    }
}
