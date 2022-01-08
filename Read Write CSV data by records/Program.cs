using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Read_Write_CSV_data_by_records
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            Console.WriteLine("Successfully installed 'CsvHelper 27.2.1' to Read Write CSV data by records");
            Console.ReadLine();

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText("country_data.csv");
            using var csvReader = new CsvReader(streamReader, csvConfig);


            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField<string>(i, out string value); i++)
                {
                    Console.Write($"{value} ");
                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
