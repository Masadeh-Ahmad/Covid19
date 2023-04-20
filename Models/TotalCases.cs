using Newtonsoft.Json;

namespace Covid.Models
{
    public class TotalCases
    {
        public int TotalConfirmed { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecovered { get; set; }
    }
}