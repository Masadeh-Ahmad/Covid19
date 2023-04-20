using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Covid.Models
{
    public class Summary
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }
        public Country[] Countries { get; set; }
    }
    public class Global
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
    }

    public class Country
    {
        public string ID { get; set; }
        [JsonProperty("Country")]
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string Slug { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
        public Premium Premium { get; set; }
    }

    public class Premium
    {
    }

}
