using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business.Actions
{
    public class CategoryAction
    {
        Data.Actions.CategoryAction _categoryAction_DL = new Data.Actions.CategoryAction();
        public List<CategotyModel> GetList(int? category_id, string search_text, int status, ResultObject result_object)
        {
            return _categoryAction_DL.GetList(category_id, search_text, status, result_object);
        }
        public void Save(CategotyModel model, ResultObject result_object)
        {
            _categoryAction_DL.Save(model, result_object);
        }

        //public void ChangeStatus(int? home_page_contact_id, int status, ResultObject result_object)
        //{
        //    _categoryAction_DL.ChangeStatus(home_page_contact_id, status, result_object);
        //}
    }
}
