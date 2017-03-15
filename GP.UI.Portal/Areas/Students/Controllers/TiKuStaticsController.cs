using GP.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using GP.Common;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class TiKuStaticsController : BaseStudentsController
    {
        //
        // GET: /Students/TiKuStatics/
        public IGP_TiKuResultService tiKuResultService { get; set; }
        public ActionResult Frame()
        {
            return View();
        }
        public ActionResult Top()
        {
            return View();
        }
        public ActionResult Body()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        #region 加载结果
        public ActionResult Load() {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string studentsName = CommonFunc.SafeGetStringFromObj(loginModel.name);
            string trainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            string SubjectCode = CommonFunc.SafeGetStringFromObj(Request["SubjectCode"]);

            var tiKuResultList = tiKuResultService.LoadEntities(u=>(u.StudentsName==studentsName)&&(u.TrainingBaseCode==trainingBaseCode)
                &&(u.SubjectCode==SubjectCode)).OrderByDescending(u=>u.RegisterDate).Take(10);
            return Json(tiKuResultList,JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
