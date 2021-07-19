using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Shared
{
    public class Render
    {
        [AliasAs("number")]
        public string Num { get; set; }/* = "509/4062/20";*/
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
