using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using System.IO;
using GP.IBLL;
using GP.Common;

namespace GP.UI.Portal.Controllers
{
    public class TagController : BaseController
    {
        //
        // GET: /Main/
        public ILoginService loginService { get; set; }
        #region 加载标识页
        public ActionResult Index()
        {
            GP_Login loginInfo = Session["loginInfo"] as GP_Login;
            ViewBag.title = loginInfo.training_base_name;
            string type = loginInfo.type.ToString();
            string[] identity = type.Split('_');
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (string i in identity)
            {
                if (i == "students")
                {
                    listItem.Add(new SelectListItem { Text = "学员", Value = "students" });
                }
                else if (i == "teachers")
                {
                    listItem.Add(new SelectListItem { Text = "指导医师", Value = "teachers" });
                }
                else if (i == "bases")
                {
                    listItem.Add(new SelectListItem { Text = "专业基地负责人", Value = "bases" });
                }
                else
                {
                    listItem.Add(new SelectListItem { Text = "管理员", Value = "managers" });
                }
            }

            ViewData["List"] = new SelectList(listItem, "Value", "Text", "");


            return View();
        } 
        #endregion

        [HttpPost]
        public ActionResult Frame()
        {
            string role =CommonFunc.SafeGetStringFromObj(Request["role"]);
            ViewData["role"] = role;
            var loginInfo = Session["loginInfo"];
            ViewData.Model = loginInfo;
            return View();
        }
             
        public ActionResult LeftFrame()
        {
            string role=CommonFunc.SafeGetStringFromObj(Request.QueryString["role"]);
            ViewData["role"] = role;
            return View();
        }
        public ActionResult MainFrame()
        {
            return View();
        }
        public ActionResult DownLoad(string fileName)
        {
            string absoluFilePath = Server.MapPath("/index/download/"+fileName);
            return File(new FileStream(absoluFilePath, FileMode.Open), "application/octet-stream", Server.UrlEncode(fileName));
        }
        [HttpGet]
        public ActionResult ModifyPassword()
        {
            TempData["name"] = Request.QueryString["name"];
            return View();
        }
        [HttpPost]
        public ActionResult ModifyPassword(FormCollection form)
        {
            GP_Login loginModel=new GP_Login();
            string name= TempData["name"].ToString();
            string txtPwd = form["txtPwd"].ToString();
            string txtConfirmPwd = form["txtConfirmPwd"].ToString();
            if (txtPwd.Equals(txtConfirmPwd))
            {
                loginModel.name = name;
                loginModel.password=txtPwd;
                if (loginService.UpdatePwd(loginModel))
                {
                    return Content("0");
                }
                else
                {
                    return Content("1");
                }
            }
            else
            {
                return Content("2");
            }
        }
    }
}
