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

        [JsonProperty("blood_glucose_mgdl")]
        public Double blood_glucose_mgdl {get; set;}

        [JsonProperty("blood_glucose_mmol")]
        public Double blood_glucose_mmol {get; set;}

        [JsonProperty("before_meal")]
        public bool before_meal {get; set;}

        [JsonProperty("pulse_bpm")]
        public int pulse_bpm {get; set;}

        [JsonProperty("Rate")]
        public int Rate {get; set;}

        [JsonProperty("date_recorded")]
        public DateTime date_recorded {get; set;}

        [JsonProperty("systolic_mmhg")]
        public int systolic_mmhg {get; set;}

        [JsonProperty("diastolic_mmhg")]
        public int diastolic_mmhg { get; set; }

        [JsonProperty("battery")]
        public int battery {get; set;}

        [JsonProperty("time_zone_offset")]
        public Double time_zone_offset {get; set;}

        [JsonProperty("tare_kg")]
        public Double tare_kg {get; set;}

        [JsonProperty("weight_kg")]
        public Double weight_kg {get; set;}

        [JsonProperty("tare_lbs")]
        public Double tare_lbs {get; set;}

        [JsonProperty("weight_lbs")]
        public Double weight_lbs {get; set;}

        [JsonProperty("reading_type")]
        public string reading_type {get; set;}

        [JsonProperty("event_flag")]
        public string event_flag {get; set;}

        [JsonProperty("Weight")]
        public int Weight {get; set;}

        [JsonProperty("device_id")]
        public string device_id {get; set;}

    }
}