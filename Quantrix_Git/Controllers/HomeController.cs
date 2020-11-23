using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quantrix_Git.Models;
using Utility;

namespace Quantrix.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ResultObject result_object = new ResultObject();
            HomePage homePage_object = new HomePage(result_object);
            return View(homePage_object);
        }   
        public ActionResult AboutUs()
        {
            ResultObject result_object = new ResultObject();
            AboutUsPage aboutUsPage_object = new AboutUsPage(result_object);
            return View(aboutUsPage_object);
        }
	}
}