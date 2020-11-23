using Quantrix_Git;
using Quantrix_Git.Models;
using System.Web.Mvc;
using Utility;

namespace Quantrix.Controllers
{
    public class HomePageFooterController : Controller
    {
        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Save(int hdnAddressID, string footer_text, string footer_sub_text,string client_name, string copywriter)
        {
            ResultObject result_object = new ResultObject();
            HomePageFooter HomePageFooter_object = new HomePageFooter();
            HomePageFooter_object.Save(hdnAddressID, footer_text, footer_sub_text, client_name, copywriter, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Search(int? home_page_footer_id, string searchText, int status)
        {
            ResultObject result_object = new ResultObject();
            HomePageFooter HomePageFooter_object = new HomePageFooter();
            HomePageFooter_object.Search(home_page_footer_id, searchText, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult ChangeStatus(int? home_page_footer_id, int status)
        {
            ResultObject result_object = new ResultObject();
            HomePageFooter HomePageFooter_object = new HomePageFooter();
            HomePageFooter_object.ChangeStatus(home_page_footer_id, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }   
        
	}
}