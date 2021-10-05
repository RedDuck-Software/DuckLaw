using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duck.Shared.Response
{
    public class CourtSearchResultsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<CourtCase> Items { get; set; }
    }
    
    public class CourtCase
    {
        [JsonProperty("doc_id")]
        public int DocId { get; set; }

        [JsonProperty("court_code")]
        public int CourtCode { get; set; }

        [JsonProperty("court_name")]
        public string CourtName { get; set; }

        [JsonProperty("judgment_code")]
        public int JudgmentCode { get; set; }

        [JsonProperty("judgment_name")]
        public string JudgmentName { get; set; }

        [JsonProperty("justice_code")]
        public int JusticeCode { get; set; }

        [JsonProperty("justice_name")]
        public string JusticeName { get; set; }

        [JsonProperty("category_code")]
        public int CategoryCode { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("cause_number")]
        public string CauseNumber { get; set; }

        [JsonProperty("adjudication_date")]
        public string AdjudicationDate { get; set; }

        [JsonProperty("date_publ")]
        public string DatePubl { get; set; }

        [JsonProperty("receipt_date")]
        public string ReceiptDate { get; set; }

        [JsonProperty("judge")]
        public string Judge { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}