using Laboru.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboru.WebServices.Controllers
{
    public class SkillController : Controller
    {
        //
        // GET: /Skill/

        public JsonResult GetAll()
        {
            return Json(SkillBO.GetInstance().GetAll(), JsonRequestBehavior.AllowGet);
        }

    }
}
