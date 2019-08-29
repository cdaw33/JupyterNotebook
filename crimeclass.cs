using Newtonsoft.Json;

namespace webAppNotebook
{
    public class crimeclass
    {
        public class totalCrimeYear
        {
            [JsonProperty("Crime ")]
            public string crime { get; set; }
            [JsonProperty("Count ")]
            public int count { get; set; }
        }
        public class crimebyYear
        {
            [JsonProperty("Year ")]
            public int Year { get; set; }
            [JsonProperty("Count ")]
            public int count { get; set; }
        }
        public class crimesbyDistrict
        {
            [JsonProperty("District ")]
            public int district { get; set; }
            [JsonProperty("Count ")]
            public int count { get; set; }
        }
    }
}