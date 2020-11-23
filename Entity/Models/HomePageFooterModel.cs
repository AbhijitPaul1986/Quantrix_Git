using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class HomePageFooterModel
    {
        public int home_page_footer_id { get; set; }
        public string footer_text { get; set; }
        public string footer_sub_text { get; set; } 
        public string client_name { get; set; }
        public string copywriter { get; set; }

        private string _createdOn;
        public string createdOn
        {
            get
            {
                return _createdOn;
            }
            set
            {
                _createdOn = Convert.ToString(value) != "" ? Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss tt") : "";
            }
        }
        private string _modifiedOn;
        public string modifiedOn
        {
            get
            {
                return _modifiedOn;
            }
            set
            {
                _modifiedOn = Convert.ToString(value) != "" ? Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss tt") : "";
            }
        }
        private string _deactivatedOn;
        public string deactivatedOn
        {
            get
            {
                return _deactivatedOn;
            }
            set
            {
                _deactivatedOn = Convert.ToString(value) != "" ? Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss tt") : "";
            }
        }
        public string createdBy { get; set; }
        public string modifiedBy { get; set; }
        public string deactivatedBy { get; set; }
        public int? isactive { get; set; }
    }
}
