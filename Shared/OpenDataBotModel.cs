using Duck.Shared.Attributes;
using Refit;
using System;
using System.Collections.Generic;

namespace Duck.Shared
{
    public class OpenDataBotModel
    {
        [AliasAs("judgment_code")]
        public int JudgmentCode { get; set; }

        [AliasAs("justice_code")]
        public int JusticeCode { get; set; }

        [AliasAs("court_code")]
        public string CourtCode { get; set; }

        [AliasAs("company_code")]
        public string CompanyCode { get; set; }

        [AliasAs("text")]
        public string Text { get; set; }

        [AliasAs("stage")]
        public string Stage { get; set; }

        [AliasAs("text_intro")]
        public string TextIntro { get; set; }

        [AliasAs("text_resolution")]
        public string TextResolution { get; set; }

        [AliasAs("offset")]
        public string Offset { get; set; }

        [AliasAs("limit")]
        public string Limit { get; set; }

        [AliasAs("date_from")]
        [DateRange]
        public DateTime? DateFrom { get; set; } = null;

        [AliasAs("date_to")]
        [DateRange]
        public DateTime? DateTo { get; set; } = null;

        [AliasAs("number")]
        public string Number { get; set; } /* = "509/4062/20";*/

        public List<(string Name, int Value)> JudgmentCodes = new()
        {
            ("Цивільне", 1),
            ("Кримінальне", 2),
            ("Господарське", 3),
            ("Адміністративне", 4),
            ("Адмінправопорушення", 5)
        };

        public List<(string Name, int Value)> JusticeCodes = new()
        {
            ("Вирок", 1),
            ("Постанова", 2),
            ("Рішення", 3),
            ("Судовий наказ", 4),
            ("Ухвала", 5),
            ("Окрема ухвала", 6),
            ("Окрема думка", 10),
        };

        public List<(string Name, string Value)> Stages = new()
        {
            ("Перша", "first"),
            ("Апеляційна", "appeal"),
            ("Касаційна", "cassation")
        };
    }

    ////https://stackoverflow.com/questions/17380900/enum-localization
    //public enum JudgmentCodes
    //{
    //    [Display(Name = "Цивільне")]
    //    Spring = 1,
    //    [Display(Name = "Кримінальне")]
    //    Summer = 2,
    //    [Display(Name = "Господарське")]
    //    Autumn = 3 ,
    //    [Display(Name = "Адміністративне")]
    //    Winter = 4,
    //}
}
