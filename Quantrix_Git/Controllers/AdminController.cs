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

namespace Quantrix.Controllers
{
    public class AdminController : Controller
    {
       [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
       public ActionResult Login(string username, string password)
        {
            ResultObject result_object = new ResultObject();
            Login Login_object = new Login();

            try
            {

                result_object = Login_object.GetLoginInfo(username, password);

                if (result_object.success == true)
                {
                    TempData["UserName"] = "Welcome " + result_object.UserName;
                    HttpContext.Session["UserID"] = result_object.UserID;
                    HttpContext.Session["UserName"] = TempData["UserName"];
                    HttpContext.Session["Name"] = result_object.Name;
                    HttpContext.Session["Email"] = result_object.email;
                    HttpContext.Session["admin"] = result_object.admin;
                }
                else
                {
                    HttpContext.Session["UserID"] = null;
                    HttpContext.Session["UserName"] = null;
                    HttpContext.Session["Name"] = null;
                    HttpContext.Session["Email"] = null;
                    HttpContext.Session["admin"] = null;                   
                }

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                Error.log(ex, (controllerName + "_" + actionName));
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
            }
            return Json(result_object);
        }

        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult BannerManagement()
        {
            ResultObject result_object = new ResultObject();
            Page Page_object = new Page();
            Page_object.GetPages(null, result_object);
            return View(Page_object);
        }

        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult GetPageDetails(int? page_id)
        {
            ResultObject result_object = new ResultObject();
            Page Page_object = new Page();
            Page_object.GetPages(page_id, result_object);
            return Json(Page_object, JsonRequestBehavior.AllowGet);
        }  
        
        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult SavePageDetails(FormCollection form)
        {
            string fileName = "";
            ResultObject result_object = new ResultObject();
            Page Page_object = new Page();
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    // get a stream
                    var stream = fileContent.InputStream;
                    // and optionally write the file to disk
                    
                    var extension = Path.GetExtension(file);
                    fileName = Guid.NewGuid().ToString()+extension;//Path.GetFileName(file);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                }
            }
            Page_object.SaveBanner(form,fileName, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult GetBanners(int? page_id,int? banner_id, string searchText, int status)
        {
            ResultObject result_object = new ResultObject();
            Page page_object = new Page();
            page_object.GetBanners(page_id,banner_id, searchText, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        } 
        
        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult ChangeBannerStatus(int? banner_id, int status)
        {
            ResultObject result_object = new ResultObject();
            Page page_object = new Page();
            page_object.ChangeStatus(banner_id, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }
  
         [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult HomePageContactManagement()
        {
            ResultObject result_object = new ResultObject();
            HomePageContact HomePageContact_object = new HomePageContact();
            HomePageContact_object.GetList(null, "",1, result_object);
            return View(HomePageContact_object);
        }    
         
        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
         public ActionResult HomePageFooterManagement()
        {
            ResultObject result_object = new ResultObject();
            HomePageFooter HomePageFooter_object = new HomePageFooter();
            HomePageFooter_object.GetList(null, "", 1, result_object);
            return View(HomePageFooter_object);
        } 
 
        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult HomePageContentManagement()
        {
            ResultObject result_object = new ResultObject();
            HomePageContent HomePagecontent_object = new HomePageContent();
            HomePagecontent_object.GetList(null, "", 1, result_object);
            return View(HomePagecontent_object);
            
        } 

        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult CategoryManagement()
        {
            ResultObject result_object = new ResultObject();
            Categoty Categoty_object = new Categoty();
            Categoty_object.GetList(null, "", 1, result_object);
            return View(Categoty_object);
        }




        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult AboutUsManagement()
        {
            ResultObject result_object = new ResultObject();
            AboutUs aboutUs_object = new AboutUs();
            aboutUs_object.GetSections(null, result_object);
            return View(aboutUs_object);
        }




        [HttpGet]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult ProductManagement()
        {
            return View();
        } 

        [HttpGet]
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["Name"] = null;
            Session["Email"] = null;
            return RedirectToAction("Index", "Admin");
        }
	}
}