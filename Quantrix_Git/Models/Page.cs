using Business.Actions;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Quantrix_Git.Models
{
    public class Page : Pagination
    {
        public PageModel Model = new PageModel();
        PageAction _pageAction_BL = new PageAction();
        public List<PageModel> PageList = new List<PageModel>();
        public string SelectedPage { get; set; }
        public void GetPages(int? page_id, ResultObject result_object)
        {
            PageList = _pageAction_BL.GetPages(page_id, result_object);
        }

        public void SaveBanner(FormCollection form,string fileName, ResultObject result_object)
        {
            this.Model.page_id = Convert.ToInt32(form.GetValue("page_id").AttemptedValue);
            this.Model.banner_id = Convert.ToInt32(form.GetValue("banner_id").AttemptedValue);
            if (form.GetValue("header_text") != null)
                this.Model.headertext = string.IsNullOrEmpty(form.GetValue("header_text").AttemptedValue) ? "" : form.GetValue("header_text").AttemptedValue;
            if (form.GetValue("sub_text") != null)
                this.Model.subtext = string.IsNullOrEmpty(form.GetValue("sub_text").AttemptedValue) ? "" : form.GetValue("sub_text").AttemptedValue;
            this.Model.image_url = fileName;
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _pageAction_BL.SaveBanner(this.Model, result_object);
        }

        public void GetBanners(int? page_id,int? banner_id, string searchText, int status, ResultObject result_object)
        {
            StringBuilder sb = new StringBuilder();

            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            PageList = _pageAction_BL.GetBanners(page_id, banner_id, searchText, status, result_object);
            if (PageList.Count > 0)
            {
                if (banner_id == null)
                {
                    foreach (var item in PageList)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td>");
                        if (item.isactive == 0)
                        {

                            sb.Append("<a href='#' class='pr-3' data-banner_id='" + item.banner_id + "'  id='aactive' ><i class='fa fa-flash' aria-hidden='true' title='Activate'></i></a>");

                        }
                        else
                        {
                            sb.Append("<a href='#' class='pr-3' data-banner_id='" + item.banner_id + "'  id='aeditBanner' ><i class='fa fa-edit' aria-hidden='true' title='Edit'></i></a>");
                            sb.Append("<a href='#' class='pr-3' data-banner_id='" + item.banner_id + "'  id='aDeactive' ><i class='fa fa-flash' aria-hidden='true' title='Deactivate'></i></a>");

                        }

                        string url="/images/notavailable.png";
                        if(Convert.ToString(item.image_url)!="")
                        {
                            url="/images/"+item.image_url;
                        }

                        sb.Append("</td>");
                        sb.Append("<td>" + "<img id='user_img_grid' height='60' width='100' style='border:solid' src='" + url + "' />" + "</td>"); 
                        sb.Append("<td>" + item.headertext + "</td>");
                        sb.Append("<td>" + item.subtext + "</td>");

                        sb.Append("</tr>");
                    }
                    result_object.recordHTML = Convert.ToString(sb);
                }
                else
                {
                    result_object.Records = new List<object>(PageList);
                }
            }
        }

        public void ChangeStatus(int? banner_id, int status, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _pageAction_BL.ChangeStatus(banner_id, status, result_object);
        }
    }
}