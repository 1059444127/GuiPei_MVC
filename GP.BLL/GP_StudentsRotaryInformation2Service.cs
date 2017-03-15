using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.DAL;
using GP.IDAL;
using GP.Model;
using GP.IBLL;

namespace GP.BLL
{
   public partial class GP_StudentsRotaryInformation2Service:BaseService<GP_StudentsRotaryInformation2>,IGP_StudentsRotaryInformation2Service
    {
       DbContext Db= DbContextFactory.CreateDbContext();
       public IGP_StudentsRotaryInformation2Dal studentsRotaryInfoDal { get; set; }

       public bool Add(int length, GP_StudentsRotaryInformation2 studentsRotaryInformation2Model, List<string> DeptCodeList, List<string> DeptNameList, List<string> BeginTimeList, List<string> EndTimeList, List<string> DaysList, List<string> TeachersNameList, List<string> TeachersRealNameList)
       {
           int i;
           for (i = 0; i < length; i++)
           {
               studentsRotaryInformation2Model.DeptCode = DeptCodeList[i];
               studentsRotaryInformation2Model.DeptName = DeptNameList[i];
               studentsRotaryInformation2Model.RotaryBeginTime = BeginTimeList[i];
               studentsRotaryInformation2Model.RotaryEndTime = EndTimeList[i];
               studentsRotaryInformation2Model.RotaryDays = DaysList[i];
               studentsRotaryInformation2Model.RotaryOrder = i;
               studentsRotaryInformation2Model.TeachersName = TeachersNameList[i];
               studentsRotaryInformation2Model.TeachersRealName = TeachersRealNameList[i];
               studentsRotaryInfoDal.AddEntity(studentsRotaryInformation2Model);

           }
           return Db.SaveChanges()>0;
       }

       public bool UpdateApplication(GP_StudentsRotaryInformation2 rotaryInfoModel)
       {
           return studentsRotaryInfoDal.UpdateApplication(rotaryInfoModel);
       }

    }
}
