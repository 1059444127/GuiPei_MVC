using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Common;
using GP.IBLL;
using GP.Model;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class StudentsBasicInformationController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsBasicInformation/
        public IGP_StudentsPersonalInformation2Service studentsPersonalInformation2Service { get; set; }
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
        public ActionResult Left()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

        #region 加载分页列表

        public ActionResult LeftToList(string RealName, string Sex, string MinZu, string HighEducation, string HighSchool, string IdentityType,
            string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
        {
            ViewData["RealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RealName));
            ViewData["Sex"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Sex));
            ViewData["MinZu"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(MinZu));
            ViewData["HighEducation"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(HighEducation));
            ViewData["HighSchool"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(HighSchool));
            ViewData["IdentityType"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(IdentityType));
            ViewData["SendUnit"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(SendUnit));
            ViewData["CollaborativeUnit"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(CollaborativeUnit));
            ViewData["TrainingTime"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(TrainingTime));
            ViewData["PlanTrainingTime"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(PlanTrainingTime));
           
            return View("List");
        }

        public ActionResult PageList()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string trainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            string professionalBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.professional_base_code);
            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string realName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RealName"]));
            string sex = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["Sex"]));
            string minZu = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["MinZu"]));
            string highEducation = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["HighEducation"]));
            string highSchool = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["HighSchool"]));
            string identityType = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["IdentityType"]));
            string sendUnit = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["SendUnit"]));
            string collaborativeUnit = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["CollaborativeUnit"]));
            string trainingTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["TrainingTime"]));
            string planTrainingTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["PlanTrainingTime"]));
            int totalCount = 0;

            ExpressionHelper<GP_StudentsPersonalInformation2> expression = new ExpressionHelper<GP_StudentsPersonalInformation2>();
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            expression.Equal("ProfessionalBaseCode", professionalBaseCode);
            if (realName != "")
            {
                expression.Equal("RealName", realName);
            }
            if (sex != "")
            {
                expression.Equal("Sex", sex);
            }
            if (minZu != "")
            {
                expression.Equal("MinZu", minZu);
            }
            if (highEducation != "")
            {
                expression.Equal("HighEducation", highEducation);
            }
            if (highSchool != "")
            {
                expression.Contains("HighSchool", highSchool);
            }
            if (identityType != "")
            {
                expression.Equal("IdentityType", identityType);
            }
            if (sendUnit != "")
            {
                expression.Contains("SendUnit", sendUnit);
            }
            if (collaborativeUnit != "")
            {
                expression.Contains("CollaborativeUnit", collaborativeUnit);
            }
            if (trainingTime != "")
            {
                expression.Contains("TrainingTime", trainingTime);
            }
            if (planTrainingTime != "")
            {
                expression.Contains("PlanTrainingTime", planTrainingTime);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var studentsPersonalInformation2List = studentsPersonalInformation2Service.LoadPageEntities(pageSize,pageIndex,out totalCount,expression.GetExpression(),u=>u.TrainingTime,false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = studentsPersonalInformation2List, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var studentsPersonalInformation2List = studentsPersonalInformation2Service.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(studentsPersonalInformation2List, JsonRequestBehavior.AllowGet);

        }
        #endregion

    }
}
