using Duck.Server.Model;
using Duck.Server.Services;
using Duck.Shared;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Refit;
using Serilog;
using System;
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
        private readonly IWebHostEnvironment env;
        [HttpPost]
        public async Task<ActionResult<Render>> CreateNewBlogPost(Render Request)
        {
            if (Request.Num == null)
            {
                return new ActionResult<Render>(new Render()) ;
            }

                Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();
                const string BaseUrl = "https://opendatabot.com";
                var service = new RootService(new Uri(BaseUrl));
                var results = await service.SearchAsync(Request);
                var resultLink = results.data.items.Last().link;
                var pageContent = LoadPage(resultLink);
                var document = new HtmlDocument();
                document.LoadHtml(pageContent);
                FileStream sw = new FileStream($"kk", FileMode.Create);
                document.Save(sw);
                //HtmlNodeCollection links = document.DocumentNode.SelectNodes(".//div/p");
                //foreach (HtmlNode html in links)
                //{
                //    string path = @"E:\MyTest.html";
                //    using (FileStream fs = System.IO.File.Create(path))
                //    {
                //        byte[] info = new UTF8Encoding(true).GetBytes(html.InnerHtml);
                //        fs.Write(info, 0, info.Length);
                //    }
                //}
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
