using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.IBLL;
using GP.Model;
using GP.Common;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class AdviceFeedbackController : BaseStudentsController
    {
        //
        // GET: /Students/AdviceFeedback/
        public IGP_AdviceFeedbackService adviceFeedbackService { get; set; }

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
        public ActionResult Manage()
        {
            return View();
        }
        #region 新增意见反馈
        public ActionResult Add(GP_AdviceFeedback adviceFeedbackModel)
        {
            adviceFeedbackModel.TeacherCheck = "未通过";
            adviceFeedbackModel.BaseCheck = "未通过";
            adviceFeedbackModel.KzrCheck = "未通过";
            adviceFeedbackModel.ManagerCheck = "未通过";
            adviceFeedbackModel.ManagerHandle = "未处理";
            if (adviceFeedbackService.AddEntity(adviceFeedbackModel))
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

        public ActionResult LeftToList(string DeptName, string ManagerHandle, string RegisterDate)
        {
            ViewData["DeptName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(DeptName));
            ViewData["ManagerHandle"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ManagerHandle));
            ViewData["RegisterDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RegisterDate));
            return View("List");
        }

        public ActionResult PageList()
        {
            string name = (Session["loginInfo"] as GP_Login).name.ToString();
            string trainingBaseCode = (Session["loginInfo"] as GP_Login).training_base_code.ToString();
            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string deptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["DeptName"]));
            string managerHandle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["ManagerHandle"]));
            string registerDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RegisterDate"]));
            int totalCount = 0;

            ExpressionHelper<GP_AdviceFeedback> expression = new ExpressionHelper<GP_AdviceFeedback>();
            expression.Equal("StudentsName", name);
            expression.Equal("TrainingBaseCode", trainingBaseCode);
            if (deptName != "")
            {
                expression.Contains("DeptName", deptName);
            }
            if (managerHandle != "")
            {
                expression.Contains("ManagerHandle", managerHandle);
            }
            if (registerDate != "")
            {
                expression.Equal("RegisterDate", registerDate);
            }

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var adviceFeedbackList = adviceFeedbackService.LoadPageEntities<string>(pageSize, pageIndex, out totalCount, expression.GetExpression(), u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = adviceFeedbackList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 修改或查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var adviceFeedbackList = adviceFeedbackService.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(adviceFeedbackList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 修改数据
        public ActionResult Update(GP_AdviceFeedback adviceFeedbackModel)
        {
            if (adviceFeedbackService.UpdateEntity(adviceFeedbackModel))
            {
                return Content("意见反馈信息更新成功");
            }
            else
            {
                return Content("意见反馈信息更新失败");
            }

        }
        #endregion

        #region 删除数据
        public ActionResult Del()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            GP_AdviceFeedback adviceFeedbackModel = new GP_AdviceFeedback() { Id=id};
            if (adviceFeedbackService.DeleteEntity(adviceFeedbackModel))
            {
                return Content("1");//意见反馈信息删除成功
            }
            else
            {
                return Content("0");//意见反馈信息删除失败
            }
            
        }
        #endregion
    }
}
