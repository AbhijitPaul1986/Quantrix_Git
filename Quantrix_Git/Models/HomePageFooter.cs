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
    public class HomePageFooter : Pagination
    {
        public HomePageFooterModel Model = new HomePageFooterModel();
        HomePageFooterAction _homePageFooterAction_BL = new HomePageFooterAction();
        public List<HomePageFooterModel> HomePageFooterList = new List<HomePageFooterModel>();

        public HomePageFooter GetList(int? home_page_footer_id, string search_text, int? status, ResultObject result_object)
        {
            HomePageFooterList = _homePageFooterAction_BL.GetList(home_page_footer_id, search_text, status, result_object);
            return this;
        }


        public void Save(int hdnAddressID, string footer_text, string footer_sub_text, string client_name,string copywriter, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _homePageFooterAction_BL.Save(hdnAddressID, footer_text, footer_sub_text, client_name, copywriter, result_object);
        }

        public void ChangeStatus(int? home_page_footer_id, int status, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _homePageFooterAction_BL.ChangeStatus(home_page_footer_id, status, result_object);
        }

        public void Search(int? home_page_footer_id, string search_text, int? status, ResultObject result_object)
        {
            StringBuilder sb = new StringBuilder();

            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            HomePageFooterList = _homePageFooterAction_BL.GetList(home_page_footer_id, search_text, status, result_object);
            if (HomePageFooterList.Count > 0)
            {
                if (home_page_footer_id == null)
                {
                    foreach (var item in HomePageFooterList)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td>");
                        if (item.isactive == 0)
                        {

                            sb.Append("<a href='#' class='pr-3' data-home_page_footer_id='" + item.home_page_footer_id + "'  id='aactive' ><i class='fa fa-flash' aria-hidden='true' title='Activate'></i></a>");

                        }
                        else
                        {
                            sb.Append("<a href='#' class='pr-3' data-home_page_footer_id='" + item.home_page_footer_id + "'  id='aedit' ><i class='fa fa-edit' aria-hidden='true' title='Edit'></i></a>");
                            sb.Append("<a href='#' class='pr-3' data-home_page_footer_id='" + item.home_page_footer_id + "'  id='aDeactive' ><i class='fa fa-flash' aria-hidden='true' title='Deactivate'></i></a>");

                        }


                        sb.Append("</td>");
                        sb.Append("<td>" + item.footer_text + "</td>");
                        sb.Append("<td>" + item.footer_sub_text + "</td>");
                        sb.Append("<td>" + item.client_name + "</td>");
                        sb.Append("<td>" + item.copywriter + "</td>");

                        sb.Append("</tr>");
                    }
                    result_object.recordHTML = Convert.ToString(sb);
                }
                else
                {
                    result_object.Records = new List<object>(HomePageFooterList);
                }
            }
        }
    }
}