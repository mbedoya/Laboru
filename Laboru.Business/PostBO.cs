using Laboru.Data;
using Laboru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Laboru.Business
{
    public class PostBO : BasePostBO
    {
        private static PostBO instance;

        public static PostBO GetInstance()
        {
            if (instance == null)
            {
                instance = new PostBO();
            }

            return instance;
        }

		public override List<PostDataModel> GetAll(int id = 0)
        {
			//HttpContext.Current.Session["PostParentID"] = null;
			return base.GetAll(id);            
        }

        public List<PostDataModel> GetPostForExpert(int id)
        {
            return PostDAL.GetPostForExpert(id);
        }

		public override int CreateOrUpdate(PostDataModel item)
        {   
			if(item.ID == null){
                item.DateCreated = DateTime.Now;
            }

            item.ID = base.CreateOrUpdate(item);

            return Convert.ToInt32(item.ID);
        }

    }
}
