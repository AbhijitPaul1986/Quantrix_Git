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
    public class AboutUs : Pagination
    {
        public AboutUsModel Model = new AboutUsModel();
        AboutUsAction _aboutUsAction_BL = new AboutUsAction();
        public List<AboutUsModel> SectionList = new List<AboutUsModel>();
        public string SelectedPage { get; set; }
        public void GetSections(int? section_id, ResultObject result_object)
        {
            SectionList = _aboutUsAction_BL.GetSections(section_id, result_object);
        }

        public void Save(FormCollection form, string fileName, ResultObject result_object)
        {
            this.Model.section_id = Convert.ToInt32(form.GetValue("section_id").AttemptedValue);
            this.Model.section_details_id = Convert.ToInt32(form.GetValue("section_details_id").AttemptedValue);
            //if (form.GetValue("section_name") != null)
            //    this.Model.section_name = string.IsNullOrEmpty(form.GetValue("section_name").AttemptedValue) ? "" : form.GetValue("section_name").AttemptedValue;
            if (form.GetValue("section_notes") != null)
                this.Model.section_notes = string.IsNullOrEmpty(form.GetValue("section_notes").AttemptedValue) ? "" : form.GetValue("section_notes").AttemptedValue;
            this.Model.image_url = fileName;
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _aboutUsAction_BL.Save(this.Model, result_object);
        }

        public void Get(int? section_id, int? section_details_id, string searchText, int status, ResultObject result_object)
        {
            StringBuilder sb = new StringBuilder();
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            SectionList = _aboutUsAction_BL.Get(section_id, section_details_id, searchText, status, result_object);
            if (SectionList.Count > 0)
            {
                if (section_details_id == null)
                {
                    foreach (var item in SectionList)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        if (item.isactive == 0)
                        {
                            sb.Append("<a href='#' class='pr-3' data-section_details_id='" + item.section_details_id + "'  id='aactive' ><i class='fa fa-flash' aria-hidden='true' title='Activate'></i></a>");
                        }
                        else
                        {
                            sb.Append("<a href='#' class='pr-3' data-section_details_id='" + item.section_details_id + "'  id='aeditBanner' ><i class='fa fa-edit' aria-hidden='true' title='Edit'></i></a>");
                            sb.Append("<a href='#' class='pr-3' data-section_details_id='" + item.section_details_id + "'  id='aDeactive' ><i class='fa fa-flash' aria-hidden='true' title='Deactivate'></i></a>");
                        }

                        string url = "/images/notavailable.png";
                        if (Convert.ToString(item.image_url) != "")
                        {
                            url = "/images/" + item.image_url;
                        }
                        sb.Append("</td>");
                        sb.Append("<td>" + "<img id='user_img_grid' height='60' width='100' style='border:solid' src='" + url + "' />" + "</td>");
                        
                        sb.Append("<td>" + item.section_notes + "</td>");
                        sb.Append("</tr>");
                    }
                    result_object.recordHTML = Convert.ToString(sb);
                }
                else
                {
                    result_object.Records = new List<object>(SectionList);
                }
            }
        }

        public void ChangeStatus(int? section_details_id, int status, ResultObject result_object)
        {
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _aboutUsAction_BL.ChangeStatus(section_details_id, status, result_object);
        }
    }
}