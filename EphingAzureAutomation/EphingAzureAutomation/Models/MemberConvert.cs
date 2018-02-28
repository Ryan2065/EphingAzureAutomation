using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EphingAzureAutomation
{
    class MemberConvert
    {
        public static string GetString(object ConvertObject)
        {
            return ConvertObject as string;
            
        }

        public static DateTimeOffset GetDateTimeOffset(object ConvertObject)
        {
            var tempDateTime = ConvertObject as DateTimeOffset?;
            if (tempDateTime.HasValue)
            {
                return (tempDateTime ?? default(DateTimeOffset));
            }
            else
            {
                return DateTimeOffset.MinValue;
            }
        }

        public static int GetInt(object ConvertObject)
        {
            var tempInt = ConvertObject as int?;
            if (tempInt.HasValue)
            {
                return (tempInt ?? default(int));
            }
            else
            {
                return 0;
            }
        }

        public static bool GetBool(object ConvertObject)
        {
            var tempBool = ConvertObject as bool?;
            if (tempBool.HasValue)
            {
                return tempBool.Value;
            }
            else
            {
                return false;
            }
        }

        public static Hashtable GetHashtable(object ConvertObject)
        {
            var tempHash = ConvertObject as Hashtable;
            return tempHash;
        }
    }
}
