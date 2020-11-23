using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class UserTypeModel
    {
        public bool admin { get; set; }
        public bool superAdmin { get; set; }
        public bool systemAdmin { get; set; }
        //public bool verifier { get; set; }
        //public bool analyst { get; set; }
    }
}
