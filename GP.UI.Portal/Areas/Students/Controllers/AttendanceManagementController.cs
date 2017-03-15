using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using GP.IBLL;
using GP.Common;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class AttendanceManagementController : BaseStudentsController
    {
        //
        // GET: /Students/AttendanceManagement/
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
        public ActionResult Manage()
        {
            return View();
        }
        #region 新增出勤记录
        public ActionResult Add(GP_AttendanceManagement attendanceManagementModel)
        {
            attendanceManagementModel.TeacherCheck = "未通过";
            attendanceManagementModel.BaseCheck = "未通过";
            attendanceManagementModel.KzrCheck = "未通过";
            attendanceManagementModel.ManagerCheck = "未通过";
            if (attendanceManagementService.AddEntity(attendanceManagementModel))
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

        public ActionResult LeftToList(string DeptName, string AttendanceCategory, string FirstDate, string LastDate, string Days)
        {
            ViewData["DeptName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DeptName));
            ViewData["AttendanceCategory"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(AttendanceCategory));
            ViewData["FirstDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(FirstDate));
            ViewData["LastDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(LastDate));
            ViewData["Days"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Days));
            return View("List");
        }

        public ActionResult PageList()
        {
            string name = (Session["loginInfo"] as GP_Login).name.ToString();
            string trainingBaseCode = (Session["loginInfo"] as GP_Login).training_base_code.ToString();
            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string deptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["DeptName"]));
            string attendanceCategory = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["AttendanceCategory"]));
            string firstDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["FirstDate"]));
            string lastDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["LastDate"]));
            string days = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["Days"]));
            int totalCount = 0;

            ExpressionHelper<GP_AttendanceManagement> expression = new ExpressionHelper<GP_AttendanceManagement>();
            expression.Equal("StudentsName", name);
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            if (deptName != "")
            {
                expression.Contains("DeptName", deptName);
            }
            if (attendanceCategory != "")
            {
                expression.Equal("AttendanceCategory", attendanceCategory);
            }
            if (firstDate != "")
            {
                expression.Equal("FirstDate", firstDate);
            }
            if (lastDate != "")
            {
                expression.Equal("LastDate", lastDate);
            }
            if (days != "")
            {
                expression.Equal("Days", days);
            }
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var attendanceManagementList = attendanceManagementService.LoadPageEntities<string>(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = attendanceManagementList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 修改或查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var attendanceManagementList = attendanceManagementService.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(attendanceManagementList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 修改数据
        public ActionResult Update(GP_AttendanceManagement attendanceManagementModel)
        {
            if (attendanceManagementService.UpdateEntity(attendanceManagementModel))
            {
                return Content("出勤记录信息更新成功");
            }
            else
            {
                return Content("出勤记录信息更新失败");
            }

        }
        #endregion
    }
}
