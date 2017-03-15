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
    public class StudentsDiseaseRegisterController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsDiseaseRegister/
        public IGP_Disease_Register2Service diseaseRegister2Service { get; set; }
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

        public ActionResult LeftToList(string students_real_name, string disease_name, string required_num, string master_degree)
        {
            ViewData["students_real_name"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(students_real_name));
            ViewData["disease_name"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(disease_name));
            ViewData["required_num"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(required_num));
            ViewData["master_degree"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(master_degree));

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
            string disease_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["disease_name"]));
            string required_num = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["required_num"]));
            string master_degree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["master_degree"]));

            int totalCount = 0;

            ExpressionHelper<GP_Disease_Register2> expression = new ExpressionHelper<GP_Disease_Register2>();
            expression.Equal("training_base_code", trainingBaseCode);
            expression.Equal("dept_code", deptCode);
            expression.Equal("TeacherId", teachersName);
            if (students_real_name != "")
            {
                expression.Equal("students_real_name", students_real_name);
            }
            if (disease_name != "")
            {
                expression.Contains("disease_name", disease_name);
            }
            if (required_num != "")
            {
                expression.Equal("required_num", required_num);
            }
            if (master_degree != "")
            {
                expression.Contains("master_degree", master_degree);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var diseaseRegister2List = diseaseRegister2Service.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.register_date, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = diseaseRegister2List, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 指导医师审核

        public ActionResult Handle()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string check = CommonFunc.SafeGetStringFromObj(Request["check"]);
            GP_Disease_Register2 diseaseRegister2Model = new GP_Disease_Register2();
            if (check == "未通过")
            {
                check = "已通过";
            }
            else
            {
                check = "未通过";
            }
            diseaseRegister2Model.id = id;
            diseaseRegister2Model.teacher_check = check;

            if (diseaseRegister2Service.Handle(diseaseRegister2Model))
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
        #endregion

        #region 查看时加载数据

        public ActionResult LoadData() {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);

            var diseaseRegister2List = diseaseRegister2Service.LoadEntities(u=>u.id==id).FirstOrDefault();

            return Json(diseaseRegister2List,JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
