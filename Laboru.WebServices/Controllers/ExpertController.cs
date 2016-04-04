using Laboru.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Laboru.Models;

namespace Laboru.WebServices.Controllers
{
    public class ExpertController : Controller
    {
        //
        // GET: /Expert/

        public JsonResult Get(int id, int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().Get(id, fromExpertID, true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ExpertDataModel expert)
        {
            ExpertBO.GetInstance().CreateOrUpdate(expert);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByMobile(ExpertDataModel expert, int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().GetByMobile(expert, fromExpertID, true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBySkillAndExpert(int skillID, int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().GetBySkillAndExpert(skillID, fromExpertID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMyRecommendations(int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().GetMyRecommendations(fromExpertID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRecommendationsByExpert(int expertID, int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().GetRecommendationsByExpert(expertID, fromExpertID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRecommendationsForExpert(int expertID)
        {
            return Json(ExpertBO.GetInstance().GetRecommendationsForExpert(expertID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllExpertSkills(int expertID)
        {
            return Json(ExpertBO.GetInstance().GetAllExpertSkills(expertID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRecommendationsBySkillAndExpert(int skillID, int expertID, int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().GetRecommendationsBySkillAndExpert(skillID, expertID, fromExpertID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult RecommendExpert(int skillID, int expertID, int fromExpertID)
        {
            ExpertBO.GetInstance().RecommendExpert(skillID, expertID, fromExpertID);

            return Json( new {success = true}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSkill(int skillID, int expertID, int fromExpertID)
        {
            ExpertBO.GetInstance().AddSkill(skillID, expertID, fromExpertID);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecommendation(int skillID, int expertID, int fromExpertID)
        {
            ExpertBO.GetInstance().DeleteRecommendation(skillID, expertID, fromExpertID);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Register(Laboru.Models.ExpertDataModel expert)
        {
            return Json(ExpertBO.GetInstance().Register(expert));
        }

        public JsonResult SetContacts(Laboru.Models.ExpertDataModel expert, List<Laboru.Models.ExpertDataModel> contacts)
        {
            try
            {
                /*
                foreach (var item in contacts)
                {
                    System.IO.File.AppendAllText(Server.MapPath("~/Logs/Errors.txt"), "\r\n" + DateTime.Now.ToString() + " " + item.Name + " " + item.Mobile);
                }
                 */ 
                ExpertBO.GetInstance().SetExpertContacts(expert, contacts);
                return Json(new { success = "true" });
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(Server.MapPath("~/Logs/Errors.txt"), "\r\n" + DateTime.Now.ToString() + " " + ex.Message);
                throw ex;
            }

            
        }

    }
}
