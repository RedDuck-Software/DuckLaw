using Duck.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using Mammoth;
using System.IO;
using System.Text;
using Spire.Pdf;
using System.Drawing;
using Spire.Pdf.Graphics;

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
                PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(path);
                PdfDocument newPdf = new PdfDocument();
                foreach (PdfPageBase page in pdf.Pages)
                {
                    PdfPageBase newPage = newPdf.Pages.Add(PdfPageSize.A4, new PdfMargins(0));
                    PdfTextLayout loLayout = new PdfTextLayout();
                    loLayout.Layout = PdfLayoutType.OnePage;
                    page.CreateTemplate().Draw(newPage, new PointF(0, 0), loLayout);
                }
                newPdf.SaveToFile($"{env.WebRootPath}\\{"Test.html"}", FileFormat.HTML);
            }
            if (uploadedFile.FileName.EndsWith("docx"))
            {
                var converter = new DocumentConverter();
                var resultt = converter.ConvertToHtml($"{env.WebRootPath}\\{uploadedFile.FileName}");
                var html = resultt.Value;
                var pathh = $"{env.WebRootPath}\\{"Test.html"}";
                using (FileStream fss = System.IO.File.Create(pathh))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(html);
                    fss.Write(info, 0, info.Length);
                }
            }
            byte[] origin = System.IO.File.ReadAllBytes($"{env.WebRootPath}\\{"Test.html"}");
            var compressed = GetMockCompressedData(origin);
            var fileS = System.IO.File.Create($"{env.WebRootPath}\\{"Compressed.html"}");
            fileS.Write(compressed, 0,compressed.Length);
            fileS.Close();
        }
        private byte[] GetMockCompressedData(byte[]doc)
        {
            return doc;
        }
    }
}
