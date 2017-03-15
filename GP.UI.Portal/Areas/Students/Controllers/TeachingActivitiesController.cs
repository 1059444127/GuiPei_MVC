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
    public class TeachingActivitiesController : BaseStudentsController
    {
        //
        // GET: /Students/TeachingActivities/
        IGP_TeachingActivitiesService teachingActivitiesService { get; set; }
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
        public ActionResult Manage()
        {
            return View();
        }

        #region 新增教学活动登记
        public ActionResult Add(GP_TeachingActivities teachingActivitiesModel)
        {
            teachingActivitiesModel.TeacherCheck = "未通过";
            teachingActivitiesModel.BaseCheck = "未通过";
            teachingActivitiesModel.KzrCheck = "未通过";
            teachingActivitiesModel.ManagerCheck = "未通过";
            if (teachingActivitiesService.AddEntity(teachingActivitiesModel))
            {
                return Content("1");//成功
            }
            else
            {
                return Content("0");//失败
            }
        } 
        #endregion

        #region 加载分页列表

        public ActionResult LeftToList(string DeptName, string ActivityForm, string MainSpeaker, string ClassHour, string ActivityDate)
        {
            ViewData["DeptName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DeptName));
            ViewData["ActivityForm"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ActivityForm));
            ViewData["MainSpeaker"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(MainSpeaker));
            ViewData["ClassHour"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ClassHour));
            ViewData["ActivityDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ActivityDate));
            return View("List");
        }

        public ActionResult PageList()
        {
            string name = (Session["loginInfo"] as GP_Login).name.ToString();
            string trainingBaseCode = (Session["loginInfo"] as GP_Login).training_base_code.ToString();
            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string deptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["DeptName"]));
            string activityForm = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ActivityForm"]));
            string mainSpeaker = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["MainSpeaker"]));
            string classHour = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ClassHour"]));
            string activityDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ActivityDate"]));
            int totalCount = 0;

            ExpressionHelper<GP_TeachingActivities> expression = new ExpressionHelper<GP_TeachingActivities>();
            expression.Equal("StudentsName", name);
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            if (deptName != "")
            {
                expression.Contains("DeptName", deptName);
            }
            if (activityForm != "")
            {
                expression.Equal("ActivityForm", activityForm);
            }
            if (mainSpeaker != "")
            {
                expression.Contains("MainSpeaker", mainSpeaker);
            }
            if (classHour != "")
            {
                expression.Contains("ClassHour", classHour);
            }
            if (activityDate != "")
            {
                expression.Equal("ActivityDate", activityDate);
            }
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var teachingActivitiesList = teachingActivitiesService.LoadPageEntities<string>(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = teachingActivitiesList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 修改或查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var teachingActivitiesList = teachingActivitiesService.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(teachingActivitiesList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 修改数据
        public ActionResult Update(GP_TeachingActivities teachingActivities2Model)
        {
            if (teachingActivitiesService.UpdateEntity(teachingActivities2Model))
            {
                return Content("教学活动信息更新成功");
            }
            else
            {
                return Content("教学活动信息更新失败");
            }

        } 
        #endregion
    }
}
