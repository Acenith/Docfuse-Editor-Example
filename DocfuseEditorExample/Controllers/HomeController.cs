using System;
using System.IO;
using System.Reflection;
using System.Text;
using Aspose.Words;
using Aspose.Words.Saving;
using System.Web.Mvc;
using DocfuseEditorExample.Models;

namespace DocfuseEditorExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)?.Substring(6);
            byte[] file = System.IO.File.ReadAllBytes($@"{path}\Documents\example.docx");
            //byte[] file = System.IO.File.ReadAllBytes($@"{path}\Documents\Cabi 010786 3.91 Informationsmøde (med advarsel).docx");
            //byte[] file = System.IO.File.ReadAllBytes($@"{path}\Documents\Cabi 010877 1.1 Jobsamtale.docx");
            //byte[] file = System.IO.File.ReadAllBytes($@"{path}\Documents\Cabi 010877 1.44 Indkaldelse vedr. aktivering.docx");

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
        public JsonResult SaveDocument(EditorViewModel editor)
        {
            try
            {
                string html = editor.Message;
                byte[] bytes = Encoding.UTF8.GetBytes(html);
                Stream stream = new MemoryStream(bytes);

                var doc = new Document(stream);
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)?.Substring(6);
                doc.Save($@"{path}\Documents\docxFromHtml.docx");

                return new JsonResult { Data = new { success = true, message = "Dokumentet er gemt" } };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new { success = false, message = e.Message } };
            }
        }
    }
}