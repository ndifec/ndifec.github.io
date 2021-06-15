using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KRIntegration.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }
    }
}
