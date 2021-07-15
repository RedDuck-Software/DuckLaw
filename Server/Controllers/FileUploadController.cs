using Duck.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using Mammoth;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Duck.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {

        private readonly IWebHostEnvironment env;
        public FileUploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        [HttpPost]
        public void Post(UploadedFile uploadedFile)
        {
            var path = $"{env.WebRootPath}\\{uploadedFile.FileName}";
            var fs = System.IO.File.Create(path);
            fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            fs.Close();
            if (uploadedFile.FileName.EndsWith("pdf"))
            {
                PdfReader reader = new PdfReader(path);
                string text = string.Empty;
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                var ffs = System.IO.File.CreateText($"{env.WebRootPath}\\{"Test.txt"}");
                ffs.Write(text, 0, text.Length);
                ffs.Close();
            }
            if (uploadedFile.FileName.EndsWith("docx"))
            {
                var converter = new DocumentConverter();
                var resultt = converter.ConvertToHtml($"{env.WebRootPath}\\{uploadedFile.FileName}");
                var html = resultt.Value;
                var pathh = $"{env.WebRootPath}\\{"Test.html"}";

                using (FileStream fss = System.IO.File.Create(pathh))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(html);
                    fss.Write(info, 0, info.Length);

                }
                var warnings = resultt.Warnings;

            }
        }
    }
}
