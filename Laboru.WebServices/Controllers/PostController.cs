using Laboru.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboru.Models;

namespace Laboru.WebServices.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public JsonResult Get(int id)
        {
            return Json(PostBO.GetInstance().Get(id, true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetForExpert(int id)
        {
            return Json(PostBO.GetInstance().GetPostForExpert(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByExpert(int id)
        {
            return Json(PostBO.GetInstance().GetPostByExpert(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            return Json(PostBO.GetInstance().GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(PostDataModel post)
        {
            PostBO.GetInstance().CreateOrUpdate(post);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
