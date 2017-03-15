using GP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class StudentsTeachingActivitiesController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsTeachingActivities/
        public IGP_TeachingActivitiesService teachingActivitiesService { get; set; }
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

        public ActionResult LeftToList(string StudentsRealName, string ActivityForm, string MainSpeaker, string ClassHour, string ActivityDate)
        {
            ViewData["StudentsRealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(StudentsRealName));
            ViewData["ActivityForm"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ActivityForm));
            ViewData["MainSpeaker"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(MainSpeaker));
            ViewData["ClassHour"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ClassHour));
            ViewData["ActivityDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ActivityDate));

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
            string StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["StudentsRealName"]));
            string ActivityForm = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ActivityForm"]));
            string MainSpeaker = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["MainSpeaker"]));
            string ClassHour = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ClassHour"]));
            string ActivityDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ActivityDate"]));
            int totalCount = 0;

            ExpressionHelper<GP_TeachingActivities> expression = new ExpressionHelper<GP_TeachingActivities>();
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            expression.Equal("DeptCode", deptCode);
            expression.Equal("TeachersName", teachersName);
            if (StudentsRealName != "")
            {
                expression.Equal("StudentsRealName", StudentsRealName);
            }
            if (ActivityForm != "")
            {
                expression.Equal("ActivityForm", ActivityForm);
            }
            if (MainSpeaker != "")
            {
                expression.Equal("MainSpeaker", MainSpeaker);
            }
            if (ClassHour != "")
            {
                expression.Equal("ClassHour", ClassHour);
            }
            if (ActivityDate != "")
            {
                expression.Equal("ActivityDate", ActivityDate);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            var teachingActivitiesList = teachingActivitiesService.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = teachingActivitiesList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 指导医师审核

        public ActionResult Handle()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string check = CommonFunc.SafeGetStringFromObj(Request["check"]);
            GP_TeachingActivities teachingActivitiesModel = new GP_TeachingActivities();
            if (check == "未通过")
            {
                check = "已通过";
            }
            else
            {
                check = "未通过";
            }
            teachingActivitiesModel.Id = id;
            teachingActivitiesModel.TeacherCheck = check;

            if (teachingActivitiesService.Handle(teachingActivitiesModel))
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
        #endregion


        #region 查看加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var teachingActivitiesList = teachingActivitiesService.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(teachingActivitiesList, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
