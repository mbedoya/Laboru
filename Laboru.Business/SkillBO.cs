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
            return SkillDAL.GetAll();
        }
    }
}
