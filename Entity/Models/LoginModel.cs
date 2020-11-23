using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class LoginModel : UserTypeModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string hostName { get; set; }
        public string ipAddress { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string _login_time { get; set; }
        public string login_time
        {
            get
            {
                return _login_time;
            }
            set
            {
                _login_time = Convert.ToString(value) != "" ? Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss tt") : "";
            }
        }


        public string _logout_time { get; set; }
        public string logout_time
        {
            get
            {
                return _logout_time;
            }
            set
            {
                _logout_time = Convert.ToString(value) != "" ? Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss tt") : "";
            }
        }
        public bool? is_session_out { get; set; }
    }
}
