using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
   public partial interface IGP_StudentsRotaryInformation2Service:IBaseService<GP_StudentsRotaryInformation2>
    {
       bool UpdateApplication(GP_StudentsRotaryInformation2 rotaryInfoModel);
       bool Add(int length, GP_StudentsRotaryInformation2 studentsRotaryInformation2Model, List<string> DeptCodeList, List<string> DeptNameList, List<string> BeginTimeList, List<string> EndTimeList, List<string> DaysList, List<string> TeachersNameList, List<string> TeachersRealNameList);
    }
}
