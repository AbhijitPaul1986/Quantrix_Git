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
    public class Categoty : Pagination
    {
        public CategotyModel Model = new CategotyModel();
        CategoryAction _categoryActionAction_BL = new CategoryAction();
        public List<CategotyModel> CategoryList = new List<CategotyModel>();

        public Categoty GetList(int? category_id, string search_text, int status, ResultObject result_object)
        {
            this.CategoryList = _categoryActionAction_BL.GetList(category_id, search_text, status, result_object);
            return this;
        }


        public void Save(FormCollection form, string fileName, ResultObject result_object)
        {
            this.Model.category_id = Convert.ToInt32(form.GetValue("category_id").AttemptedValue);
            if (form.GetValue("category_name") != null)
                this.Model.category_name = string.IsNullOrEmpty(form.GetValue("category_name").AttemptedValue) ? "" : form.GetValue("category_name").AttemptedValue;
            if (form.GetValue("category_notes") != null)
                this.Model.category_notes = string.IsNullOrEmpty(form.GetValue("category_notes").AttemptedValue) ? "" : form.GetValue("category_notes").AttemptedValue;
            this.Model.image_url = fileName;
            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            _categoryActionAction_BL.Save(this.Model, result_object);
        }

        //public void ChangeStatus(int? home_page_Content_id, int status, ResultObject result_object)
        //{
        //    result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        //    _homePageContentAction_BL.ChangeStatus(home_page_Content_id, status, result_object);
        //}

        public void Search(int? category_id, string search_text, int status, ResultObject result_object)
        {
            StringBuilder sb = new StringBuilder();

            result_object.ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            CategoryList = _categoryActionAction_BL.GetList(category_id, search_text, status, result_object);
            if (CategoryList.Count > 0)
            {
                if (category_id == null)
                {
                    foreach (var item in CategoryList)
                    {
                        sb.Append("<tr>");

                        sb.Append("<td>");
                        if (item.isactive == 0)
                        {

                            //sb.Append("<a href='#' class='pr-3' data-home_page_Content_id='" + item.home_page_content_id + "'  id='aactive' ><i class='fa fa-flash' aria-hidden='true' title='Activate'></i></a>");

                        }
                        else
                        {
                            sb.Append("<a href='#' class='pr-3' data-category_id='" + item.category_id + "'  id='aedit' ><i class='fa fa-edit' aria-hidden='true' title='Edit'></i></a>");
                            //sb.Append("<a href='#' class='pr-3' data-home_page_content_id='" + item.home_page_content_id + "'  id='aDeactive' ><i class='fa fa-flash' aria-hidden='true' title='Deactivate'></i></a>");

                        }


                        string url = "/images/notavailable.png";
                        if (Convert.ToString(item.image_url) != "")
                        {
                            url = "/images/" + item.image_url;
                        }

                        sb.Append("</td>");
                        sb.Append("<td>" + "<img id='category_img_grid' height='60' width='100' style='border:solid' src='" + url + "' />" + "</td>");
                        sb.Append("<td>" + item.category_name + "</td>");
                        sb.Append("<td>" + item.category_notes + "</td>");

                        sb.Append("</tr>");
                    }
                    result_object.recordHTML = Convert.ToString(sb);
                }
                else
                {
                    result_object.Records = new List<object>(CategoryList);
                }
            }
        }
    }
}