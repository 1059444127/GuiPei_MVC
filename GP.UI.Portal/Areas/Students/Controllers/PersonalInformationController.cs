using GP.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.IBLL;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class PersonalInformationController :BaseStudentsController
    {
        //
        // GET: /Students/PersonalInformation/
        public IGP_Professional_BaseService professionalBaseService { get; set; }
        public IGP_SchoolInformationService schoolInformationService { get; set; }

        public IGP_StudentsPersonalInformation2Service studentsPersonalInformation { get; set; }
        public ActionResult Index()
        {
            GP_Login loginInfo = Session["loginInfo"] as GP_Login;
            ViewBag.name = loginInfo.name;
            ViewBag.realname = loginInfo.real_name;
            ViewBag.trainingbasecode = loginInfo.training_base_code;
            ViewBag.trainingbasename = loginInfo.training_base_name;
            return View();
        }

        #region 头像上传
        
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files["Filedata"];

            if (file != null && file.ContentLength > 0)
            {

                string strfillName = Path.GetFileName(file.FileName);
                string strExt = Path.GetExtension(strfillName);
                string[] strExts = { ".jpg", ".png", ".bmp", ".gif", ".jpeg" };

                if (strExts.Contains(strExt))
                {
                    //string strSaveName = string.Empty;
                    //string strSavePath = ConvertImageByWH(context, file.InputStream, 60, 80, strExt, out strSaveName);
                    string strSavePath = ConvertImageByWH(file.InputStream, 120, 170, strExt, strfillName);


                    return Json(new { imgSrc = strSavePath }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { imgSrc = "0" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { imgSrc = "1" }, JsonRequestBehavior.AllowGet);//请选择头像进行上传
            }
        }

        /// <summary>
        /// 按照给定的宽高对图片进行压缩
        /// </summary>
        /// <param name="byteImg">图片字节流</param>
        /// <param name="intImgCompressWidth">压缩后的图片宽度</param>
        /// <param name="intImgCompressHeight">压缩后的图片高度</param>
        /// <param name="strExt">扩展名</param>
        /// <param name="strSaveName">保存后的名字</param>
        /// <returns>压缩后的图片相对路径</returns>
        private string ConvertImageByWH(Stream stream, int intImgCompressWidth, int intImgCompressHeight, string strExt, string strSaveName)
        {
            //从输入流中获取上传的image对象
            using (System.Drawing.Image img = System.Drawing.Image.FromStream(stream))
            {
                //根据压缩比例求出图片的宽度
                int intWidth = intImgCompressWidth / intImgCompressHeight * img.Height;
                int intHeight = img.Width * intImgCompressHeight / intImgCompressWidth;
                //画布
                using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(img, new Size(intImgCompressWidth, intImgCompressHeight)))
                {
                    //在画布上创建画笔对象
                    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
                    {
                        //将图片使用压缩后的宽高,从0，0位置画在画布上
                        graphics.DrawImage(img, 0, 0, intImgCompressWidth, intImgCompressHeight);
                        //创建保存路径
                        string strSavePath = "/UploadFile/images/";

                        //如果保存目录不存在，则创建
                        if (!Directory.Exists(Server.MapPath(strSavePath)))
                        {
                            Directory.CreateDirectory(Server.MapPath(strSavePath));
                        }
                        // //定义新的文件名
                        // string strfileNameNoExt = string.Empty;
                        // //接收参数
                        // string strId = context.Request.Params["strId"];
                        // if (!string.IsNullOrEmpty(strId))
                        //{
                        //    if (strId == "1")
                        //      {
                        //         //定义新的文件名
                        //       strfileNameNoExt = Guid.NewGuid().ToString();
                        //    }
                        // }

                        // strSaveName = strfileNameNoExt + strExt;
                        //添加时如果图片已经存在则删除
                        if (System.IO.File.Exists(Server.MapPath(strSavePath) + strSaveName))
                        {
                            System.IO.File.Delete(Server.MapPath(strSavePath) + strSaveName);
                        }
                        //保存文件
                        bitmap.Save(Server.MapPath(strSavePath) + strSaveName);
                        return strSavePath + strSaveName;
                    }
                }
            }
        } 
        #endregion

        #region 加载专业基地
        public ActionResult ProfessionalBase()
        {
            var professionalBaseList = professionalBaseService.LoadEntities(u=>true,a=>a.professional_base_code);
            return Json(professionalBaseList);
        }
        #endregion

        #region AutoComplete大学名称 
        public ActionResult SchoolName()
        {
            var schoolInformationEntities = schoolInformationService.LoadEntities(u=>true);
            return Json(schoolInformationEntities,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 保存或更新
        public ActionResult AddAndUpdate(GP_StudentsPersonalInformation2 personalInformation)
        {
            string name=Request.Form["Name"].ToString();

            if (studentsPersonalInformation.LoadEntities(u => u.Name == name) == null)
            {
                if (studentsPersonalInformation.AddEntity(personalInformation))
                {
                    return Content("0");//个人基本信息保存成功
                }
                else
                {
                    return Content("1");//个人基本信息保存失败
                }
            }
            else
            {
                if (studentsPersonalInformation.UpdateEntity(personalInformation))
                {
                    return Content("2");//个人基本信息更新成功
                }
                else
                {
                    return Content("3");//个人基本信息更新失败
                }
            }
            
                                
        }
        #endregion

        #region 加载基本信息
        public ActionResult LoadData()
        {
            string name = Request.QueryString["name"].ToString();
            var studentsInfo = studentsPersonalInformation.LoadEntities(u => u.Name == name);
            return Json(studentsInfo, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
