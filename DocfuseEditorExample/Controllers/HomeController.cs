using System;
using System.IO;
using System.Reflection;
using System.Text;
using Aspose.Words;
using Aspose.Words.Saving;
using System.Web.Mvc;
using DocfuseEditorExample.Constants;
using DocfuseEditorExample.Models;

namespace DocfuseEditorExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)?.Substring(6);
            byte[] file = System.IO.File.ReadAllBytes($@"{path}\Documents\{Word.Example}");

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
                doc.Save($@"{path}\Documents\{Word.DocxFromHtml}");

                return new JsonResult { Data = new { success = true, message = "Dokumentet er gemt" } };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new { success = false, message = e.Message } };
            }
        }
    }
}