
using Quantrix_Git.Models;
using Quantrix_Git;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Quantrix.Controllers
{
    public class HomePageContactController : Controller
    {
        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Save(int hdnAddressID,string address, string email, string phone)
        {
            ResultObject result_object = new ResultObject();
            HomePageContact HomePageContact_object = new HomePageContact();
            HomePageContact_object.Save(hdnAddressID,address, email, phone, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Search(int? home_page_contact_id, string searchText, int status)
        {
            ResultObject result_object = new ResultObject();
            HomePageContact HomePageContact_object = new HomePageContact();
            HomePageContact_object.Search(home_page_contact_id, searchText, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }   

         [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult ChangeStatus(int? home_page_contact_id, int status)
        {
            ResultObject result_object = new ResultObject();
            HomePageContact HomePageContact_object = new HomePageContact();
            HomePageContact_object.ChangeStatus(home_page_contact_id, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }   
        
	}
}