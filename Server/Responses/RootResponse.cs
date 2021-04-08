using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Duck.Server.Responses
{
    public class RootResponse
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
