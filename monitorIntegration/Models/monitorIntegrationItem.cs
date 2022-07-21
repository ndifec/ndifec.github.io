using System;
using Newtonsoft.Json;

namespace monitorIntegration.Models
{
    [JsonObject]
    public class monitorInformationItem
    {
        public long id {get; set;}

        [JsonProperty("reading_id")]
        public long reading_id {get; set;}

        [JsonProperty("irregular")]
        public bool irregular {get; set;}

        [JsonProperty("device_model")]
        public string device_model {get; set;}

        [JsonProperty("date_received")]
        public DateTime date_received {get; set;}

        [JsonProperty("pulse_bpm")]
        public int pulse_bpm {get; set;}

        [JsonProperty("date_recorded")]
        public DateTime date_recorded {get; set;}

        [JsonProperty("systolic_mmhg")]
        public int systolic_mmhg {get; set;}

        [JsonProperty("diastolic_mmhg")]
        public int diastolic_mmhg { get; set; }

        [JsonProperty("time_zone_offset")]
        public Double time_zone_offset {get; set;}

        [JsonProperty("reading_type")]
        public string reading_type {get; set;}

        [JsonProperty("device_id")]
        public string device_id {get; set;}

        [JsonProperty("short_code")]
        public string short_code { get; set; }

    }
}