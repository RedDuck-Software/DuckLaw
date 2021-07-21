using Duck.Server.Services;
using Duck.Shared;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    public class User : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        public User(IWebHostEnvironment env)
        {
            this.env = env;
        }
        [HttpPost]
        public async Task<ActionResult<Render>> SaveDoc(Render Request)
        {
            if (Request.Num == null)
            {
                return new ActionResult<Render>(new Render());
            }
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Verbose()
            .CreateLogger();
            const string BaseUrl = "https://opendatabot.com";
            var service = new RootService(new Uri(BaseUrl));
            //var pageContent = LoadPage("https://opendatabot.com/court/76195512-b22b9fbfbb31d6aca70b89d1257287a4");
            var document = new HtmlDocument();
            document.LoadHtml($"{env.WebRootPath}\\{"Test.html"}");
            var removenode = document.DocumentNode.SelectNodes("//div[@class='jumbotron bg-light']");
            foreach (var item in removenode)
            {
                item.RemoveAll();
            }
            HtmlNodeCollection links = document.DocumentNode.SelectNodes("//div[@class='container p-2 p-sm-3']");
            string strr = default;
            foreach (HtmlNode html in links)
            {
                strr += html.InnerHtml;
            }
            string path = $"{env.WebRootPath}\\{"Test.html"}";
            using (FileStream fs = System.IO.File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(strr);
                fs.Write(info, 0, info.Length);
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
            var text = System.IO.File.ReadAllText(($"{env.WebRootPath}\\{"Ita.html"}"));
            return text;
        }
        [HttpPost("parse")]
        public async Task<string> Test(ParsePage request)
        {
            string path = $"{env.WebRootPath}\\{"Test.html"}";
           await using (FileStream fs = System.IO.File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(request.Url);
                fs.Write(info, 0, info.Length);
            }
            return " ";
        }
    }
}
