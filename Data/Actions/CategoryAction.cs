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
    public class CategoryAction : ConnectionProvider
    {
        public void Save(CategotyModel model, ResultObject result_object)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_Category_Save]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@category_id", Convert.ToInt32(model.category_id));
                        cmd.Parameters.AddWithValue("@category_name", Convert.ToString(model.category_name));
                        cmd.Parameters.AddWithValue("@category_notes", Convert.ToString(model.category_notes));

                        if (model.image_url == "")
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
                Error.log(ex, "DataAccess.Actions.CategoryAction.Save");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }
        }

        public List<CategotyModel> GetList(int? category_id, string searchText, int status, ResultObject result_object)
        {
            List<CategotyModel> _categories = new List<CategotyModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_Category_Get]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (category_id == null)
                        cmd.Parameters.AddWithValue("@category_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@category_id", category_id);

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

                        CategotyModel _category = new CategotyModel();
                        _category.category_id = Convert.ToInt32(ds.Tables[0].Rows[i]["category_id"]);
                        _category.category_name = Convert.ToString(ds.Tables[0].Rows[i]["category_name"]);
                        _category.category_notes = Convert.ToString(ds.Tables[0].Rows[i]["category_notes"]);
                        _category.image_url = Convert.ToString(ds.Tables[0].Rows[i]["image_url"]);
                        _category.isactive = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["is_active"]) == "" ? 0 : ds.Tables[0].Rows[i]["is_active"]);
                        _categories.Add(_category);

                    }
                }
            }
            result_object.success = true;
            return _categories;
        }

        //public void ChangeStatus(int? banner_id, int status, ResultObject result_object)
        //{

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(conStr))
        //        {
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            DataSet ds = new DataSet();
        //            using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_Banners_Active_Deactive]", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@banner_id", Convert.ToInt32(banner_id));
        //                cmd.Parameters.AddWithValue("@status", Convert.ToBoolean(status));

        //                if (HttpContext.Current.Session["UserID"] == null)
        //                    cmd.Parameters.AddWithValue("@created_by", DBNull.Value);
        //                else
        //                    cmd.Parameters.AddWithValue("@created_by", Convert.ToInt32(HttpContext.Current.Session["UserID"]));
        //                cmd.Parameters.AddWithValue("@ip_address", result_object.ipAddress);
        //                cmd.CommandTimeout = 0;
        //                conn.Open();
        //                da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //                conn.Close();
        //                result_object.success = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.log(ex, "DataAccess.Actions.PageAction.ChangeStatus");
        //        result_object.success = false;
        //        result_object.message = "Unexpected Error occured.Please contact to development team.";
        //        result_object.is_error_raised = true;
        //    }

        //}
    }
}
