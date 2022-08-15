using Newtonsoft.Json;

namespace AnnexioLuke.Models
{

    public class Flag
    {

        [JsonProperty("svg")]
        public string Svg { get; set; }

        [JsonProperty("png")]
        public string Png { get; set; }
    }
}
