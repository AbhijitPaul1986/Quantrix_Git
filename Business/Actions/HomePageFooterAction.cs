using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class HomePageFooterAction
    {
        Data.Actions.HomePageFooterAction _homePageFooterAction_DL = new Data.Actions.HomePageFooterAction();
        public List<HomePageFooterModel> GetList(int? home_page_footer_id, string search_text, int? status, ResultObject result_object)
        {
            return _homePageFooterAction_DL.GetList(home_page_footer_id, search_text, status, result_object);
        }
        public void Save(int hdnAddressID, string footer_text, string footer_sub_text,string client_name, string copywriter, ResultObject result_object)
        {
            _homePageFooterAction_DL.Save(hdnAddressID, footer_text, footer_sub_text, client_name, copywriter, result_object);
        }

        public void ChangeStatus(int? home_page_footer_id, int status, ResultObject result_object)
        {
            _homePageFooterAction_DL.ChangeStatus(home_page_footer_id, status, result_object);
        }
    }
}
