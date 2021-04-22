using Duck.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Mammoth;
using System.IO;
using System.Text;

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
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            if (uploadedFile.FileName.EndsWith("pdf"))
            {
                f.OpenPdf($"{env.WebRootPath}\\{uploadedFile.FileName}");
                int result = f.ToHtml($"{env.WebRootPath}\\{"Test.html"}");
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
