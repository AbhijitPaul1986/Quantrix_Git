using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class LoginAction
    {
        Data.Actions.LoginAction _loginAction_DL = new Data.Actions.LoginAction();
        public LoginModel GetLoginInfo(string username, ResultObject result_object)
        {
            return _loginAction_DL.GetLoginInfo(username, result_object);
            //return new LoginModel();
        }
    }
}
