using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.IBLL;
using GP.Model;
using GP.Model.SearchParam;
using GP.Common;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class DiseaseRegisterController : BaseStudentsController
    {
        //
        // GET: /Students/DiseaseRegister/
        public IGP_Disease_RegisterService diseaseRegisterService { get; set; }
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

        #region 加载病种名称
        public ActionResult LoadDisease()
        {
            string deptcode = Request["DeptCode"].ToString();
            var diseaseList = diseaseRegisterService.LoadEntities(u => u.disease_code.StartsWith(deptcode));
            return Json(diseaseList, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 新增病种登记
        public ActionResult Add(GP_Disease_Register2 diseaseRegister2Model)
        {
            diseaseRegister2Model.teacher_check = "未通过";
            diseaseRegister2Model.base_check = "未通过";
            diseaseRegister2Model.kzr_check = "未通过";
            diseaseRegister2Model.manage_check = "未通过";
            if (diseaseRegister2Service.AddEntity(diseaseRegister2Model))
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
        
        public ActionResult LeftToList(string DeptName,string DiseaseName,string RequiredNum,string MasterDegree)
        {
            ViewData["DeptName"] =CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DeptName));
            ViewData["DiseaseName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DiseaseName));
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
            string diseaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["DiseaseName"]));
            string requiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RequiredNum"]));
            string masterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["MasterDegree"]));
            int totalCount = 0;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            DiseaseRegisterParam diseaseRegisterParam = new DiseaseRegisterParam()
            {
                Name = name,
                TrainingBaseCode = trainingBaseCode,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                DeptName = deptName,
                DiseaseName = diseaseName,
                RequiredNum = requiredNum,
                MasterDegree = masterDegree
            };
            var diseaseRegisterList = diseaseRegister2Service.LoadSearchEntities(diseaseRegisterParam);
            int PageCount = Convert.ToInt32(Math.Ceiling((double)diseaseRegisterParam.TotalCount/pageSize));
            return Json(new { data=diseaseRegisterList,totalCount=diseaseRegisterParam.TotalCount,pageCount=PageCount});

        }
        #endregion

        #region 修改或查看时加载数据
        public ActionResult LoadData()
        {
            string id=CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var diseaseRegisterList=diseaseRegister2Service.LoadEntities(u=>u.id==id).FirstOrDefault();
            return Json(diseaseRegisterList,JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 修改数据
        public ActionResult Update()
        {
            string id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["id"]));
            string disease_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["disease_name"]));
            string patient_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["patient_name"]));
            string case_num = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["case_num"]));
            string main_diagnosis = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["main_diagnosis"]));
            string secondary_diagnosis = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["secondary_diagnosis"]));
            string is_charge = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["is_charge"]));
            string is_rescue = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["is_rescue"]));
            string cure_measure = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["cure_measure"]));
            string visit_date = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["visit_date"]));
            string condition = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["condition"]));
            string comment = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["comment"]));

            GP_Disease_Register2 diseaseRegister2Model = new GP_Disease_Register2();
            diseaseRegister2Model.id = id;
            diseaseRegister2Model.disease_name = disease_name;
            diseaseRegister2Model.patient_name = patient_name;
            diseaseRegister2Model.case_num = case_num;
            diseaseRegister2Model.main_diagnosis = main_diagnosis;
            diseaseRegister2Model.secondary_diagnosis = secondary_diagnosis;
            diseaseRegister2Model.is_charge = is_charge;
            diseaseRegister2Model.is_rescue = is_rescue;
            diseaseRegister2Model.cure_measure = cure_measure;
            diseaseRegister2Model.visit_date = visit_date;
            diseaseRegister2Model.condition = condition;
            diseaseRegister2Model.comment = comment;

            if (diseaseRegister2Service.UpdateDiseaseRegister2(diseaseRegister2Model))
            {
                return Content("病种信息修改成功");
            }
            else
            {
                return Content("病种信息修改失败");
            }
        }
        #endregion


    }
}
