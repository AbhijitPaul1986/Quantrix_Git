using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AboutUsModel
    {
        public int section_id { get; set; }
        public int section_details_id { get; set; }
        public string section_name { get; set; }
        public string section_notes { get; set; }
        public string image_url { get; set; }

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
