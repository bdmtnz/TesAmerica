using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesAmerica.Domain.Base
{
    public static class Utils
    {
        public static string GetStartDbDate(DateTime start)
        {
            var parseDate = start.ToString("s");
            var dateWithoutTime = parseDate.Split("T");
            return $"{dateWithoutTime[0]} 00:00:00.000";
        }

        public static string GetEndDbDate(DateTime end)
        {
            var parseDate = end.ToString("s");
            var dateWithoutTime = parseDate.Split("T");
            return $"{dateWithoutTime[0]} 23:59:00.000";
        }
    }
}
