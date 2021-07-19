using Refit;

namespace Duck.Shared
{
    public class ParsePage
    {
        [AliasAs("Url")]
        public string Url { get; set; }
    }
}
