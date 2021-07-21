using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Shared
{
    public class ParsePage
    {
        [AliasAs("url")]
        public string Url { get; set; }
    }
}
