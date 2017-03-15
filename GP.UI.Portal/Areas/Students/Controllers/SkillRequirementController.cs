using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using GP.Common;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class SkillRequirementController : BaseStudentsController
    {
        //
        // GET: /Students/SkillRequirement/
        public IGP_SkillRequirementService skillRequirementService { get; set; }
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
        //public ActionResult Index()
        //{
        //    return View();
        //}

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
        #region 加载技能名称
        public ActionResult LoadSkill()
        {
            string deptcode = Request["DeptCode"].ToString();
            var skillList = skillRequirementService.LoadEntities(u => u.SkillCode.StartsWith(deptcode));
            return Json(skillList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 新增技能登记
        public ActionResult Add(GP_SkillRequirement2 skillRequirement2Model)
        {
            skillRequirement2Model.TeacherCheck = "未通过";
            skillRequirement2Model.BaseCheck = "未通过";
            skillRequirement2Model.KzrCheck = "未通过";
            skillRequirement2Model.ManagerCheck = "未通过";
            if (skillRequirement2Service.AddEntity(skillRequirement2Model))
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

        public ActionResult LeftToList(string DeptName, string SkillName, string RequiredNum, string MasterDegree)
        {
            ViewData["DeptName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DeptName));
            ViewData["SkillName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(SkillName));
            ViewData["RequiredNum"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RequiredNum));
            ViewData["MasterDegree"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(MasterDegree));
            return View("List");
        }

        public ActionResult PageList()
        {
            string name = (Session["loginInfo"] as GP_Login).name.ToString();
            string trainingBaseCode = (Session["loginInfo"] as GP_Login).training_base_code.ToString();
            int pageIndex = Request["PageIndex"] != null ? int.Parse(Request["PageIndex"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string deptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["DeptName"]));
            string skillName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["SkillName"]));
            string requiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RequiredNum"]));
            string masterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["MasterDegree"]));
            int totalCount = 0;

            ExpressionHelper<GP_SkillRequirement2> expression = new ExpressionHelper<GP_SkillRequirement2>();
            expression.Equal("StudentsName", name);
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            if (deptName != "")
            {
                expression.Contains("DeptName", deptName);
            }
            if (skillName != "")
            {
                expression.Contains("SkillName", skillName);
            }
            if (requiredNum != "")
            {
                expression.Equal("RequiredNum", requiredNum);
            }
            if (masterDegree != "")
            {
                expression.Contains("MasterDegree", masterDegree);
            }
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var skillRequirementList = skillRequirement2Service.LoadPageEntities<string>(pageSize,pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);
            
            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = skillRequirementList, totalCount, pageCount = PageCount });
           
        }
        #endregion

        #region 修改或查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var diseaseRegisterList = skillRequirement2Service.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(diseaseRegisterList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 修改数据
        public ActionResult Update()
        {
            string Id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["Id"]));
            string SkillName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["SkillName"]));
            string PatientName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["PatientName"]));
            string CaseNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["CaseNum"]));
            string IsOk = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["IsOk"]));
            string OperateDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["OperateDate"]));
            string Comment = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["Comment"]));

            GP_SkillRequirement2 skillRequirement2Model = new GP_SkillRequirement2();
            skillRequirement2Model.Id = Id;
            skillRequirement2Model.SkillName = SkillName;
            skillRequirement2Model.PatientName = PatientName;
            skillRequirement2Model.CaseNum = CaseNum;
            skillRequirement2Model.IsOk = IsOk;
            skillRequirement2Model.OperateDate = OperateDate;
            skillRequirement2Model.Comment = Comment;

            if (skillRequirement2Service.UpdateSkillRequirement2(skillRequirement2Model))
            {
                return Content("技能操作信息修改成功");
            }
            else
            {
                return Content("技能操作信息修改成功");
            }
        }
        #endregion
    }
}
