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
    public class AboutUsPage
    {
        public PageModel _page = new PageModel();
        PageAction _pageAction_BL = new PageAction();
        public List<AboutUsModel> SectionList = new List<AboutUsModel>();
        AboutUsAction _aboutUsAction_BL = new AboutUsAction();
        public AboutUsPage(ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

            _page = _pageAction_BL.GetBanners(2, null, "", 1, result_object).FirstOrDefault();
            SectionList = _aboutUsAction_BL.Get(null, null, "", 1, result_object);
        }
    }
}