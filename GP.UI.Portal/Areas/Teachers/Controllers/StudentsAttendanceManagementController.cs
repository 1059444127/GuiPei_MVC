using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Common;
using GP.Model;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class StudentsAttendanceManagementController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsAttendanceManagement/
        public IGP_AttendanceManagementService attendanceManagementService { get; set; }
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

        public ActionResult LeftToList(string StudentsRealName, string AttendanceCategory, string FirstDate, string LastDate, string Days)
        {
            ViewData["StudentsRealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(StudentsRealName));
            ViewData["AttendanceCategory"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(AttendanceCategory));
            ViewData["FirstDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(FirstDate));
            ViewData["LastDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(LastDate));
            ViewData["Days"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Days));
            
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
            string AttendanceCategory = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["AttendanceCategory"]));
            string FirstDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["FirstDate"]));
            string LastDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["LastDate"]));
            string Days = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["Days"]));
            int totalCount = 0;

            ExpressionHelper<GP_AttendanceManagement> expression = new ExpressionHelper<GP_AttendanceManagement>();
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            expression.Equal("DeptCode", deptCode);
            expression.Equal("TeacherId", teachersName);
            if (StudentsRealName != "")
            {
                expression.Equal("StudentsRealName", StudentsRealName);
            }
            if (AttendanceCategory != "")
            {
                expression.Equal("AttendanceCategory", AttendanceCategory);
            }
            if (FirstDate != "")
            {
                expression.Equal("FirstDate", FirstDate);
            }
            if (LastDate != "")
            {
                expression.Equal("LastDate", LastDate);
            }
            if (Days != "")
            {
                expression.Contains("Days", Days);
            }
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var attendanceManagementList = attendanceManagementService.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = attendanceManagementList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 指导医师审核

        public ActionResult Handle()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string check = CommonFunc.SafeGetStringFromObj(Request["check"]);
            GP_AttendanceManagement attendanceManagementModel = new GP_AttendanceManagement();
            if (check == "未通过")
            {
                check = "已通过";
            }
            else
            {
                check = "未通过";
            }
            attendanceManagementModel.Id = id;
            attendanceManagementModel.TeacherCheck = check;

            if (attendanceManagementService.Handle(attendanceManagementModel))
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
        #endregion
    }
}
