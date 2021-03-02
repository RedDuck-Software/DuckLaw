using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duck.Server.Controllers
{
    public class Model
    {
        public class Root
        {
            [JsonProperty("status")]
            public string status { get; set; }
            [JsonProperty("data")]
            public Data data { get; set; }
        }
        public class Data
        {
            [JsonProperty("count")]
            public int count { get; set; }
            [JsonProperty("items")]
            public List<Item> items { get; set; }
        }
        public class Item
        {
            [JsonProperty("link")]
            public string link { get; set; }
        }
    }
}
