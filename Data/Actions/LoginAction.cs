using Entity.Models;
using ErrorLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Data.Actions
{
    public class LoginAction : ConnectionProvider
    {
        public LoginModel GetLoginInfo(string username, ResultObject result_object)
        {
            LoginModel _loginModel = new LoginModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[spGetLoginInfo]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user_name", Convert.ToString(username));
                        cmd.CommandTimeout = 0;
                        conn.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        conn.Close();
                    }
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _loginModel.username = Convert.ToString(ds.Tables[0].Rows[0]["user_name"]);
                            _loginModel.userID = Convert.ToInt32(ds.Tables[0].Rows[0]["user_id"]);
                            _loginModel.name = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                            _loginModel.password = Cryptograph.Decrypt(Convert.ToString(ds.Tables[0].Rows[0]["user_password"]));
                            _loginModel.email = Convert.ToString(ds.Tables[0].Rows[0]["email_id"]);
                            _loginModel.admin = Convert.ToBoolean(ds.Tables[0].Rows[0]["is_admin"]);
                            //_loginModel.superAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["is_super_admin"]);
                            //_loginModel.systemAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["is_system_admin"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.log(ex, "DataAccess.Actions.LoginAction.GetLoginInfo");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
                result_object.is_error_raised = true;
            }
            return _loginModel;
        }
    }
}
