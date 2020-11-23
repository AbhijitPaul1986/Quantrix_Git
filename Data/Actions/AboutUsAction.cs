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
    public class AboutUsAction : ConnectionProvider
    {
        public List<AboutUsModel> GetSections(int? section_id, ResultObject result_object)
        {
            List<AboutUsModel> _sections = new List<AboutUsModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[spGetAboutUsSectionInfo]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (section_id == null)
                        cmd.Parameters.AddWithValue("@section_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@section_id", section_id);
                    cmd.CommandTimeout = 0;
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    conn.Close();
                }

                if (ds.Tables.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AboutUsModel _section = new AboutUsModel();
                        _section.section_id = Convert.ToInt32(ds.Tables[0].Rows[i]["section_id"]);
                        _section.section_name = Convert.ToString(ds.Tables[0].Rows[i]["section_name"]);
                        _sections.Add(_section);
                    }
                }
            }
            return _sections;
        }

        public void Save(AboutUsModel model, ResultObject result_object)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_AboutUs_Section_Save]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@section_details_id", Convert.ToInt32(model.section_details_id));
                        cmd.Parameters.AddWithValue("@section_id", Convert.ToInt32(model.section_id));
                        //cmd.Parameters.AddWithValue("@section_name", Convert.ToString(model.section_name));
                        cmd.Parameters.AddWithValue("@section_notes", Convert.ToString(model.section_notes));
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
                Error.log(ex, "DataAccess.Actions.AboutUsAction.Save");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }
        }

        public List<AboutUsModel> Get(int? section_id, int? section_details_id, string searchText, int status, ResultObject result_object)
        {
            List<AboutUsModel> _sections = new List<AboutUsModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_AboutUs_Section_Details_Get]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (section_id == null)
                        cmd.Parameters.AddWithValue("@section_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@section_id", section_id);

                    if (section_details_id == null)
                        cmd.Parameters.AddWithValue("@section_details_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@section_details_id", section_details_id);

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
                        AboutUsModel _section = new AboutUsModel();
                        _section.section_id = Convert.ToInt32(ds.Tables[0].Rows[i]["section_id"]);
                        _section.section_details_id = Convert.ToInt32(ds.Tables[0].Rows[i]["section_details_id"]);
                        _section.section_name = Convert.ToString(ds.Tables[0].Rows[i]["section_name"]);
                        _section.section_notes = Convert.ToString(ds.Tables[0].Rows[i]["section_notes"]);
                        _section.image_url = Convert.ToString(ds.Tables[0].Rows[i]["image_url"]);
                        _section.isactive = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["is_active"]) == "" ? 0 : ds.Tables[0].Rows[i]["is_active"]);
                        _sections.Add(_section);
                    }
                }
            }
            result_object.success = true;
            return _sections;
        }

        public void ChangeStatus(int? section_details_id, int status, ResultObject result_object)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_Systbl_AboutUs_Section_Details_Active_Deactive]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@section_details_id", Convert.ToInt32(section_details_id));
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
                Error.log(ex, "DataAccess.Actions.AboutUsAction.ChangeStatus");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }
        }
    }
}
