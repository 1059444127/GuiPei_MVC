using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.IBLL;
using GP.Model;
using GP.Common;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class QuestionBankController : BaseStudentsController
    {
        //
        // GET: /Students/QuestionBank/
        public IGP_NeiKeOptionService neiKeOptionService { get; set; }
        public IGP_TiKuResultService tiKuResultService { get; set; }
        public ActionResult Frame()
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

        #region 加载题库
        public ActionResult Load() {
            string code =CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["code"]));
            var neiKeOptionList = neiKeOptionService.LoadEntities(u=>u.SubjectCode==code).OrderBy(u=>Guid.NewGuid()).Take(50);
            return Json(neiKeOptionList,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 保存答题结果
        public ActionResult Add()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string StudentsName = CommonFunc.SafeGetStringFromObj(loginModel.name.ToString());
            string StudentsRealName = CommonFunc.SafeGetStringFromObj(loginModel.real_name.ToString());
            string TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code.ToString());
            string TrainingBaseName = CommonFunc.SafeGetStringFromObj(loginModel.training_base_name.ToString());
            string  RegisterDate = CommonFunc.SafeGetMyDateTimeStringFromObjectByFormat(DateTime.Now.ToString(),"yyyy-MM-dd hh:mm");
            string SubjectName = CommonFunc.SafeGetStringFromObj(Request["SubjectName"]);
            string SubjectCode = CommonFunc.SafeGetStringFromObj(Request["SubjectCode"]);
            string TotalScore = CommonFunc.SafeGetStringFromObj(Request["TotalScore"]);
            string TotalNum = CommonFunc.SafeGetStringFromObj(Request["TotalNum"]);
            string UndoNum = CommonFunc.SafeGetStringFromObj(Request["UndoNum"]);
            string CorrectNum =CommonFunc.SafeGetStringFromObj(Request["CorrectNum"]);
            string ErrorNum = CommonFunc.SafeGetStringFromObj(Request["ErrorNum"]);

            GP_TiKuResult tiKuResultModel = new GP_TiKuResult();
            tiKuResultModel.Id = Guid.NewGuid().ToString();
            tiKuResultModel.StudentsName = StudentsName;
            tiKuResultModel.StudentsRealName = StudentsRealName;
            tiKuResultModel.TrainingBaseCode = TrainingBaseCode;
            tiKuResultModel.TrainingBaseName = TrainingBaseName;
            tiKuResultModel.SubjectName = SubjectName;
            tiKuResultModel.SubjectCode = SubjectCode;
            tiKuResultModel.TotalScore = TotalScore;
            tiKuResultModel.TotalNum = TotalNum;
            tiKuResultModel.UndoNum = UndoNum;
            tiKuResultModel.CorrectNum = CorrectNum;
            tiKuResultModel.ErrorNum = ErrorNum;
            tiKuResultModel.RegisterDate = RegisterDate;

            if (tiKuResultService.AddEntity(tiKuResultModel))
            {
                return Content("1");//保存成功
            }
            else
            {
                return Content("0");
            }
            
        }
        #endregion
    }
}
