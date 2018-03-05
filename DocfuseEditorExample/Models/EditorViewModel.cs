using System.Web.Mvc;

namespace DocfuseEditorExample.Models
{
    public class EditorViewModel
    {
        [AllowHtml]
        public string Message { get; set; }
    }
}