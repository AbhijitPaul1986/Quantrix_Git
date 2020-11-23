using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using System.Web;
using ErrorLog;
using Entity.Models;
namespace Data.Actions
{
    public class HomePageContentAction : ConnectionProvider
    {
        public List<HomePageContentModel> GetList(int? home_page_Content_id, string search_text, int? status, ResultObject result_object)
        {
            List<HomePageContentModel> _homePageContents = new List<HomePageContentModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_HomePageContent_Get]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (home_page_Content_id == null)
                        cmd.Parameters.AddWithValue("@home_page_content_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@home_page_content_id", home_page_Content_id);

                    if (search_text == null || search_text == "")
                        cmd.Parameters.AddWithValue("@search_text", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@search_text", search_text);

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

                        HomePageContentModel _homePageContent = new HomePageContentModel();
                        _homePageContent.home_page_content_id = Convert.ToInt32(ds.Tables[0].Rows[i]["home_page_content_id"]);
                        _homePageContent.content_text = Convert.ToString(ds.Tables[0].Rows[i]["content_text"]);
                        _homePageContent.content_name = Convert.ToString(ds.Tables[0].Rows[i]["content_name"]);
                        _homePageContent.isactive = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["is_active"]) == "" ? 0 : ds.Tables[0].Rows[i]["is_active"]);
                        _homePageContent.icon = Convert.ToString(ds.Tables[0].Rows[i]["icon"]);
                        _homePageContents.Add(_homePageContent);
                        result_object.success = true;
                    }
                }


            }
            return _homePageContents;
        }


        public void Save(int hdnAddressID, string Content_text, ResultObject result_object)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_HomePageContent_Save]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@home_page_content_id", Convert.ToInt32(hdnAddressID));
                        cmd.Parameters.AddWithValue("@Content_text", Convert.ToString(Content_text));
                        
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
                Error.log(ex, "DataAccess.Actions.HomePageContentAction.Save");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }

        }


        public void ChangeStatus(int? home_page_Content_id, int status, ResultObject result_object)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_HomePageContent_Active_Deactive]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@home_page_content_id", Convert.ToInt32(home_page_Content_id));
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
                Error.log(ex, "DataAccess.Actions.HomePageContentAction.ChangeStatus");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }

        }
    }
}
