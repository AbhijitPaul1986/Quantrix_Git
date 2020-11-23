using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class PageAction
    {
        Data.Actions.PageAction _distributorAction_DL = new Data.Actions.PageAction();
        public List<PageModel> GetPages(int? page_id, ResultObject result_object)
        {
            return _distributorAction_DL.GetPages(page_id, result_object);
        }

        public void SaveBanner(PageModel model, ResultObject result_object)
        {
             _distributorAction_DL.SaveBanner(model, result_object);
        }

        public List<PageModel> GetBanners(int? page_id, int? banner_id, string searchText, int status, ResultObject result_object)
        {
            return _distributorAction_DL.GetBanners(page_id, banner_id, searchText, status, result_object);
        }

        public void ChangeStatus(int? banner_id, int status, ResultObject result_object)
        {
            _distributorAction_DL.ChangeStatus(banner_id, status, result_object);
        }
    }
}
