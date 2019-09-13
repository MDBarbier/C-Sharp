using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DateParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string weirdDate = "31:12:2019 00:00:00";
            string weirdDate2 = "31!12!2019 00!00!00";
            string weirdDate3 = "31|12|201900|00|00";
            string weirdDate4 = "31122019000000";

            string formatString = "dd':'MM':'yyyy' 'HH':'mm':'ss";
            string formatString2 = "dd:MM:yyyy HH:mm:ss";
            string formatString3 = "dd!MM!yyyy HH!mm!ss";
            string formatString4 = "dd|MM|yyyyHH|mm|ss";
            string formatString5 = "ddMMyyyyHHmmss";

            var parsedDate = ParseDateFromStringWithFormat(weirdDate, formatString);
            var parsedDate2 = ParseDateFromStringWithFormat2(weirdDate, formatString2);
            var parsedDate3 = ParseDateFromStringWithFormat2(weirdDate2, formatString3);
            var parsedDate4 = ParseDateFromStringWithFormat2(weirdDate3, formatString4);
            var parsedDate5 = ParseDateFromStringWithFormat2(weirdDate4, formatString5);

            Console.WriteLine($"The parsed date is {parsedDate}");
            Console.WriteLine($"The parsed date2 is {parsedDate2}");
            Console.WriteLine($"The parsed date3 is {parsedDate3}");
            Console.WriteLine($"The parsed date4 is {parsedDate4}");
            Console.WriteLine($"The parsed date5 is {parsedDate5}");
            Console.ReadLine();
        }

        public static DateTime ParseDateFromStringWithFormat(string datetime, string format)
        {
            if (!DateTime.TryParseExact(datetime, format, null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                throw new InvalidOperationException("Failed to parse the supplied date with the supplied format");
            }

            return result;
        }

        public static DateTime ParseDateFromStringWithFormat2(string datetime, string format)
        {
            char precedingChar = '\0';
            string finalValue = string.Empty;

            using (StringWriter sw = new StringWriter())
            {
                foreach (char c in format)
                {
                    //If char is alphanumeric...
                    if (isAlphaNumeric(c))
                    {
                        //was the last char non-alphanumeric?
                        if (precedingChar != '\0' && !isAlphaNumeric(precedingChar))
                        {
                            sw.Write('\'');
                            sw.Write(c);
                        }
                        else
                        {
                            sw.Write(c);
                        }
                    }
                    else
                    {               
                        /*Was the preceding character alphanumeric?*/
                        if (isAlphaNumeric(precedingChar))
                        {
                            //If so, write a single quote THEN the character
                            sw.Write('\'');
                            sw.Write(c);
                        }
                        else
                        {
                            //else, write the character as-is
                            sw.Write(c);
                        }
                        
                    }

                    precedingChar = c;
                }

                finalValue = sw.ToString();
                
            }

            if (!DateTime.TryParseExact(datetime, finalValue, null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                throw new InvalidOperationException("Failed to parse the supplied date with the supplied format");
            }

            return result;

        }

        public static Boolean isAlphaNumeric(char charToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(charToCheck.ToString());
        }
    }
}
