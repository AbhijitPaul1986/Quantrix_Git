using Entity.Models;
using ErrorLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utility;

namespace Data.Actions
{
    public class PageAction : ConnectionProvider
    {
        public List<PageModel> GetPages(int? page_id, ResultObject result_object)
        {
            List<PageModel> _pages = new List<PageModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[spGetPageInfo]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (page_id == null)
                        cmd.Parameters.AddWithValue("@page_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@page_id", page_id);

                    

                   
                    cmd.CommandTimeout = 0;
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    conn.Close();
                }

                if (ds.Tables.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        
                            PageModel _page = new PageModel();
                            _page.page_id = Convert.ToInt32(ds.Tables[0].Rows[i]["page_id"]);
                            _page.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                            //_page.headertext = Convert.ToString(ds.Tables[0].Rows[i]["headertext"]);
                            //_page.subtext1 = Convert.ToString(ds.Tables[0].Rows[i]["subtext1"]);
                            //_page.subtext2 = Convert.ToString(ds.Tables[0].Rows[i]["subtext2"]);
                            //_page.subtext3 = Convert.ToString(ds.Tables[0].Rows[i]["subtext3"]);
                            //_page.subtext4 = Convert.ToString(ds.Tables[0].Rows[i]["subtext4"]);
                            //_page.image_url = Convert.ToString(ds.Tables[0].Rows[i]["image_url"]);
                            //_page.createdOn = Convert.ToString(ds.Tables[0].Rows[i]["created"]);
                            //if (Convert.ToString(ds.Tables[0].Rows[i]["modified"]) != "")
                            //    _page.modifiedOn = Convert.ToString(ds.Tables[0].Rows[i]["modified"]);
                            //else
                            //    _page.modifiedOn = "";
                            //if (Convert.ToString(ds.Tables[0].Rows[i]["deactivated"]) != "")
                            //    _page.deactivatedOn = Convert.ToString(ds.Tables[0].Rows[i]["deactivated"]);
                            //else
                            //    _page.deactivatedOn = "";
                            //_page.createdBy = Convert.ToString(ds.Tables[0].Rows[i]["created_by"]);
                            //_page.modifiedBy = Convert.ToString(ds.Tables[0].Rows[i]["modified_by"]);
                            //_page.deactivatedBy = Convert.ToString(ds.Tables[0].Rows[i]["deactivated_by"]);
                            //_page.isactive = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["is_active"]) == "" ? 0 : ds.Tables[0].Rows[i]["is_active"]);
                            _pages.Add(_page);
                        

                    }
                }

                //CheckUserType(ds, result_object);
            }
            return _pages;
        }

        public void SaveBanner(PageModel model, ResultObject result_object)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_Banners_Save]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@banner_id", Convert.ToInt32(model.banner_id));
                        cmd.Parameters.AddWithValue("@page_id", Convert.ToInt32(model.page_id));
                        cmd.Parameters.AddWithValue("@headertext", Convert.ToString(model.headertext));
                        cmd.Parameters.AddWithValue("@subtext", Convert.ToString(model.subtext));

                        if (model.image_url=="")
                            cmd.Parameters.AddWithValue("@image_url", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@image_url", Convert.ToString(model.image_url));
                       
                        if (HttpContext.Current.Session["UserID"] == null)
                            cmd.Parameters.AddWithValue("@created_by", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@created_by", Convert.ToInt32(HttpContext.Current.Session["UserID"]));
                        cmd.Parameters.AddWithValue("@ip_address", result_object.ipAddress);
                        cmd.CommandTimeout = 0;
                        conn.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        conn.Close();
                        result_object.success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.log(ex, "DataAccess.Actions.PageAction.SaveBanner");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }
        }

        public List<PageModel> GetBanners(int? page_id, int? banner_id, string searchText, int status, ResultObject result_object)
        {
            List<PageModel> _pages = new List<PageModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[spGetBannerInfo]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (page_id == null)
                        cmd.Parameters.AddWithValue("@page_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@page_id", page_id);

                    if (banner_id == null)
                        cmd.Parameters.AddWithValue("@banner_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@banner_id", banner_id);


                    if (searchText == null || searchText == "")
                        cmd.Parameters.AddWithValue("@search_text", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@search_text", searchText);

                    if (status == 1)
                        cmd.Parameters.AddWithValue("@status", 1);
                    else if (status == 0)
                        cmd.Parameters.AddWithValue("@status", 0);
                    else
                        cmd.Parameters.AddWithValue("@status", DBNull.Value);

                    cmd.CommandTimeout = 0;
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    conn.Close();
                }

                if (ds.Tables.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        PageModel _page = new PageModel();
                        _page.page_id = Convert.ToInt32(ds.Tables[0].Rows[i]["page_id"]);
                        _page.banner_id = Convert.ToInt32(ds.Tables[0].Rows[i]["banner_id"]);
                        _page.headertext = Convert.ToString(ds.Tables[0].Rows[i]["headertext"]);
                        _page.subtext = Convert.ToString(ds.Tables[0].Rows[i]["subtext"]);
                        _page.image_url = Convert.ToString(ds.Tables[0].Rows[i]["image_url"]);
                        _page.isactive = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["is_active"]) == "" ? 0 : ds.Tables[0].Rows[i]["is_active"]);
                        _pages.Add(_page);
                        
                    }
                }
            }
            result_object.success = true;
            return _pages;
        }

        public void ChangeStatus(int? banner_id, int status, ResultObject result_object)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_Banners_Active_Deactive]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@banner_id", Convert.ToInt32(banner_id));
                        cmd.Parameters.AddWithValue("@status", Convert.ToBoolean(status));

                        if (HttpContext.Current.Session["UserID"] == null)
                            cmd.Parameters.AddWithValue("@created_by", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@created_by", Convert.ToInt32(HttpContext.Current.Session["UserID"]));
                        cmd.Parameters.AddWithValue("@ip_address", result_object.ipAddress);
                        cmd.CommandTimeout = 0;
                        conn.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        conn.Close();
                        result_object.success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.log(ex, "DataAccess.Actions.PageAction.ChangeStatus");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }

        }
    }
}
