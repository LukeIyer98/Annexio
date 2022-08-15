﻿using Newtonsoft.Json;

namespace AnnexioLuke.Models
{

    public class Currency
    {
   
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}