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
    public class StudentsSkillRequirementController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsSkillRequirement/
        public IGP_SkillRequirement2Service skillRequirement2Service { get; set; }
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

        public ActionResult LeftToList(string StudentsRealName, string SkillName, string RequiredNum, string MasterDegree)
        {
            ViewData["StudentsRealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(StudentsRealName));
            ViewData["SkillName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(SkillName));
            ViewData["RequiredNum"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RequiredNum));
            ViewData["MasterDegree"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(MasterDegree));

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
            string SkillName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["SkillName"]));
            string RequiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RequiredNum"]));
            string MasterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["MasterDegree"]));

            int totalCount = 0;

            ExpressionHelper<GP_SkillRequirement2> expression = new ExpressionHelper<GP_SkillRequirement2>();
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            expression.Equal("DeptCode", deptCode);
            expression.Equal("TeacherId", teachersName);
            if (StudentsRealName != "")
            {
                expression.Equal("StudentsRealName", StudentsRealName);
            }
            if (SkillName != "")
            {
                expression.Contains("SkillName", SkillName);
            }
            if (RequiredNum != "")
            {
                expression.Equal("RequiredNum", RequiredNum);
            }
            if (MasterDegree != "")
            {
                expression.Contains("MasterDegree", MasterDegree);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var skillRequirement2List = skillRequirement2Service.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = skillRequirement2List, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 指导医师审核

        public ActionResult Handle()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string check = CommonFunc.SafeGetStringFromObj(Request["check"]);
            GP_SkillRequirement2 skillRequirement2Model = new GP_SkillRequirement2();
            if (check == "未通过")
            {
                check = "已通过";
            }
            else
            {
                check = "未通过";
            }
            skillRequirement2Model.Id = id;
            skillRequirement2Model.TeacherCheck = check;

            if (skillRequirement2Service.Handle(skillRequirement2Model))
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

            var skillRequirement2List = skillRequirement2Service.LoadEntities(u=>u.Id==id).FirstOrDefault();

            return Json(skillRequirement2List,JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
    
}
