using Laboru.Data;
using Laboru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Laboru.Business
{
    public class BaseExpertBO
    {
        public virtual List<ExpertDataModel> GetAll(int id=0)
        {
            return ExpertDAL.GetAll();
        }
		
		public virtual ExpertDataModel Get(int id, bool useCache = false)
        {
            return ExpertDAL.Get(id);
        }

		public virtual ExpertDataModel GetByName(string name, bool useCache = false)
        {
            return ExpertDAL.GetByName(name);
        }

		public virtual List<ExpertDataModel> Filter(ExpertDataModel model)
        {
            return ExpertDAL.Filter(model);
        }

        public virtual int CreateOrUpdate(ExpertDataModel item)
        {
						

            if (item.ID > 0)
            {
                ExpertDAL.Update(item);
            }
            else
            {
                item.ID = ExpertDAL.Create(item);
            }

			return Convert.ToInt32(item.ID);           
        }     

		public virtual void Delete(int id)
        {
            ExpertDAL.Delete(id);
        }
    }
}