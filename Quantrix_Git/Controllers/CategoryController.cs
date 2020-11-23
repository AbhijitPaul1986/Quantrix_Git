using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
using Quantrix_Git.Models;
using ErrorLog;
using System.IO;
using System.Configuration;
using Quantrix_Git;

namespace Quantrix_Git.Controllers
{
    public class CategoryController : Controller
    {
        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Save(FormCollection form)
        {
            string fileName = "";
            ResultObject result_object = new ResultObject();
            Categoty category_object = new Categoty();
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    // get a stream
                    var stream = fileContent.InputStream;
                    // and optionally write the file to disk

                    var extension = Path.GetExtension(file);
                    fileName = Guid.NewGuid().ToString() + extension;//Path.GetFileName(file);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                }
            }
            category_object.Save(form, fileName, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Search(int? category_id, string searchText, int status)
        {
            ResultObject result_object = new ResultObject();
            Categoty category_object = new Categoty();
            category_object.Search(category_id, searchText, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }
    }
}