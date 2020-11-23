//using BusinessLogics.Actions;
using Entity.Models;
using ErrorLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;
using Business.Actions;

namespace Quantrix_Git.Models
{
    public class Login : Pagination
    {
        public LoginModel Model = new LoginModel();
        LoginAction _loginAction_BL = new LoginAction();
        public ResultObject GetLoginInfo(string username, string password)
        {
            ResultObject result_object = new ResultObject();
            try
            {
                Model = _loginAction_BL.GetLoginInfo(username, result_object);

                if (result_object.is_error_raised != true)
                {
                    if (this.Model.username == "" || this.Model.username == null)
                    { result_object.success = false; result_object.message = "Invalid login..!"; }
                    else
                    {
                        if (this.Model.password == password)
                        {
                            result_object.success = true;
                            result_object.UserID = this.Model.userID;
                            result_object.UserName = this.Model.username;
                            result_object.Name = this.Model.name;
                            result_object.email = this.Model.email;
                            result_object.admin = this.Model.admin;
                            //result_object.superAdmin = this.Model.superAdmin;
                            //result_object.systemAdmin = this.Model.systemAdmin;
                            //result_object.verifier = this.Model.verifier;
                            //result_object.analyst = this.Model.analyst;
                            result_object.is_session_out = null;
                            //result_object.login_in_out_info_history_id = 0;
                            //if (Utility.Enums.MenuList._permittedMenus.Contains("Dashboard"))
                            //{
                            //    result_object.dashboardAccess = true;
                            //}
                            //else
                            //{ result_object.dashboardAccess = false; }
                            //this.Model.hostName = Dns.GetHostName();
                            //this.Model.ipAddress = Dns.GetHostByName(Model.hostName).AddressList[0].ToString();
                            //_loginAction_BL.UpdateUserLoginDetails(result_object, this.Model.ipAddress);
                        }
                        else
                        {
                            result_object.success = false;
                            result_object.message = "Invalid login..!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.log(ex, "Quantrix.Models.Login.GetLoginInfo");
                result_object.success = false;
                result_object.message = "Unexpected Error occured.Please contact to development team.";
            }
            return result_object;
        }
    }
}