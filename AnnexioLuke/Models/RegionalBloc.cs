using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnnexioLuke.Models
{

    public class RegionalBloc
    {

        [JsonProperty("acronym")]
        public string Acronym { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("otherAcronyms")]
        public IList<object> OtherAcronyms { get; set; }


        [JsonProperty("otherNames")]
        public IList<string> OtherNames { get; set; }
    }
}