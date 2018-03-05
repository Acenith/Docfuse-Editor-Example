using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Words;
using Aspose.Words.Saving;
using System.Web;
using System.Web.Mvc;
using DocfuseEditorExample.Models;

namespace DocfuseEditorExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            byte[] file = System.IO.File.ReadAllBytes(@"C:\Users\z6lnb\Desktop\docEx.docx");
            Stream stream = new MemoryStream(file);
            var doc = new Document(stream);

            // Options
            var options = new HtmlSaveOptions
            {
                ExportRoundtripInformation = true,
                ExportImagesAsBase64 = true
            };

            var memoryStream = new MemoryStream();
            doc.Save(memoryStream, options);

            var htmlMessage = Encoding.UTF8.GetString(memoryStream.ToArray());

            var vm = new EditorViewModel
            {
                Message = htmlMessage
            };

            return View(vm);
        }

        [HttpPost]
        public void SaveDocument(EditorViewModel editor)
        {
            var lol = editor;
        }
    }
}