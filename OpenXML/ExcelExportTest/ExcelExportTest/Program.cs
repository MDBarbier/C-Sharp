using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelExportTest
{
    public struct TestData
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        private static string excelPath = @"c:\logfiles\excel-test2.xlsx";
        private static string tempPath = Path.GetTempFileName();
        static void Main(string[] args)
        {
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
            if (File.Exists(excelPath))
            {
                File.Delete(excelPath);
            }

            dynamic data = PopulateTestData();

            ExcelFunctions.CreateSpreadsheet(tempPath, "Test spreadsheet");
            ExcelFunctions.EditWorkbook(tempPath, data);

            File.Copy(tempPath, excelPath);

        }

        private static dynamic PopulateTestData()
        {
            dynamic data = new List<TestData>();

            data.Add(new TestData()
            {
                Age = 35,
                Name = "Matt"
            });

            data.Add(new TestData()
            {
                Age = 36,
                Name = "Heather"
            });
            return data;
        }
    }
}
