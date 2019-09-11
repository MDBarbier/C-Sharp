using System;

namespace DateParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string weirdDate = "31:12:2019 00:00:00";
            

            string formatString = "dd':'MM':'yyyy' 'HH':'mm':'ss";            
            var parsedDate = DateTime.ParseExact(weirdDate, formatString, null);

            Console.WriteLine($"The parsed date is {parsedDate}");
            Console.ReadLine();
        }

        public static DateTime ParseDateFromStringWithFormat(string datetime, string format)
        {
            if (DateTime.TryParseExact(datetime, format, null, null, out DateTime result))
            {

            }
        }
    }
}
