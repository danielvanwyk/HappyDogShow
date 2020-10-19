using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Reports
{
    public static class ReportConstants
    {
        private static Dictionary<string, string> internaldata;
        private static string GetValueFromInternalData(string keyname)
        {
            if (internaldata == null)
                LoadInternalData();

            if (internaldata.ContainsKey(keyname.Trim().ToUpper()))
                return internaldata[keyname.Trim().ToUpper()];

            return "not specified";
        }

        private static void LoadInternalData()
        {
            internaldata = new Dictionary<string, string>();
            List<string> settings = System.IO.File.ReadAllLines("reportsettings.txt").ToList();

            settings.ForEach(c =>
            {
                var parts = c.Split('|');
                string key = parts[0].Trim().ToUpper();
                string value = parts[1].Trim();

                if (internaldata.ContainsKey(key))
                    internaldata[key] = value;
                else
                    internaldata.Add(key, value);
            });
        }

        public static string REGION_NAME => GetValueFromInternalData("REGION_NAME");
        public static string SHOWDATE_AS_STRING => GetValueFromInternalData("SHOWDATE_AS_STRING");
        public static string SECRETARY => GetValueFromInternalData("SECRETARY");
        public static string VENUE_NAME => GetValueFromInternalData("VENUE_NAME");
        public static string CLUB_NAME => GetValueFromInternalData("CLUB_NAME");
        public static string CHAIRMAN => GetValueFromInternalData("CHAIRMAN");
        public static string SHOWMANAGER => GetValueFromInternalData("SHOWMANAGER");
        public static string VETONCALL => GetValueFromInternalData("VETONCALL");
        public static string KUSA_REP => GetValueFromInternalData("KUSA_REP");
        public static string JUDGING_ORDER_BREED => GetValueFromInternalData("JUDGING_ORDER_BREED");
        public static string JUDGING_ORDER_GROUP => GetValueFromInternalData("JUDGING_ORDER_GROUP");
        public static string JUDGING_ORDER_SHOW => GetValueFromInternalData("JUDGING_ORDER_SHOW");
    }
}
