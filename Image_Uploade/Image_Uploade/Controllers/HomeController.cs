using Image_Uploade.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Image_Uploade.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
     private VIVEKEntities db = new VIVEKEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveImage(string name,HttpPostedFileBase File)  
        {
            if (File != null && File.ContentLength>0) 
                {
                string filename=File.FileName;

                var extension=Path.GetExtension(filename);

                if (extension == ".jpg" || extension == ".png")
                {
                    var minImgSize = 8 * 1024 * 1024;
                    if (minImgSize >= File.ContentLength)
                    {
                        var folderPath = Server.MapPath("~/Content/UserImg/");
                        var filePath = folderPath + File.FileName;
                        var demoPath = Path.Combine(folderPath, filePath);
                        File.SaveAs(demoPath);
                       
                         DBImg dBImg = new DBImg();
                        //String result = dBImg.ImgInsert(name, filename); //file name only database send
                        String result = dBImg.ImgInsert(name, filePath);
                        ViewBag.Messege=result;
                        ViewBag.ImgName = filename;

                    }
                    else
                    {
                        ViewBag.errormsg = "Please Upload min 5 mb Image";
                    }
                }
                else
                {
                    ViewBag.errormsg = "please upload jpg or png image";
                 }
            }
            return View("Index");
        }
    }
}