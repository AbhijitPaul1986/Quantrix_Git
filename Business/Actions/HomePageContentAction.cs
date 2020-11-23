using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class HomePageContentAction
    {
        Data.Actions.HomePageContentAction _homePageContentAction_DL = new Data.Actions.HomePageContentAction();
        public List<HomePageContentModel> GetList(int? home_page_Content_id, string search_text, int? status, ResultObject result_object)
        {
            return _homePageContentAction_DL.GetList(home_page_Content_id, search_text, status, result_object);
        }
        public void Save(int hdnAddressID, string Content_text, ResultObject result_object)
        {
            _homePageContentAction_DL.Save(hdnAddressID, Content_text, result_object);
        }

        public void ChangeStatus(int? home_page_Content_id, int status, ResultObject result_object)
        {
            _homePageContentAction_DL.ChangeStatus(home_page_Content_id, status, result_object);
        }
    }
}
