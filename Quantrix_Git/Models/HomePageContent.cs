using Business.Actions;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Utility;

namespace Quantrix_Git.Models
{
    public class HomePageContent : Pagination
    {
        public HomePageContentModel Model = new HomePageContentModel();
        HomePageContentAction _homePageContentAction_BL = new HomePageContentAction();
        public List<HomePageContentModel> HomePageContentList = new List<HomePageContentModel>();

        public HomePageContent GetList(int? home_page_Content_id, string search_text, int? status, ResultObject result_object)
        {
            HomePageContentList = _homePageContentAction_BL.GetList(home_page_Content_id, search_text, status, result_object);
            return this;
        }


        public void Save(int hdnAddressID, string Content_text,  ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _homePageContentAction_BL.Save(hdnAddressID, Content_text, result_object);
        }

        public void ChangeStatus(int? home_page_Content_id, int status, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _homePageContentAction_BL.ChangeStatus(home_page_Content_id, status, result_object);
        }

        public void Search(int? home_page_Content_id, string search_text, int? status, ResultObject result_object)
        {
            StringBuilder sb = new StringBuilder();

            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            HomePageContentList = _homePageContentAction_BL.GetList(home_page_Content_id, search_text, status, result_object);
            if (HomePageContentList.Count > 0)
            {
                if (home_page_Content_id == null)
                {
                    foreach (var item in HomePageContentList)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td>");
                        if (item.isactive == 0)
                        {

                            //sb.Append("<a href='#' class='pr-3' data-home_page_Content_id='" + item.home_page_content_id + "'  id='aactive' ><i class='fa fa-flash' aria-hidden='true' title='Activate'></i></a>");

                        }
                        else
                        {
                            sb.Append("<a href='#' class='pr-3' data-home_page_content_id='" + item.home_page_content_id + "'  id='aedit' ><i class='fa fa-edit' aria-hidden='true' title='Edit'></i></a>");
                            //sb.Append("<a href='#' class='pr-3' data-home_page_content_id='" + item.home_page_content_id + "'  id='aDeactive' ><i class='fa fa-flash' aria-hidden='true' title='Deactivate'></i></a>");

                        }


                        sb.Append("</td>");
                        sb.Append("<td>" + item.content_name + "</td>");
                        sb.Append("<td>" + item.content_text + "</td>");
                       
                        sb.Append("</tr>");
                    }
                    result_object.recordHTML = Convert.ToString(sb);
                }
                else
                {
                    result_object.Records = new List<object>(HomePageContentList);
                }
            }
        }
    }
}