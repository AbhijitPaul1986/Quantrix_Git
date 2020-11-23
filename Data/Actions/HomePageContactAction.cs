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
    public class HomePageContactAction : ConnectionProvider
    {
        public List<HomePageContactModel> GetList(int? home_page_contact_id, string search_text, int? status, ResultObject result_object)
        {
            List<HomePageContactModel> _homePageContacts = new List<HomePageContactModel>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_HomePageContact_Get]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (home_page_contact_id == null)
                        cmd.Parameters.AddWithValue("@home_page_contact_id", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@home_page_contact_id", home_page_contact_id);

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

                        HomePageContactModel _homePageContact = new HomePageContactModel();
                        _homePageContact.home_page_contact_id = Convert.ToInt32(ds.Tables[0].Rows[i]["home_page_contact_id"]);
                        _homePageContact.address = Convert.ToString(ds.Tables[0].Rows[i]["address"]);
                        _homePageContact.email = Convert.ToString(ds.Tables[0].Rows[i]["email"]);
                        _homePageContact.phone = Convert.ToString(ds.Tables[0].Rows[i]["phone"]);
                        _homePageContact.isactive = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i]["is_active"]) == "" ? 0 : ds.Tables[0].Rows[i]["is_active"]);
                         _homePageContacts.Add(_homePageContact);
                         result_object.success = true;
                    }
                }

                
            }
            return _homePageContacts;
        }


        public void Save(int hdnAddressID,string address, string email, string phone, ResultObject result_object)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_HomePageContact_Save]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@home_page_contact_id", Convert.ToInt32(hdnAddressID));
                        cmd.Parameters.AddWithValue("@address", Convert.ToString(address));
                        cmd.Parameters.AddWithValue("@email", Convert.ToString(email));
                        cmd.Parameters.AddWithValue("@phone", Convert.ToString(phone));
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
                Error.log(ex, "DataAccess.Actions.HomePageContactAction.Save");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }
            
        }


        public void ChangeStatus(int? home_page_contact_id, int status, ResultObject result_object)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[sp_HomePageContact_Active_Deactive]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@home_page_contact_id", Convert.ToInt32(home_page_contact_id));
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
                Error.log(ex, "DataAccess.Actions.HomePageContactAction.ChangeStatus");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }

        }
    }
}
