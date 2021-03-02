using Duck.Shared;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class User : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Render>> CreateNewBlogPost(Render Request)
        {
            var request = RestService.For<Ireq>("https://opendatabot.com");
            var result = request.GetResult(new Render());
            var resultLink = result.Result.data.items[0].link;
            var pageContent = LoadPage(resultLink);
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);
            HtmlNodeCollection links = document.DocumentNode.SelectNodes(".//div/p");
            return Request;
            static string LoadPage(string url)
            {
                var result = "";
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    if (receiveStream != null)
                    {
                        StreamReader readStream;
                        if (response.CharacterSet == null)
                            readStream = new StreamReader(receiveStream);
                        else
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        result = readStream.ReadToEnd();
                        readStream.Close();
                    }
                    response.Close();
                }
                return result;
            }
        }

    }
}
