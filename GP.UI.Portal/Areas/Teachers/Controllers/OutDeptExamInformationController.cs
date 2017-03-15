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
    public class OutDeptExamInformationController : BaseTeachersController
    {
        //
        // GET: /Teachers/OutDeptExamInformation/
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

        public ActionResult LeftToList(string students_real_name, string rotary_begin_time, string rotary_end_time, string total_score)
        {
            ViewData["students_real_name"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(students_real_name));
            ViewData["rotary_begin_time"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(rotary_begin_time));
            ViewData["rotary_end_time"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(rotary_end_time));
            ViewData["total_score"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(total_score));
            
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
            string students_real_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["students_real_name"]));
            string rotary_begin_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["rotary_begin_time"]));
            string rotary_end_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["rotary_end_time"]));
            string total_score = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["total_score"]));
            int totalCount = 0;

            ExpressionHelper<GP_OutDept_Exam> expression = new ExpressionHelper<GP_OutDept_Exam>();
            expression.Equal("training_base_code", trainingBaseCode);
            expression.Equal("rotary_dept_code", deptCode);
            expression.Equal("instructor_tag", teachersName);
            if (students_real_name != "")
            {
                expression.Equal("students_real_name", students_real_name);
            }
            if (rotary_begin_time != "")
            {
                expression.Equal("rotary_begin_time", rotary_begin_time);
            }
            if (rotary_end_time != "")
            {
                expression.Equal("rotary_end_time", rotary_end_time);
            }
            if (total_score != "")
            {
                expression.Equal("total_score", total_score);
            }
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var outDeptExamList = outDeptExamService.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.instructor_date, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = outDeptExamList, totalCount, pageCount = PageCount });

        }
        #endregion

    }
}
