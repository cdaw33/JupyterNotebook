using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net;

namespace webAppNotebook
{
    public class crimeAmount
    {
        static string getURL(string type)
        {
            //Creates a web request to maake requests to Juyter
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8889/total_crime/" + type);
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            string jsonString;
            //Returns the response as a stream
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            //trims the string so that it is purely JSON
            string jsonnow = jsonString.Replace(@"\", " ");
            string jsonText = jsonnow.Substring(1, jsonString.Length - 3);
            //returns the trimmed JSON
            return jsonText;            
        }
        public static List<crimeclass.totalCrimeYear> GetCrimeCount(string year)
        {
            if (year == "Total")
                year = "total";
            //Deserializes the JSON using the class as a format
            List<crimeclass.totalCrimeYear> crime = JsonConvert.DeserializeObject<List<crimeclass.totalCrimeYear>>(getURL(year));
            return crime;
        }
        static List<crimeclass.crimebyYear> getList(string json)
        {
            List<crimeclass.crimebyYear> crime = JsonConvert.DeserializeObject<List<crimeclass.crimebyYear>>(getURL(json));
            return crime;
        }
        public static List<crimeclass.crimebyYear> assaultChart()
        {
            string type = "assault";
            return getList(type);
                        
        }
        public static List<crimeclass.crimebyYear> theftChart()
        {
            string type = "theft";
            return getList(type);
        }
        public static List<crimeclass.crimebyYear> narcoticsChart()
        {
            string type = "narcotics";
            return getList(type);
        }
        public static List<crimeclass.crimesbyDistrict> districtChart()
        {
            string type = "district";            
            List<crimeclass.crimesbyDistrict> district = JsonConvert.DeserializeObject<List<crimeclass.crimesbyDistrict>>(getURL(type));            
            return district;
        }
        public static bool validate(string input)
        {
            if (input == "2015" || input == "2016" || input == "2017" || input == "2018" || input == "2019" || input == "total" || input == "Total")
            {
                return true;
            }
            else
                return false;
        }
    }
}