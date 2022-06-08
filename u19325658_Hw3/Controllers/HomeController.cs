using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19325658_Hw3.Models;

namespace u19325658_Hw3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string mediaUpload)
        {
            if (files != null && files.ContentLength > 0)
            {
                if(mediaUpload == "document")
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
                    files.SaveAs(path);
                }

                else if(mediaUpload == "image")
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
                    files.SaveAs(path);
                }

                else if(mediaUpload == "video")
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);
                    files.SaveAs(path);
                }
            }
            return RedirectToAction("Index");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        
    }
}