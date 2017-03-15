using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GP.Model;
using GP.IBLL;
using System.Data;
using Aspose.Words;
using System.IO;
using GP.Common;
using Aspose.Words.Tables;

namespace GP.UI.Portal.Areas.Students.Controllers
{
    public class RotaryInformationController : BaseStudentsController
    {
        //
        // GET: /Students/RotaryInformation/

        public IGP_StudentsRotaryInformation2Service studentsRotaryInformation2 { set; get; }
        public IGP_QuestionnaireService questionnaireService { get; set; }
        public IGP_StudentsPersonalInformation2Service personalInfoService { get; set; }

        public IGP_RotaryScheduleService rotaryScheduleService { get; set; }
        public IGP_DeptManagementService deptManagementService { get; set; }
        #region Index
        /// <summary>
        /// 主页面下有left和list两个iframe
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        } 
        #endregion

        #region Left页面
        public ActionResult Left()
        {
            return View();
        } 
        #endregion

        #region List页面
        public ActionResult List()
        {
            GP_Login loginInfo = Session["loginInfo"] as GP_Login;

            ViewData["Name"] =CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(loginInfo.name));
            ViewData["RealName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(loginInfo.real_name));
            ViewData["TrainingBaseCode"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(loginInfo.training_base_code));
            ViewData["TrainingBaseName"] = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(loginInfo.training_base_name));
            return View();
        } 
        #endregion

        #region 加载轮转信息到List
        public ActionResult LoadRotaryInfo()
        {
            string Name = Request["Name"].ToString();
            string TrainingBaseCode = Request["TrainingBaseCode"].ToString();

            var rotaryInfoList = studentsRotaryInformation2.LoadOrderEntities(u => (u.Name == Name) && (u.TrainingBaseCode == TrainingBaseCode), u => u.RotaryOrder, true);

            return Json(rotaryInfoList, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 下载轮转表

        public ActionResult ToWord()
        {
            string Name = Request["Name"];
            string RealName = Request["RealName"];
            string TrainingBaseCode = Request["TrainingBaseCode"];
            string TrainingBaseName = Request["TrainingBaseName"];
            string templatePath = HttpContext.Server.MapPath(@"/RotaryTemplete/AsposeRotaryTemplete.docx");

            Document doc = new Document(templatePath);
            DocumentBuilder builder = new DocumentBuilder(doc);
            if (!System.IO.File.Exists(templatePath)) { return Content("0"); };//0:服务器没有模版
            var rotaryInfoList = studentsRotaryInformation2.LoadOrderEntities(u => (u.Name == Name) && (u.TrainingBaseCode == TrainingBaseCode), u => u.RotaryOrder, true);
            DataTable dt = CommonMethod.LINQToDataTable(rotaryInfoList);
            string  filename = "个人轮转表-" + dt.Rows[0]["RealName"] + ".doc";
            string outputPath = HttpContext.Server.MapPath(@"/RotaryWord/" + filename);
            int count = 0;

            for (var i = 0; i < dt.Columns.Count; i++)
            {
                if (doc.Range.Bookmarks[dt.Columns[i].ColumnName.Trim()] != null)
                {
                    Bookmark mark = doc.Range.Bookmarks[dt.Columns[i].ColumnName.Trim()];
                    mark.Text = "";
                    count++;
                }
            }
            System.Collections.Generic.List<string> listcolumn = new System.Collections.Generic.List<string>(count);
            for (var i = 0; i < count; i++)
            {
                builder.MoveToCell(0, 0, i, 0); //移动单元格
                if (builder.CurrentNode.NodeType == NodeType.BookmarkStart)
                {
                    listcolumn.Add((builder.CurrentNode as BookmarkStart).Name);
                }
            }
            double width = builder.CellFormat.Width;//获取单元格宽度
            builder.MoveToBookmark("table");        //开始添加值
            for (var m = 0; m < dt.Rows.Count; m++)
            {
                for (var i = 0; i < listcolumn.Count; i++)
                {
                    builder.InsertCell();            // 添加一个单元格                    
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                    builder.CellFormat.Width = width;
                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                    builder.Write(dt.Rows[m][listcolumn[i]].ToString());
                }
                builder.EndRow();
            }
            doc.Range.Bookmarks["table"].Text = "";    // 清掉标示  
            //doc.Save(filename, SaveFormat.Doc, SaveType.OpenInWord,context.Response);
            doc.Save(outputPath);
            //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", filename));
            //context.Response.WriteFile(outputPath);
           return Content(filename);
        }
        #endregion

        #region 申请出科

        public ActionResult OutDeptApplication()
        {
            string id = Request["Id"];
            GP_StudentsRotaryInformation2 rotaryInfoModel = new GP_StudentsRotaryInformation2();
            rotaryInfoModel.Id = id;
            rotaryInfoModel.OutdeptApplication = "1";

            if (studentsRotaryInformation2.UpdateApplication(rotaryInfoModel))
            {
                return Content("0");//0:申请出科考核成功，请耐心等待
            }
            else
            {
                return Content("1");//1:系统繁忙，请联系管理员
            }

        }
        #endregion

        #region 初始化问卷内容
        public ActionResult InitialQuestionnaire()
        {
            string id = Request["id"].ToString();
            var rotaryModel = studentsRotaryInformation2.LoadEntities(u=>u.Id==id);
            return Json(rotaryModel,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 提交问卷反馈
        public ActionResult SubmitQuestionnaire(GP_Questionnaire questionnaireModel)
        {
            string rotaryInfoId = Request["RotaryInfoId"].ToString();
            GP_StudentsRotaryInformation2 rotaryInfoModel = new GP_StudentsRotaryInformation2();
            rotaryInfoModel.Id = rotaryInfoId;
            rotaryInfoModel.QuestionnaireStatus = "1";

            if (questionnaireService.AddAndUpdateQS(questionnaireModel,rotaryInfoModel))
            {
                return Content("0");//添加成功
            }
            else
            {
                return Content("1");//添加失败
            }
           
        }
        #endregion

        #region 生成轮转信息
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPersonalInfo()
        {
            string Name = Request["Name"].ToString();
            string TrainingBaseCode = Request["TrainingBaseCode"].ToString();

            var personalInfoList = personalInfoService.LoadEntities(u => (u.Name == Name) && (u.TrainingBaseCode == TrainingBaseCode));
            if (personalInfoList == null)
            {
                return Content("0");//请完善个人基本信息
            }
            else
            {
                return Json(personalInfoList, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 从管理员那获得轮转信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRotaryInfo()
        {
            string TrainingBaseCode = Request["TrainingBaseCode"].ToString();
            string ProfessionalBaseCode = Request["ProfessionalBaseCode"].ToString();
            string TrainingTime = Request["TrainingTime"].ToString();

            var rotaryScheduleList = rotaryScheduleService.LoadEntities(u => (u.TrainingBaseCode == TrainingBaseCode) && (u.ProfessionalBaseCode == ProfessionalBaseCode) && (u.TrainingTime == TrainingTime));
            if (rotaryScheduleList == null)
            {
                return Content("0");//管理员尚未进行轮转排班
            }
            else
            {
                return Json(rotaryScheduleList, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 生成插入轮转信息
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertRotary()
        {
            string name = Request["name"];
            string realName = Request["realName"];
            string trainingBaseCode = Request["trainingBaseCode"];
            string trainingBaseName = Request["trainingBaseName"];
            string professionalBaseName = Request["professionalBaseName"];
            string professionalBaseCode = Request["professionalBaseCode"];
            string deptCodeList = Request["deptCodeList"];
            string deptNameList = Request["deptNameList"];
            string beginTimeList = Request["beginTimeList"];
            string endTimeList = Request["endTimeList"];
            string daysList = Request["daysList"];
            string outdeptStatus = Request["outdeptStatus"];
            string outdeptApplication = Request["outdeptApplication"];
            string questionnaireStatus =Request["questionnaireStatus"];
            string trainingTime =Request["trainingTime"];
            int length = Convert.ToInt16(Request["length"]);

            List<string> TeachersNameList = new List<string>();
            List<string> TeachersRealNameList = new List<string>();
            List<string> DeptCodeList = new List<string>();
            List<string> DeptNameList = new List<string>();
            List<string> BeginTimeList = new List<string>();
            List<string> EndTimeList = new List<string>();
            List<string> DaysList = new List<string>();

            foreach (string s in deptCodeList.Split('}'))
            {
                DeptCodeList.Add(s);
            }
            foreach (string s1 in deptNameList.Split('}'))
            {
                DeptNameList.Add(s1);
            }
            foreach (string s2 in beginTimeList.Split('}'))
            {
                BeginTimeList.Add(s2);
            }
            foreach (string s3 in endTimeList.Split('}'))
            {
                EndTimeList.Add(s3);
            }
            foreach (string s4 in daysList.Split('}'))
            {
                DaysList.Add(s4);
            }

            IQueryable<GP_DeptManagement> getTeachersList = deptManagementService.LoadEntities(u=>(u.TrainingBaseCode==trainingBaseCode)&&(u.ProfessionalBaseCode==professionalBaseCode)&&(u.TrainingTime==trainingTime));
            for (int j = 0; j < length; j++)
            {
                foreach (var item in getTeachersList)
                {
                    if (DeptCodeList[j] == item.DeptCode.ToString())
                    {
                        TeachersNameList.Add(item.Tag1.ToString());
                        TeachersRealNameList.Add(item.Tag2.ToString());
                    }
                }
            }

            GP_StudentsRotaryInformation2 studentsRotaryInformation2Model = new GP_StudentsRotaryInformation2();
            studentsRotaryInformation2Model.Name = name;
            studentsRotaryInformation2Model.RealName = realName;
            studentsRotaryInformation2Model.TrainingBaseCode = trainingBaseCode;
            studentsRotaryInformation2Model.TrainingBaseName = trainingBaseName;
            studentsRotaryInformation2Model.ProfessionalBaseCode = professionalBaseCode;
            studentsRotaryInformation2Model.ProfessionalBaseName = professionalBaseName;
            studentsRotaryInformation2Model.OutdeptStatus = outdeptStatus;
            studentsRotaryInformation2Model.OutdeptApplication = outdeptApplication;
            studentsRotaryInformation2Model.QuestionnaireStatus = questionnaireStatus;
            studentsRotaryInformation2Model.Tag1 = "0";
            if (studentsRotaryInformation2.Add(length, studentsRotaryInformation2Model, DeptCodeList, DeptNameList, BeginTimeList, EndTimeList, DaysList, TeachersNameList, TeachersRealNameList))
            {
                return Content("轮转信息生成成功");//轮转信息生成成功
            }
            else
            {
                return Content("轮转信息生成失败");//轮转信息生成失败
            }
                
        }
        #endregion

    }
}
