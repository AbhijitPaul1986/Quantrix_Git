using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class HomePageContactAction
    {
        Data.Actions.HomePageContactAction _homePageContactAction_DL = new Data.Actions.HomePageContactAction();
        public List<HomePageContactModel> GetList(int? home_page_contact_id, string search_text, int? status, ResultObject result_object)
        {
            return _homePageContactAction_DL.GetList( home_page_contact_id,search_text,status, result_object);
        }
        public void Save(int hdnAddressID, string address, string email, string phone, ResultObject result_object)
        {
            _homePageContactAction_DL.Save(hdnAddressID,address, email, phone, result_object);
        }

        public void ChangeStatus(int? home_page_contact_id, int status, ResultObject result_object)
        {
            _homePageContactAction_DL.ChangeStatus( home_page_contact_id,status,result_object);
        }
    }
}
