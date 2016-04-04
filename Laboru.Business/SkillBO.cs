using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laboru.Models;
using Laboru.Data;

namespace Laboru.Business
{
    public class SkillBO
    {
        private static SkillBO instance;

        public static SkillBO GetInstance()
        {
            if (instance == null)
            {
                instance = new SkillBO();
            }

            return instance;
        }

        public List<SkillDataModel> GetAll(int id = 0)
        {
            List<SkillDataModel> list = null;

            /*
            Plenum.Utilities.Cache.CacheManager cache = Plenum.Utilities.Cache.CacheManager.GetInstance();

            list = cache.GetObject<SkillDataModel>("Skills");

            if (list == null){
                list = SkillDAL.GetAll();
                cache.AddObject("Skills", list);
            }
             */

            list = SkillDAL.GetAll();

            return list;
        }
    }
}
