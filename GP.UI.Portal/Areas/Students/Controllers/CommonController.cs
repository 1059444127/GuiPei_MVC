using GP.IBLL;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Common;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class CommonController : BaseStudentsController
    {
        //
        // GET: /Common/
        public IGP_StudentsPersonalInformation2Service studentsPersonalInfoService { get; set; }
        public IGP_Professional_Base_DeptService professionalBaseDeptService { get; set; }
        public IGP_LoginService loginService { get; set; }
        public IGP_ProvinceService provinceService { get; set; }
        public IGP_CityService cityService { get; set; }
        public IGP_AreaService areaService { get; set; }

        #region 获取专业基地名称以及加载轮转科室
        /// <summary>
        /// 获取专业基地名称以及加载轮转科室
        /// </summary>
        /// <returns></returns>
        public ActionResult GetInfo()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            string name = loginModel.name == null ? "" : loginModel.name.ToString();
            string trainingBaseCode = loginModel.training_base_code == null ? "" : loginModel.training_base_code.ToString();
            var studentsPersonalInfoList = studentsPersonalInfoService.LoadEntities(u => (u.Name == name) && (u.TrainingBaseCode == trainingBaseCode)).FirstOrDefault();
            if (studentsPersonalInfoList == null)
            {
                return Json(new { msg = "0" }, JsonRequestBehavior.AllowGet);//个人基本信息未填写
            }
            else
            {
                string professionalBaseCode = studentsPersonalInfoList.ProfessionalBaseCode.ToString();

                var deptList = professionalBaseDeptService.LoadOrderEntities(u => u.professional_base_code == professionalBaseCode, u => u.dept_code, true);

                return Json(new { msg = "1", personalInfo = studentsPersonalInfoList, deptInfo = deptList }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 根据培训基地和科室获得指导医师
        public ActionResult GetTeachers()
        {
            string trainingBaseCode = Request["TrainingBaseCode"].ToString();
            string deptCode = Request["DeptCode"].ToString();
            var loginList = loginService.LoadEntities(u => (u.training_base_code == trainingBaseCode) && (u.dept_code == deptCode) && (u.type.Contains("teacher")));
            if (loginList == null)
            {
                return Json(new { msg = "0" }, JsonRequestBehavior.AllowGet);//尚无指导医师信息
            }
            else
            {
                return Json(new { msg = "1", teachersInfo = loginList }, JsonRequestBehavior.AllowGet);
            }
        } 
        #endregion

        #region 获取省市县
        public ActionResult Province()
        {
            var provinceList = provinceService.LoadEntities(u=>true);
            return Json(provinceList,JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult City()
        {
            string code=CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["father"])); 
            var cityList = cityService.LoadEntities(u =>u.father==code );
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Area()
        {
            string code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["father"])); 
            var areaList = areaService.LoadEntities(u => u.father==code);
            return Json(areaList, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

