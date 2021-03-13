using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Shared
{
    public class Render
    {

        [JsonProperty("number")]
        public string Num { get; set; } /*= "509/4062/20";*/
        [JsonProperty("apiKey")]
        public string Key { get; set; } = "UyVcQj3XzGaN";
        [JsonProperty("judgment_code")]
        public int JudgmentCode { get; set; } /*= 3;*/
        [JsonProperty("justice_code")]
        public int JusticeCode { get; set; } /*= 2;*/
        [JsonProperty("stage")]
        public string Stage { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        public string Doc { get; set; }        

    }
}
