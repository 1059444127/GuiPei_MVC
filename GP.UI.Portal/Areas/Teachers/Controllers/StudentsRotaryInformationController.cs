using GP.Common;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class StudentsRotaryInformationController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsRotaryInformation/
        public IRotaryInformationJoinService rotaryInformationJoinService { get; set; }
        public IGP_OutDept_ExamService outDeptExamService { get; set; }
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
            string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,string RotaryBeginTime,string RotaryEndTime,string OutdeptStatus)
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
            ViewData["RotaryBeginTime"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RotaryBeginTime));
            ViewData["RotaryEndTime"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RotaryEndTime));
            ViewData["OutdeptStatus"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(OutdeptStatus));
            return View("List");
        }

        public ActionResult PageList()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string trainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            string deptCode = CommonFunc.SafeGetStringFromObj(loginModel.dept_code);
            string teachersName = CommonFunc.SafeGetStringFromObj(loginModel.name);

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
            string rotaryBeginTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RotaryBeginTime"]));
            string rotaryEndTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RotaryEndTime"]));
            string outdeptStatus = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["OutdeptStatus"]));
            int totalCount = 0;

            ExpressionHelper<RotaryInformationJoin> expression = new ExpressionHelper<RotaryInformationJoin>();
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            expression.Equal("DeptCode", deptCode);
            expression.Equal("TeachersName", teachersName);
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

            if (rotaryBeginTime != "")
            {
                expression.Equal("RotaryBeginTime", rotaryBeginTime);
            }
            if (rotaryEndTime != "")
            {
                expression.Equal("rotaryEndTime", rotaryEndTime);
            }
            if (outdeptStatus != "")
            {
                expression.Equal("OutdeptStatus", outdeptStatus);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var rotaryInfomationJoinList = rotaryInformationJoinService.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.TrainingTime, false).OrderBy(u => u.RotaryBeginTime);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = rotaryInfomationJoinList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 提交出科考核

        public ActionResult TiJiao(GP_OutDept_Exam outDeptExamModel)
        {

            GP_StudentsRotaryInformation2 studentsRotaryInformation2Model = new GP_StudentsRotaryInformation2();
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string outDeptStatus = CommonFunc.SafeGetStringFromObj(Request["is_pass"]);
            studentsRotaryInformation2Model.Id = id;
            studentsRotaryInformation2Model.OutdeptStatus = outDeptStatus;

            if (outDeptExamService.AddAndUpdate(outDeptExamModel,studentsRotaryInformation2Model))
            {
                return Content("学员出科考核提交成功");
            }
            else
            {
                return Content("学员出科考核提交失败");
            }
        }
        #endregion
    }
}
