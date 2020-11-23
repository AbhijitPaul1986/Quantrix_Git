using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class AboutUsAction
    {
        Data.Actions.AboutUsAction _aboutUsAction_DL = new Data.Actions.AboutUsAction();
        public List<AboutUsModel> GetSections(int? section_id, ResultObject result_object)
        {
            return _aboutUsAction_DL.GetSections(section_id, result_object);
        }

        public void Save(AboutUsModel model, ResultObject result_object)
        {
            _aboutUsAction_DL.Save(model, result_object);
        }

        public List<AboutUsModel> Get(int? section_id, int? section_details_id, string searchText, int status, ResultObject result_object)
        {
            return _aboutUsAction_DL.Get(section_id, section_details_id, searchText, status, result_object);
        }

        public void ChangeStatus(int? section_details_id, int status, ResultObject result_object)
        {
            _aboutUsAction_DL.ChangeStatus(section_details_id, status, result_object);
        }
    }
}
