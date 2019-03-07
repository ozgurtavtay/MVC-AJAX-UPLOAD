using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult FileUpload(HttpPostedFileBase file)
        {

            if (file!=null)
            {
                if (Directory.Exists(Server.MapPath("~/Files")) ==false )
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files"));
                    file.SaveAs(Path.Combine(Server.MapPath("~/Files"),file.FileName));
                    return Json(new { hasError = false, message = "Dosya yüklendi" });
                }
            }
            return Json(new { hasError = true, message = "Dosya NullB" });
        }
    }
}