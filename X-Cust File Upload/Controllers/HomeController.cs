using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X_Cust_File_Upload.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Homepage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUniqueIdentifier()
        {
            return Json(Guid.NewGuid().ToString());
        }

        [HttpPost]
        public ActionResult SingleFileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultipleFileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadSingleFile(HttpPostedFileBase paramFile, string paramId)
        {


            return View();
        }

        [HttpPost]
        public ActionResult TrackProgress(string paramId)
        {
            double paramCurrentFileSize = Convert.ToDouble(HttpContext.Cache[paramId + "_current"]);
            double paramTotalFileSize = Convert.ToDouble(HttpContext.Cache[paramId + "_total"]);
            int uploadProgress = Convert.ToInt32(paramCurrentFileSize * 100 / paramTotalFileSize);

            return Json(uploadProgress);

            return View();
        }
    }
}
