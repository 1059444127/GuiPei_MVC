using GP.Common;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class BigMedicalRecordsController : BaseStudentsController
    {
        //
        // GET: /Students/BigMedicalRecords/

        IGP_BigMedicalRecords2Service bigMedicalRecords2Service { get; set; }

        public ActionResult Frame()
        {
            return View();
        }
        public ActionResult Body()
        {
            return View();
        }
        public ActionResult Top()
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

        #region 新增大病历信息登记
        public ActionResult Add(GP_BigMedicalRecords2 bigMedicalRecords2Model)
        {

            bigMedicalRecords2Model.RecordsStatus = "0";//尚未提交，为1时已成功提交
            bigMedicalRecords2Model.TeacherCheck = "未通过";
            bigMedicalRecords2Model.BaseCheck = "未通过";
            bigMedicalRecords2Model.KzrCheck = "未通过";
            bigMedicalRecords2Model.ManagerCheck = "未通过";
            if (bigMedicalRecords2Service.AddEntity(bigMedicalRecords2Model))
            {
                return Content("1");//大病历登记信息保存成功
            }
            else
            {
                return Content("0");//大病历登记信息保存失败
            }
            
        }
        #endregion

        #region 加载分页列表
        public ActionResult LeftToList(string DeptName, string TeachersRealName, string RegisterDate, string PatientName, string PatientNo, string InhospitalNo)
        {
            ViewData["DeptName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DeptName));
            ViewData["TeachersRealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(TeachersRealName));
            ViewData["RegisterDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RegisterDate));
            ViewData["PatientName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(PatientName));
            ViewData["PatientNo"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(PatientNo));
            ViewData["InhospitalNo"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(InhospitalNo));
            return View("List");
        }
        public ActionResult PageList()
        {
            string name = (Session["loginInfo"] as GP_Login).name.ToString();
            string trainingBaseCode = (Session["loginInfo"] as GP_Login).training_base_code.ToString();
            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string deptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["DeptName"]));
            string teachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["TeachersRealName"]));
            string registerDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RegisterDate"]));
            string patientName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["PatientName"]));
            string patientNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["PatientNo"]));
            string inhospitalNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["InhospitalNo"]));
            int totalCount = 0;

            ExpressionHelper<GP_BigMedicalRecords2> expression = new ExpressionHelper<GP_BigMedicalRecords2>();
            expression.Equal("StudentsName", name);
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            if (deptName != "")
            {
                expression.Contains("DeptName", deptName);
            }
            if (teachersRealName != "")
            {
                expression.Contains("TeachersRealName", teachersRealName);
            }
            if (registerDate != "")
            {
                expression.Equal("RegisterDate", registerDate);
            }
            if (patientName != "")
            {
                expression.Contains("PatientName", patientName);
            }
            if (patientNo != "")
            {
                expression.Equal("PatientNo", patientNo);
            }
            if (inhospitalNo != "")
            {
                expression.Equal("InhospitalNo", inhospitalNo);
            }
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var bigMedicalRecords2List = bigMedicalRecords2Service.LoadPageEntities<string>(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = bigMedicalRecords2List, totalCount, pageCount = PageCount });

        } 
        #endregion

        #region 提交大病历
        public ActionResult Handle()
        {
            string id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["id"]));
            string recordsStatus = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["recordsStatus"]));
            if (recordsStatus == "0")
            {
                recordsStatus = "1";
            }
            else
            {
                recordsStatus = "1";
            }

            GP_BigMedicalRecords2 bigMedicalRecords2Model = new GP_BigMedicalRecords2();
            bigMedicalRecords2Model.Id = id;
            bigMedicalRecords2Model.RecordsStatus = recordsStatus;
            if (bigMedicalRecords2Service.UpdateRecordsStatus(bigMedicalRecords2Model))
            {
                return Content("1");//大病历提交成功
            }
            else
            {
                return Content("0");//大病历提交失败
            }

        }
        #endregion

        #region 修改或查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var bigMedicalRecords2List = bigMedicalRecords2Service.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(bigMedicalRecords2List, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新大病历信息
        public ActionResult Update(GP_BigMedicalRecords2 bigMedicalRecords2Model)
        {
            if (bigMedicalRecords2Service.UpdateEntity(bigMedicalRecords2Model))
            {
                return Content("大病历信息更新成功");
            }
            else
            {
                return Content("大病历信息更新失败");
            }

        } 
        #endregion
    }
}
