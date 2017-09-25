using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            //This simulates a Scientia appointment from the View
            DateTime originalTime = DateTime.Parse("2017/09/26 18:00:00");

            //This code simulates converting to a Time zone based on the timezone field from canvas user profile
            //This would be done in the scientia-canvas-sync, after comparison but before transmission over API
            bool error1;
            DateTime convertedToTallinnTime = TzConverter.ConvertToTargetTimeZoneFromLocalTime(originalTime, "Tallinn", out error1);

            if (error1)
            {
                //remedial action
            }

            //These 2 lines are just converting to UTC which would happen when we DL the appointment from the Canvas API
            TimeZoneInfo tz = TzConverter.GetTimeZoneInfo("Tallinn");
            DateTime backToUtc = TimeZoneInfo.ConvertTimeToUtc(convertedToTallinnTime, tz);

            //This is how we would convert the time downloaded from Canvas API before comparison/storing
            DateTime local = TzConverter.ConvertFromUtcToLocalTime(backToUtc);

            //This just shows how a time can be converted directly from target TZ to local time if needed
            bool error2;
            DateTime backToLocal = TzConverter.ConvertToLocalTimeFromTargetTimeZone(convertedToTallinnTime, "Tallinn", out error2);

            if (error2)
            {
                //remedial action
            }

            //Logging
            Console.WriteLine($"Converted output: {convertedToTallinnTime.ToString()}");
            Console.WriteLine($"Converted back to UTC: {backToUtc}");
            Console.WriteLine($"Converted to local time: {local}");
            Console.WriteLine($"Converted straight from Tallinn time to UK time: {backToLocal}");
            Console.WriteLine("Original input: " + originalTime.ToString());
            Console.ReadLine();
        }
    }
}
