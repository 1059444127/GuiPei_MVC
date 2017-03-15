 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.IDAL;
using GP.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GP.DAL
{
   
		
	public partial class GP_AdviceFeedbackDal:BaseDal<GP_AdviceFeedback>,IGP_AdviceFeedbackDal
    {
	}
		
	public partial class GP_AreaDal:BaseDal<GP_Area>,IGP_AreaDal
    {
	}
		
	public partial class GP_AttendanceManagementDal:BaseDal<GP_AttendanceManagement>,IGP_AttendanceManagementDal
    {
	}
		
	public partial class GP_BigMedicalRecords2Dal:BaseDal<GP_BigMedicalRecords2>,IGP_BigMedicalRecords2Dal
    {
	}
		
	public partial class GP_CityDal:BaseDal<GP_City>,IGP_CityDal
    {
	}
		
	public partial class GP_DeptManagementDal:BaseDal<GP_DeptManagement>,IGP_DeptManagementDal
    {
	}
		
	public partial class GP_Disease_RegisterDal:BaseDal<GP_Disease_Register>,IGP_Disease_RegisterDal
    {
	}
		
	public partial class GP_Disease_Register2Dal:BaseDal<GP_Disease_Register2>,IGP_Disease_Register2Dal
    {
	}
		
	public partial class GP_LoginDal:BaseDal<GP_Login>,IGP_LoginDal
    {
	}
		
	public partial class GP_NeiKeOptionDal:BaseDal<GP_NeiKeOption>,IGP_NeiKeOptionDal
    {
	}
		
	public partial class GP_OutDept_ExamDal:BaseDal<GP_OutDept_Exam>,IGP_OutDept_ExamDal
    {
	}
		
	public partial class GP_Professional_BaseDal:BaseDal<GP_Professional_Base>,IGP_Professional_BaseDal
    {
	}
		
	public partial class GP_Professional_Base_DeptDal:BaseDal<GP_Professional_Base_Dept>,IGP_Professional_Base_DeptDal
    {
	}
		
	public partial class GP_ProvinceDal:BaseDal<GP_Province>,IGP_ProvinceDal
    {
	}
		
	public partial class GP_QuestionnaireDal:BaseDal<GP_Questionnaire>,IGP_QuestionnaireDal
    {
	}
		
	public partial class GP_ReleaseNewsDal:BaseDal<GP_ReleaseNews>,IGP_ReleaseNewsDal
    {
	}
		
	public partial class GP_RotaryScheduleDal:BaseDal<GP_RotarySchedule>,IGP_RotaryScheduleDal
    {
	}
		
	public partial class GP_SchoolInformationDal:BaseDal<GP_SchoolInformation>,IGP_SchoolInformationDal
    {
	}
		
	public partial class GP_SkillRequirementDal:BaseDal<GP_SkillRequirement>,IGP_SkillRequirementDal
    {
	}
		
	public partial class GP_SkillRequirement2Dal:BaseDal<GP_SkillRequirement2>,IGP_SkillRequirement2Dal
    {
	}
		
	public partial class GP_StudentsPersonalInformation2Dal:BaseDal<GP_StudentsPersonalInformation2>,IGP_StudentsPersonalInformation2Dal
    {
	}
		
	public partial class GP_StudentsRotaryInformation2Dal:BaseDal<GP_StudentsRotaryInformation2>,IGP_StudentsRotaryInformation2Dal
    {
	}
		
	public partial class GP_Teachers_Appoint_InformationDal:BaseDal<GP_Teachers_Appoint_Information>,IGP_Teachers_Appoint_InformationDal
    {
	}
		
	public partial class GP_TeachingActivitiesDal:BaseDal<GP_TeachingActivities>,IGP_TeachingActivitiesDal
    {
	}
		
	public partial class GP_TiKuResultDal:BaseDal<GP_TiKuResult>,IGP_TiKuResultDal
    {
	}
		
	public partial class RotaryInformationJoinDal:BaseDal<RotaryInformationJoin>,IRotaryInformationJoinDal
    {
	}


}