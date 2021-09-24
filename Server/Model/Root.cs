using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Refit;

namespace Duck.Server.Model
{
    public class Root
    {
        [AliasAs("number")]
        public string Num { get; set; } = "509/4062/20";
        [AliasAs("judgment_code")]
        public int JudgmentCode { get; set; } = 3;
        [AliasAs("justice_code")]
        public int JusticeCode { get; set; } = 2;
        [AliasAs("stage")]
        public string Stage { get; set; }
        [AliasAs("text")]
        public string Text { get; set; }
    }
}
