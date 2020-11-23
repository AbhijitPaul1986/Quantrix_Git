using Business.Actions;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Utility;

namespace Quantrix_Git.Models
{
    public class HomePage
    {
        public HomePageContactModel _contact = new HomePageContactModel();
        public List<CategotyModel> CategoryList = new List<CategotyModel>();
        public List<HomePageContentModel> HomePageContentList = new List<HomePageContentModel>();
        public PageModel _page = new PageModel();
        public List<HomePageFooterModel> HomePageFooterList = new List<HomePageFooterModel>();
        HomePageContactAction _homePageContactAction_BL = new HomePageContactAction();
        CategoryAction _categoryActionAction_BL = new CategoryAction();
        HomePageContentAction _homePageContentAction_BL = new HomePageContentAction();
        PageAction _pageAction_BL = new PageAction();
        HomePageFooterAction _homePageFooterAction_BL = new HomePageFooterAction();
       
        public HomePage(ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _contact = _homePageContactAction_BL.GetList(null, "", 1, result_object).FirstOrDefault();
            CategoryList = _categoryActionAction_BL.GetList(null, "", 1, result_object);
            HomePageContentList = _homePageContentAction_BL.GetList(null, "", 1, result_object);
            _page = _pageAction_BL.GetBanners(1, null, "", 1, result_object).FirstOrDefault();
            HomePageFooterList = _homePageFooterAction_BL.GetList(null, "", 1, result_object);
        }
    }
}