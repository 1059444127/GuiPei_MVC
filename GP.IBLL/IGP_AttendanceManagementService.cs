using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
    public partial interface IGP_AttendanceManagementService : IBaseService<GP_AttendanceManagement>
    {
        bool Handle(GP_AttendanceManagement attendanceManagementModel);
    }
}
