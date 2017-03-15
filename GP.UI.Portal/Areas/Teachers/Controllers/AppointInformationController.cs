using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using GP.Common;
using GP.Model;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class AppointInformationController : BaseTeachersController
    {
        //
        // GET: /Teachers/AppointInformation/
        public IGP_Teachers_Appoint_InformationService teachersAppointInformationService { get; set; }
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
        #region 新增界面初始化信息
        public ActionResult Manage()
        {
            GP_Login loginModel = Session["loginInfo"] as GP_Login;
            ViewData["teachers_real_name"] = CommonFunc.SafeGetStringFromObj(loginModel.real_name);
            ViewData["teachers_name"] = CommonFunc.SafeGetStringFromObj(loginModel.name);
            ViewData["training_base_code"] = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
            ViewData["training_base_name"] = CommonFunc.SafeGetStringFromObj(loginModel.training_base_name);
            ViewData["professional_base_code"] = CommonFunc.SafeGetStringFromObj(loginModel.professional_base_code);
            ViewData["professional_base_name"] = CommonFunc.SafeGetStringFromObj(loginModel.professional_base_name);
            ViewData["dept_code"] = CommonFunc.SafeGetStringFromObj(loginModel.dept_code);
            ViewData["dept_name"] = CommonFunc.SafeGetStringFromObj(loginModel.dept_name);
            ViewData["register_date"] = DateTime.Now.Date.ToString("yyyy-MM-dd");
            ViewData["id"] = Guid.NewGuid().ToString();
            ViewData["IsReceive"] = "未接收";
            ViewData["is_pass"] = "未通过";
            ViewData["type"] = "指导医师";
            return View();
        } 
        #endregion

        #region 指导医师上传附件

        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files["uploadFile"];
            string filePath = "/UploadFile/teachers/";
            if (file != null && file.ContentLength > 0)
            {
                if (!Directory.Exists(Server.MapPath(filePath)))
                {
                    Directory.CreateDirectory(Server.MapPath(filePath));
                }

                string fileName = Path.GetFileName(file.FileName);
                string strExt = Path.GetExtension(fileName);
                string[] strExts = { ".doc", ".docx", ".ppt", ".pptx", ".xls", ".xlsx", ".pdf", ".rar", ".zip" };
                if (strExts.Contains(strExt))
                {
                    if (System.IO.File.Exists(Server.MapPath(filePath) + fileName))
                    {
                       System.IO.File.Delete(Server.MapPath(filePath) + fileName);
                    } 
                    file.SaveAs(Server.MapPath(filePath) + fileName); 
                    return Json(new { message ="2",filename=fileName,filepath=filePath});//2：文件上传成功
                }
                else
                {
                    return Json(new { message = "0" });//0：请选择格式为:doc、docx、ppt、pptx、xls、xlsx、pdf、rar、zip的文件进行上传
                }

            }
            else
            {
                return Json(new { message="1"});//1：请选择文件进行上传
            }
        }
        #endregion

        #region 加载分页列表

        public ActionResult LeftToList(string appoint_begin_time, string appoint_end_time, string is_pass)
        {
            ViewData["appoint_begin_time"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(appoint_begin_time));
            ViewData["appoint_end_time"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(appoint_end_time));
            ViewData["is_pass"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(is_pass));
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
            string appoint_begin_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["appoint_begin_time"]));
            string appoint_end_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["appoint_end_time"]));
            string is_pass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["is_pass"])); 
            int totalCount = 0;

            ExpressionHelper<GP_Teachers_Appoint_Information> expression = new ExpressionHelper<GP_Teachers_Appoint_Information>();
            expression.Equal("training_base_code", trainingBaseCode);
            expression.Equal("dept_code", deptCode);
            expression.Equal("teachers_name", teachersName);
            if (appoint_begin_time != "")
            {
                expression.Contains("appoint_begin_time", appoint_begin_time);
            }
            if (appoint_end_time != "")
            {
                expression.Contains("appoint_end_time", appoint_end_time);
            }
            if (is_pass != "")
            {
                expression.Contains("is_pass", is_pass);
            } 
            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            var teachersAppointInformationList = teachersAppointInformationService.LoadPageEntities(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.register_date, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = teachersAppointInformationList, totalCount, pageCount = PageCount });

        }
        #endregion


        #region 新增预约信息
        public ActionResult Save(GP_Teachers_Appoint_Information teachersAppointInformationModel)
        {
            if (string.IsNullOrEmpty(teachersAppointInformationModel.teachers_real_name))
            {
                return Json(new { status = "error", message = "指导医师不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.dept_name))
            {
                return Json(new { status = "error", message = "所在科室不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.appoint_begin_time))
            {
                return Json(new { status = "error", message = "预约开始时间不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.appoint_end_time))
            {
                return Json(new { status = "error", message = "预约结束时间不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.total_num))
            {
                return Json(new { status = "error", message = "培训总人数不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.training_content))
            {
                return Json(new { status = "error", message = "培训内容不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.register_date))
            {
                return Json(new { status = "error", message = "登记日期不能为空" });
            }
            else
            {
                if (teachersAppointInformationService.AddEntity(teachersAppointInformationModel))
                {
                    return Json(new { status = "ok", message = "预约信息提交成功" });
                }
                else
                {
                    return Json(new { status = "ok", message = "预约信息提交失败" });
                }
            }
        }
        #endregion

        #region 查看加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var teachersAppointInformationList = teachersAppointInformationService.LoadEntities(u => u.id == id).FirstOrDefault();
            return Json(teachersAppointInformationList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改数据
        public ActionResult Update(GP_Teachers_Appoint_Information teachersAppointInformationModel)
        {
            if (string.IsNullOrEmpty(teachersAppointInformationModel.teachers_real_name))
            {
                return Json(new { status = "error", message = "指导医师不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.dept_name))
            {
                return Json(new { status = "error", message = "所在科室不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.appoint_begin_time))
            {
                return Json(new { status = "error", message = "预约开始时间不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.appoint_end_time))
            {
                return Json(new { status = "error", message = "预约结束时间不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.total_num))
            {
                return Json(new { status = "error", message = "培训总人数不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.training_content))
            {
                return Json(new { status = "error", message = "培训内容不能为空" });
            }
            else if (string.IsNullOrEmpty(teachersAppointInformationModel.register_date))
            {
                return Json(new { status = "error", message = "登记日期不能为空" });
            }
            else
            {
                if (teachersAppointInformationService.UpdateEntity(teachersAppointInformationModel))
                {
                    return Json(new { status = "ok", message = "预约信息更新成功" });
                }
                else
                {
                    return Json(new { status = "ok", message = "预约信息更新失败" });
                }
            }
        }
        #endregion
    }
}
