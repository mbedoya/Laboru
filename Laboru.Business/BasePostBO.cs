using Laboru.Data;
using Laboru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Laboru.Business
{
    public class BasePostBO
    {
        public virtual List<PostDataModel> GetAll(int id=0)
        {
            return PostDAL.GetAll();
        }

		
				public virtual List<PostDataModel> GetPostByPage(int id)
        {
            return PostDAL.GetPostByPage(id);
        }
				public virtual List<PostDataModel> GetPostByExpert(int id)
        {
            return PostDAL.GetPostByExpert(id);
        }
		
		public virtual PostDataModel Get(int id, bool useCache = false)
        {
            return PostDAL.Get(id);
        }

		public virtual PostDataModel GetByName(string name, bool useCache = false)
        {
            return PostDAL.GetByName(name);
        }

		public virtual List<PostDataModel> Filter(PostDataModel model)
        {
            return PostDAL.Filter(model);
        }

        public virtual int CreateOrUpdate(PostDataModel item)
        {
						

            if (item.ID > 0)
            {
                PostDAL.Update(item);
            }
            else
            {
                item.ID = PostDAL.Create(item);
            }

			return Convert.ToInt32(item.ID);           
        }     

		public virtual void Delete(int id)
        {
            PostDAL.Delete(id);
        }
    }
}