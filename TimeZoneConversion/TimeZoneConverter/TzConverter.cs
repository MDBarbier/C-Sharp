using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeZoneConverter
{
    public class TzConverter
    {
        //To be used when you are confident that only one time zone will contain the string you send
        public static DateTime ConvertToTargetTimeZoneFromLocalTime(DateTime toConvert, string sourceTimeZone, out bool error)
        {
            error = false;

            DateTime utc = toConvert.ToUniversalTime();

            IReadOnlyCollection<TimeZoneInfo> cstZonse = TimeZoneInfo.GetSystemTimeZones();

            TimeZoneInfo tz = cstZonse.Where(a => a.DisplayName.Contains(sourceTimeZone)).FirstOrDefault();

            if (tz == null)
            {
                error = true;
                return new DateTime();
            }
            else
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utc, tz);
            }            
        }

        //To be used when you are confident that only one time zone will contain the string you send
        public static DateTime ConvertToTargetTimeZoneFromUtcTime(DateTime toConvert, string sourceTimeZone, out bool error)
        {
            error = false;

            IReadOnlyCollection<TimeZoneInfo> cstZonse = TimeZoneInfo.GetSystemTimeZones();

            TimeZoneInfo tz = cstZonse.Where(a => a.DisplayName.Contains(sourceTimeZone)).FirstOrDefault();

            if (tz == null)
            {
                error = true;
                return new DateTime();
            }
            else
            {
                return TimeZoneInfo.ConvertTimeFromUtc(toConvert, tz);
            }
            
        }

        public static DateTime ConvertToLocalTimeFromTargetTimeZone(DateTime toConvert, string sourceTimeZone, out bool error)
        {
            error = false;

            IReadOnlyCollection<TimeZoneInfo> cstZonse = TimeZoneInfo.GetSystemTimeZones();

            TimeZoneInfo tz = cstZonse.Where(a => a.DisplayName.Contains(sourceTimeZone)).FirstOrDefault();

            if (tz == null)
            {
                error = true;
                return new DateTime();
            }
            else
            {
                DateTime utc = TimeZoneInfo.ConvertTimeToUtc(toConvert, tz);

                return ConvertFromUtcToLocalTime(utc);
            }            
        }

        //To be used when you need TimeZoneInfo object from a string
        public static TimeZoneInfo GetTimeZoneInfo(string sourceTimeZone)
        {
            IReadOnlyCollection<TimeZoneInfo> cstZonse = TimeZoneInfo.GetSystemTimeZones();

            TimeZoneInfo tz = cstZonse.Where(a => a.DisplayName.Contains(sourceTimeZone)).FirstOrDefault();

            return tz;
        }

        //Takes a UTC datetime and converts to local time
        public static DateTime ConvertFromUtcToLocalTime(DateTime toConvert)
        {
            DateTime kindSpecifiedDate = DateTime.SpecifyKind(toConvert, DateTimeKind.Utc);
            DateTime convertedToLocal = kindSpecifiedDate.ToLocalTime();

            return convertedToLocal;
        }

        //Takes a string representing a UTC datetime and converts to local time, our parameter specified if successful or not
        public static DateTime ConvertStringFromUtcToLocalTime(string toConvert, out bool error)
        {
            error = false;

            DateTime parsed = new DateTime();

            try
            {
                parsed = DateTime.Parse(toConvert);
            }
            catch
            {
                error = true;
                return new DateTime();
            }

            DateTime kindSpecifiedDate = DateTime.SpecifyKind(parsed, DateTimeKind.Utc);
            DateTime convertedToLocal = kindSpecifiedDate.ToLocalTime();

            return convertedToLocal;
        }

        //To be used when you are not sure that only one time zone will contain the string you send
        public static string[] GetPotentialZones(string sourceTimeZone)
        {
            IReadOnlyCollection<TimeZoneInfo> cstZonse = TimeZoneInfo.GetSystemTimeZones();

            List<TimeZoneInfo> tzs = cstZonse.Where(a => a.DisplayName.Contains(sourceTimeZone)).ToList();
            List<string> names = new List<string>();

            foreach (var tz in tzs)
            {
                names.Add(tz.DisplayName);
            }

            return names.ToArray();
        }

        //Simple conversion from local time to UTC
        public static DateTime ConvertToUTC(DateTime toConvert)
        {
            DateTime utc = toConvert.ToUniversalTime();

            return utc;
        }
    }
}
