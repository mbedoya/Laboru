using Laboru.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Laboru.WebServices.Controllers
{
    public class ExpertController : Controller
    {
        //
        // GET: /Expert/

        public JsonResult Get(int id)
        {
            return Json(ExpertBO.GetInstance().Get(id, true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBySkillAndExpert(int skillID, int fromExpertID)
        {
            return Json(ExpertBO.GetInstance().GetBySkillAndExpert(skillID, fromExpertID), JsonRequestBehavior.AllowGet);
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
