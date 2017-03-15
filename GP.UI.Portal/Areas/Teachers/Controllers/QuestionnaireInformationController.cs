using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Common;
using GP.Model;
using GP.IBLL;
using Spring.Expressions.Processors;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class QuestionnaireInformationController : BaseTeachersController
    {
        //
        // GET: /Teachers/QuestionnaireInformation/
        public IGP_QuestionnaireService questionnaireService { get; set; }
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
        #region 满意度调查反馈表格数据
        public ActionResult List()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string trainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            string deptCode = CommonFunc.SafeGetStringFromObj(loginModel.dept_code);
            string teachersRealName = CommonFunc.SafeGetStringFromObj(loginModel.real_name);

            var questionnaireList = questionnaireService.LoadEntities(u => (u.training_base_code == trainingBaseCode) &&
                (u.rotary_dept_code == deptCode) && (u.instructor == teachersRealName));
            ViewBag.sum = questionnaireList.Count();

            ViewBag.one_a = (from u in questionnaireList where u.one == "A" select u).Count();
            ViewBag.one_b = (from u in questionnaireList where u.one == "B" select u).Count();
            ViewBag.one_c = (from u in questionnaireList where u.one == "C" select u).Count();
            ViewBag.one_d = (from u in questionnaireList where u.one == "D" select u).Count();
            ViewBag.one_e = (from u in questionnaireList where u.one == "E" select u).Count();

            ViewBag.two_a = (from u in questionnaireList where u.two == "A" select u).Count();
            ViewBag.two_b = (from u in questionnaireList where u.two == "B" select u).Count();
            ViewBag.two_c = (from u in questionnaireList where u.two == "C" select u).Count();
            ViewBag.two_d = (from u in questionnaireList where u.two == "D" select u).Count();
            ViewBag.two_e = (from u in questionnaireList where u.two == "E" select u).Count();

            ViewBag.three_a = (from u in questionnaireList where u.three == "A" select u).Count();
            ViewBag.three_b = (from u in questionnaireList where u.three == "B" select u).Count();
            ViewBag.three_c = (from u in questionnaireList where u.three == "C" select u).Count();
            ViewBag.three_d = (from u in questionnaireList where u.three == "D" select u).Count();
            ViewBag.three_e = (from u in questionnaireList where u.three == "E" select u).Count();

            ViewBag.four_a = (from u in questionnaireList where u.four == "A" select u).Count();
            ViewBag.four_b = (from u in questionnaireList where u.four == "B" select u).Count();
            ViewBag.four_c = (from u in questionnaireList where u.four == "C" select u).Count();
            ViewBag.four_d = (from u in questionnaireList where u.four == "D" select u).Count();
            ViewBag.four_e = (from u in questionnaireList where u.four == "E" select u).Count();

            ViewBag.five_a = (from u in questionnaireList where u.five == "A" select u).Count();
            ViewBag.five_b = (from u in questionnaireList where u.five == "B" select u).Count();
            ViewBag.five_c = (from u in questionnaireList where u.five == "C" select u).Count();
            ViewBag.five_d = (from u in questionnaireList where u.five == "D" select u).Count();
            ViewBag.five_e = (from u in questionnaireList where u.five == "E" select u).Count();

            ViewBag.six_a = (from u in questionnaireList where u.six == "A" select u).Count();
            ViewBag.six_b = (from u in questionnaireList where u.six == "B" select u).Count();
            ViewBag.six_c = (from u in questionnaireList where u.six == "C" select u).Count();
            ViewBag.six_d = (from u in questionnaireList where u.six == "D" select u).Count();
            ViewBag.six_e = (from u in questionnaireList where u.six == "E" select u).Count();

            ViewBag.seven_a = (from u in questionnaireList where u.seven == "A" select u).Count();
            ViewBag.seven_b = (from u in questionnaireList where u.seven == "B" select u).Count();
            ViewBag.seven_c = (from u in questionnaireList where u.seven == "C" select u).Count();
            ViewBag.seven_d = (from u in questionnaireList where u.seven == "D" select u).Count();
            ViewBag.seven_e = (from u in questionnaireList where u.seven == "E" select u).Count();

            ViewBag.eight_a = (from u in questionnaireList where u.eight == "A" select u).Count();
            ViewBag.eight_b = (from u in questionnaireList where u.eight == "B" select u).Count();
            ViewBag.eight_c = (from u in questionnaireList where u.eight == "C" select u).Count();
            ViewBag.eight_d = (from u in questionnaireList where u.eight == "D" select u).Count();
            ViewBag.eight_e = (from u in questionnaireList where u.eight == "E" select u).Count();

            ViewBag.nine_a = (from u in questionnaireList where u.nine == "A" select u).Count();
            ViewBag.nine_b = (from u in questionnaireList where u.nine == "B" select u).Count();
            ViewBag.nine_c = (from u in questionnaireList where u.nine == "C" select u).Count();
            ViewBag.nine_d = (from u in questionnaireList where u.nine == "D" select u).Count();
            ViewBag.nine_e = (from u in questionnaireList where u.nine == "E" select u).Count();

            ViewBag.ten_a = (from u in questionnaireList where u.ten == "A" select u).Count();
            ViewBag.ten_b = (from u in questionnaireList where u.ten == "B" select u).Count();
            ViewBag.ten_c = (from u in questionnaireList where u.ten == "C" select u).Count();
            ViewBag.ten_d = (from u in questionnaireList where u.ten == "D" select u).Count();
            ViewBag.ten_e = (from u in questionnaireList where u.ten == "E" select u).Count();

            ViewBag.eleven_a = (from u in questionnaireList where u.eleven == "A" select u).Count();
            ViewBag.eleven_b = (from u in questionnaireList where u.eleven == "B" select u).Count();
            ViewBag.eleven_c = (from u in questionnaireList where u.eleven == "C" select u).Count();
            ViewBag.eleven_d = (from u in questionnaireList where u.eleven == "D" select u).Count();
            ViewBag.eleven_e = (from u in questionnaireList where u.eleven == "E" select u).Count();

            ViewBag.twelve_a = (from u in questionnaireList where u.twelve == "A" select u).Count();
            ViewBag.twelve_b = (from u in questionnaireList where u.twelve == "B" select u).Count();
            ViewBag.twelve_c = (from u in questionnaireList where u.twelve == "C" select u).Count();
            ViewBag.twelve_d = (from u in questionnaireList where u.twelve == "D" select u).Count();
            ViewBag.twelve_e = (from u in questionnaireList where u.twelve == "E" select u).Count();

            ViewBag.thirteen_a = (from u in questionnaireList where u.thirteen == "A" select u).Count();
            ViewBag.thirteen_b = (from u in questionnaireList where u.thirteen == "B" select u).Count();
            ViewBag.thirteen_c = (from u in questionnaireList where u.thirteen == "C" select u).Count();
            ViewBag.thirteen_d = (from u in questionnaireList where u.thirteen == "D" select u).Count();
            ViewBag.thirteen_e = (from u in questionnaireList where u.thirteen == "E" select u).Count();

            return View();
        } 
        #endregion

        #region 加载分页列表

        public ActionResult PageList()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string trainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            string deptCode = CommonFunc.SafeGetStringFromObj(loginModel.dept_code);
            string teachersRealName = CommonFunc.SafeGetStringFromObj(loginModel.real_name);

            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = 5; 
            int totalCount = 0;

            ExpressionHelper<GP_Questionnaire> expression = new ExpressionHelper<GP_Questionnaire>();
            expression.Equal("training_base_code", trainingBaseCode);
            expression.Equal("rotary_dept_code", deptCode);
            expression.Equal("instructor", teachersRealName);
            
            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            var questionnaireList = questionnaireService.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.register_date, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = questionnaireList, totalCount, pageCount = PageCount });

        }
        #endregion
    }
}
