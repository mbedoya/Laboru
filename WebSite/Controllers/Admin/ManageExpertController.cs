using Laboru.Business;
using Laboru.Models;
using Plenum.WebSite.Models;
using Plenum.WebSite.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboru.WebSite.Controllers.Admin
{
    public class ManageExpertController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(ExpertDataModel model)
        {
            List<ExpertDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Mobile))
            {
                list = ExpertBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = ExpertBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = ExpertBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

						
		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ExpertDataModel());
            }
            else
            {
                return View(ExpertBO.GetInstance().Get(id));
            }
            
        }
				

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ExpertDataModel item)
        {
            ExpertBO.GetInstance().CreateOrUpdate(item);

            if (Session["ExpertParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ExpertParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            ExpertBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

		
    }
}