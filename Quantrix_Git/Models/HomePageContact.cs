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
    public class HomePageContact : Pagination
    {
        public HomePageContactModel Model = new HomePageContactModel();
        HomePageContactAction _homePageContactAction_BL = new HomePageContactAction();
        public List<HomePageContactModel> HomePageContactList = new List<HomePageContactModel>();

        public HomePageContact GetList(int? home_page_contact_id, string search_text, int? status, ResultObject result_object)
        {
            HomePageContactList = _homePageContactAction_BL.GetList(home_page_contact_id, search_text, status, result_object);
            return this;
        }


        public void Save(int hdnAddressID, string address, string email, string phone, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _homePageContactAction_BL.Save(hdnAddressID, address, email, phone, result_object);
        }

        public void ChangeStatus(int? home_page_contact_id, int status, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _homePageContactAction_BL.ChangeStatus(home_page_contact_id, status, result_object);
        }

        public void Search(int? home_page_contact_id, string search_text, int? status, ResultObject result_object)
        {
            StringBuilder sb = new StringBuilder();

            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            HomePageContactList = _homePageContactAction_BL.GetList(home_page_contact_id, search_text, status, result_object);
            if (HomePageContactList.Count > 0)
            {
                if (home_page_contact_id == null)
                {
                    foreach (var item in HomePageContactList)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td>");
                        if (item.isactive == 0)
                        {

                            sb.Append("<a href='#' class='pr-3' data-home_page_contact_id='" + item.home_page_contact_id + "'  id='aactive' ><i class='fa fa-flash' aria-hidden='true' title='Activate'></i></a>");

                        }
                        else
                        {
                            sb.Append("<a href='#' class='pr-3' data-home_page_contact_id='" + item.home_page_contact_id + "'  id='aedit' ><i class='fa fa-edit' aria-hidden='true' title='Edit'></i></a>");
                            sb.Append("<a href='#' class='pr-3' data-home_page_contact_id='" + item.home_page_contact_id + "'  id='aDeactive' ><i class='fa fa-flash' aria-hidden='true' title='Deactivate'></i></a>");

                        }


                        sb.Append("</td>");
                        sb.Append("<td>" + item.address + "</td>");
                        sb.Append("<td>" + item.email + "</td>");
                        sb.Append("<td>" + item.phone + "</td>");

                        sb.Append("</tr>");
                    }
                    result_object.recordHTML = Convert.ToString(sb);
                }
                else
                {
                    result_object.Records = new List<object>(HomePageContactList);
                }
            }
        }
    }
}