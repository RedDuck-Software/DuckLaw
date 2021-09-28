using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Duck.Server.Responses
{
    public class Item
    {
        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public class RootResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
