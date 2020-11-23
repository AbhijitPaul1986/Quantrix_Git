using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ResultObject : UserTypeModel
    {
        public Object Record { get; set; }
        public List<Object> Records { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public string exceptionMsg { get; set; }
        public string UserName { get; set; }
        public int? UserID { get; set; }    
        public string recordHTML { get; set; }        
        public string ipAddress { get; set; }
        public bool? is_session_out { get; set; }
        public bool? is_error_raised { get; set; }
        public string email { get; set; }
        public string Name { get; set; }
        
    }
}
