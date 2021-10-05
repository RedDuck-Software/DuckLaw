using Newtonsoft.Json;

namespace Duck.Shared.Requests
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CourtSearchRequest
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
        
        [JsonProperty("judgment_code")]
        public int JudgmentCode { get; set; }
        
        [JsonProperty("justice_code")]
        public int JusticeCode { get; set; }
        
        [JsonProperty("court_code")]
        public int CourtCode { get; set; }
        
        [JsonProperty("company_code")]
        public string CompanyCode { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("stage")]
        public string Stage { get; set; }
        
        [JsonProperty("text_intro")]
        public string TextIntro { get; set; }
        
        [JsonProperty("text_resolution")]
        public string TextResolution { get; set; }
        
        [JsonProperty("offset")]
        public string Offset { get; set; }
        
        [JsonProperty("limit")]
        public string Limit { get; set; }
        
        [JsonProperty("date_from")]
        public string DateFrom { get; set; }
        
        [JsonProperty("date_to")]
        public string DateTo { get; set; }
        
        [JsonProperty("number")]
        public string Number { get; set; }
        
        [JsonProperty("search_criteria")]
        public string SearchCriteria { get; set; }
    }
}