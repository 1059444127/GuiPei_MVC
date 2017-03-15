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
    public class StudentsBigMedicalRecordsController : BaseTeachersController
    {
        //
        // GET: /Teachers/StudentsBigMedicalRecords/
        public IGP_BigMedicalRecords2Service bigMedicalRecords2Service { get; set; }
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
        public ActionResult LeftToList(string StudentsRealName, string PatientName, string PatientNo, string InhospitalNo)
        {
            ViewData["StudentsRealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(StudentsRealName));
            
            ViewData["PatientName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(PatientName));
            ViewData["PatientNo"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(PatientNo));
            ViewData["InhospitalNo"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(InhospitalNo));
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
            string PatientName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["PatientName"]));
            string PatientNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["PatientNo"]));
            string InhospitalNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["InhospitalNo"]));

            int totalCount = 0;

            ExpressionHelper<GP_BigMedicalRecords2> expression = new ExpressionHelper<GP_BigMedicalRecords2>();
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            expression.Equal("DeptCode", deptCode);
            expression.Equal("TeachersName", teachersName);
            if (StudentsRealName != "")
            {
                expression.Equal("StudentsRealName", StudentsRealName);
            }
            if (PatientName != "")
            {
                expression.Equal("PatientName", PatientName);
            }
            if (PatientNo != "")
            {
                expression.Equal("PatientNo", PatientNo);
            }
            if (InhospitalNo != "")
            {
                expression.Equal("InhospitalNo", InhospitalNo);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var bigMedicalRecords2List = bigMedicalRecords2Service.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = bigMedicalRecords2List, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 指导医师审核

        public ActionResult Handle()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string check = CommonFunc.SafeGetStringFromObj(Request["check"]);
            GP_BigMedicalRecords2 bigMedicalRecords2Model = new GP_BigMedicalRecords2();
            if (check == "未通过")
            {
                check = "已通过";
            }
            else
            {
                check = "未通过";
            }
            bigMedicalRecords2Model.Id = id;
            bigMedicalRecords2Model.TeacherCheck = check;

            if (bigMedicalRecords2Service.Handle(bigMedicalRecords2Model))
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
        #endregion

        #region 加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            var bigMedicalRecords2List = bigMedicalRecords2Service.LoadEntities(u => u.Id==id).FirstOrDefault();
            return Json(bigMedicalRecords2List, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 指导医师修正诊断
        public ActionResult XiuZheng()
        {
            string id = CommonFunc.SafeGetStringFromObj(Request["id"]);
            string xzzDuan = CommonFunc.SafeGetStringFromObj(Request["xzzDuan"]);
            string reviewer = CommonFunc.SafeGetStringFromObj(Request["reviewer"]);
            string reviewerDate = CommonFunc.SafeGetStringFromObj(Request["reviewerDate"]);
            GP_BigMedicalRecords2 bigMedicalRecords2Model = new GP_BigMedicalRecords2();
            bigMedicalRecords2Model.Id = id;
            bigMedicalRecords2Model.XZZDuan = xzzDuan;
            bigMedicalRecords2Model.Reviewer = reviewer;
            bigMedicalRecords2Model.ReviewerDate = reviewerDate;

            if (bigMedicalRecords2Service.xiuZhen(bigMedicalRecords2Model))
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
