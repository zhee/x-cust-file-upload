using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
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
        public ActionResult DoUploadSingleFile(HttpPostedFileBase berkas, string guid)
        {
            bool result = false;
            string filePath = Server.MapPath("~/Temporary/") + berkas.FileName;

            int fileLength = berkas.ContentLength;
            HttpContext.Cache[guid + "_total"] = fileLength;
            byte[] fileContent = new byte[fileLength];
            int bufferLength = 5 * 1024;
            byte[] buffer = new byte[bufferLength];
            int bytesRead = 0;

            FileStream outputFileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite); 
            using (Stream inputFileStream = berkas.InputStream)
            {
                while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputFileStream.Write(buffer, 0, bytesRead);
                    outputFileStream.Flush();

                    HttpContext.Cache[guid + "_current"] = Convert.ToInt32(HttpContext.Cache[guid + "_current"]) + bytesRead;
                    Debug.WriteLine(HttpContext.Cache[guid + "_current"].ToString());
                    Thread.Sleep(50);
                }

                inputFileStream.Close();
                inputFileStream.Dispose();
            }

            outputFileStream.Close();
            outputFileStream.Dispose();
            result = true;

            return Json(result);
        }

        [HttpPost]
        public ActionResult TrackProgress(string guid)
        {
            try
            {
                double paramCurrentFileSize = Convert.ToDouble(HttpContext.Cache[guid + "_current"]);
                double paramTotalFileSize = Convert.ToDouble(HttpContext.Cache[guid + "_total"]);
                int uploadProgress = Convert.ToInt32(paramCurrentFileSize * 100 / paramTotalFileSize);

                return Json(uploadProgress);
            }
            catch (Exception)
            {
                return Json(0);
            }
        }
    }
}
