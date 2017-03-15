using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using GP.IBLL;
using GP.Common;
using System.IO;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class NewsController : BaseStudentsController
    {
        //
        // GET: /Students/News/
        public IGP_ReleaseNewsService releaseNewsService { get; set; }
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

        public ActionResult LeftToList(string NewsTitle,  string RegisterDate)
        {
            ViewData["NewsTitle"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(NewsTitle));
            ViewData["RegisterDate"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RegisterDate));
            return View("List");
        }

        public ActionResult PageList()
        {
            string trainingBaseCode = (Session["loginInfo"] as GP_Login).training_base_code.ToString();
            int pageIndex = Request["pi"] != null ? int.Parse(Request["pi"]) : 1;
            int pageSize = GP.Common.Const.pageSize;
            string newsTitle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["NewsTitle"]));
            string registerDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["RegisterDate"]));
            int totalCount = 0;

            //ExpressionHelper<GP_ReleaseNews> expression = new ExpressionHelper<GP_ReleaseNews>();

            //expression.Equal("TrainingBaseCode", trainingBaseCode);
            //expression.Equal("Students", "1");
            //if (newsTitle != "")
            //{
            //    expression.StartsWith("NewsTitle", newsTitle);
            //}
            //if (registerDate != "")
            //{
            //    expression.StartsWith("RegisterDate", registerDate);
            //}

            //var releaseNewsList = releaseNewsService.LoadPageEntities<string>(pageSize, pageIndex, out totalCount,
            //    expression.GetExpression(),
            //    u => u.RegisterDate, false);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var releaseNewsList = releaseNewsService.LoadPageEntities<string>(pageSize, pageIndex, out totalCount,
                u => (u.TrainingBaseCode == trainingBaseCode) &&
                    (u.Students == "1") &&
                    (newsTitle == "" ? true : u.NewsTitle.Contains(newsTitle)) &&
                    (registerDate == "" ? true : u.RegisterDate.StartsWith(registerDate)),
                u => u.RegisterDate, false);

            int PageCount = Convert.ToInt32(Math.Ceiling((double)totalCount / pageSize));

            return Json(new { data = releaseNewsList, totalCount, pageCount = PageCount });

        }
        #endregion

        #region 查看时加载数据
        public ActionResult LoadData()
        {
            string id = CommonFunc.FilterSpecialString((CommonFunc.SafeGetStringFromObj(Request["id"])));
            var releaseNewsList = releaseNewsService.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(releaseNewsList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 文件下载
        public ActionResult Download()
        {
            string FileName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["FileName"]));
            string FilePath = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request["FilePath"]));
            string absoluFilePath = Server.MapPath(FilePath + FileName);
            return File(new FileStream(absoluFilePath, FileMode.Open), "application/octet-stream", Server.UrlEncode(FileName));
        }
        #endregion
    }
}
