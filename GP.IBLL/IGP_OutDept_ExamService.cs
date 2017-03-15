using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
    public partial interface IGP_OutDept_ExamService : IBaseService<GP_OutDept_Exam>
    {
        bool AddAndUpdate(GP_OutDept_Exam outDeptExamModel,GP_StudentsRotaryInformation2 studentsRotaryInformation2Model);
    }
}
