using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.BLL;
using GP.IBLL;
using GP.Model;
using GP.Common;

namespace GP.UI.Portal.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        //ILoginService loginService = new LoginService();
        public ILoginService loginService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;
           
           byte[] buffer= validateCode.CreateValidateGraphic(code);//将验证吗画到画布上
           return File(buffer, "image/jpeg");

        }
        #endregion
        public ActionResult Download()
        {
            return Redirect("http://www.chinancd.net/index/download.html");
        }
        #region 登录
        public ActionResult DengLu()
        {
            string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("验证码输入错误");
            }
            //Session["validateCode"] = null;
            string txtCode = Request["txtCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("验证码输入错误");
            }
            string txtUserName = Request["txtUserName"];
            string txtPassword = Request["txtPassword"];
            var loginInfo = loginService.LoadEntities(u => u.name == txtUserName && u.password == txtPassword).FirstOrDefault();

            if (loginInfo != null)
            {
                if (loginInfo.LoginState.ToString() == "1")
                {
                    Session["loginInfo"] = loginInfo;
                    return Content("ok");

                }
                else
                {
                    return Content("账号已锁定，需管理员进行解锁登录");
                }

            }
            else
            {
                return Content("用户名或密码错误");
            }
        } 
        #endregion
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }


    }
}
