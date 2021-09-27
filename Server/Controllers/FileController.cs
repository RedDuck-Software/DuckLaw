using Duck.Server.Services;
using Duck.Shared;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MockHttp;
using MockHttp.Json;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        public FileController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        [HttpPost]
        public async Task<ActionResult<OpenDataBotModel>> SaveDoc(OpenDataBotModel Request)
        {
            if (Request.Number == null)
            {
                return new ActionResult<OpenDataBotModel>(new OpenDataBotModel());
            }
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Verbose()
            .CreateLogger();
            MockHttpHandler mockHttp = new MockHttpHandler();
            mockHttp.When(matching => matching.Method("GET").RequestUri("https://opendatabot.com/*"))
                .RespondJson(HttpStatusCode.OK, new { status = "ok",
                    count = 1,
                    items = new[] { new { link = "https://opendatabot.ua/court/76195512-b22b9fbfbb31d6aca70b89d1257287a4" } } })
                .Verifiable();

            const string BaseUrl = "https://opendatabot.com";
            var service = new RootService(new Uri(BaseUrl), mockHttp);
            var results = await service.SearchAsync(Request);
            var pageContent = LoadPage(results.Items[0].Link);
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);
            string path = $"{env.WebRootPath}\\{"MockTest.html"}";
            CutAdvert(document, path);
            static void CutAdvert(HtmlDocument document, string path)
            {
                var removenode = document.DocumentNode.SelectNodes("//div[@class='jumbotron bg-light']");
                foreach (var item in removenode)
                {
                    item.RemoveAll();
                }
                HtmlNodeCollection links = document.DocumentNode.SelectNodes("//div[@class='container p-2 p-sm-3']");
                string str = default;
                foreach (HtmlNode html in links)
                {
                    str += html.InnerHtml;
                }
                using (FileStream fs = System.IO.File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(str);
                    fs.Write(info, 0, info.Length);
                }
            }
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
        [HttpGet]
        public string GetDoc(string url)
        {
            return System.IO.File.ReadAllText(($"{env.WebRootPath}\\{"Ita.html"}"));
        }
        [HttpPost("saveComment")]
        public async Task<bool> SaveUserComment(ParsePage request)
        {
            string path = $"{env.WebRootPath}\\{"Test.html"}";
            byte[] url = new UTF8Encoding(true).GetBytes(request.Url);
            using (FileStream fs = System.IO.File.Create(path))
            {
                fs.Write(url, 0, url.Length);
            }
            return true;
        }

    }
}
