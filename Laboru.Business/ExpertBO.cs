using Laboru.Data;
using Laboru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Laboru.Business
{
    public class ExpertBO : BaseExpertBO
    {
        private static ExpertBO instance;

        public static ExpertBO GetInstance()
        {
            if (instance == null)
            {
                instance = new ExpertBO();
            }

            return instance;
        }

        public string FormatMobileNumber(string number)
        {
            if (String.IsNullOrEmpty(number))
            {
                return "";
            }

            //Remove unnecessary chars
            number = number.Replace("+", "").Replace(" ", "").Replace("-","");

            //Add Country Code if not there
            if (!number.StartsWith("57") && number.Length == 10 && number.StartsWith("3"))
            {
                number = "57" + number;
            }

            //Just 15 Chars
            if(number.Length > 15){
                number = number.Substring(0, 15);
            }

            return number;
        }

		public override List<ExpertDataModel> GetAll(int id = 0)
        {
			return base.GetAll(id);            
        }

        public ExpertDataModel Get(int id, int fromExpertID, bool useCache = false)
        {
            ExpertDataModel expert = base.Get(id, useCache);
            expert.Skills = ExpertDAL.GetSkills(id, fromExpertID);

            return expert;
        }

		public override int CreateOrUpdate(ExpertDataModel item)
        {
            item.ID = base.CreateOrUpdate(item);

            return Convert.ToInt32(item.ID);
        }

        public ExpertDataModel Register(ExpertDataModel item)
        {
            //Remove + and " " chars
            item.Mobile = FormatMobileNumber(item.Mobile);

            ExpertDataModel model = ExpertDAL.GetByMobile(item.Mobile);
            if (model != null)
            {
                //Set ID so info is updated (Name)
                item.ID = model.ID;
            }

            item.ID = CreateOrUpdate(item);

            return  item;
        }

        public void SetExpertContacts(ExpertDataModel expert, List<ExpertDataModel> contacts)
        {
            ExpertDAL.DeleteContacts(Convert.ToInt32(expert.ID));
            foreach (var item in contacts)
            {
                try
                {
                    //Remove + and " " chars
                    item.Mobile = FormatMobileNumber(item.Mobile);

                    //Create if it does not exist
                    ExpertDataModel model = ExpertDAL.GetByMobile(item.Mobile);
                    if (model == null)
                    {
                        model = item;
                        model.ID = CreateOrUpdate(item);
                    }
                    ExpertDAL.AddContact(Convert.ToInt32(expert.ID), Convert.ToInt32(model.ID));
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(@"C:\Plenum\Laboru\WebServices\Logs\Errors.txt", "\r\n" + DateTime.Now.ToString() + item.Name + " " + 
                        item.Mobile + " " + ex.Message);
                }                
            }
        }

        public List<ExpertSearchResultDataModel> GetBySkillAndExpert(int skillID, int fromExpertID)
        {
            return ExpertDAL.GetBySkillAndExpert(skillID, fromExpertID);
        }

        public List<ExpertSearchResultDataModel> GetRecommendationsByExpert(int expertID, int fromExpertID)
        {
            return ExpertDAL.GetRecommendationsByExpert(expertID, fromExpertID);
        }

        public List<ExpertDataModel> GetRecommendationsBySkillAndExpert(int skillID, int expertID, int fromExpertID)
        {
            return ExpertDAL.GetRecommendationsBySkillAndExpert(skillID, expertID, fromExpertID);
        }

        public void RecommendExpert(int skillID, int expertID, int fromExpertID)
        {
            ExpertDAL.RecommendExpert(skillID, expertID, fromExpertID);
        }

        public void DeleteRecommendation(int skillID, int expertID, int fromExpertID)
        {
            ExpertDAL.DeleteRecommendation(skillID, expertID, fromExpertID);
        }

    }
}
