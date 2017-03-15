using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
    public partial interface IGP_BigMedicalRecords2Service : IBaseService<GP_BigMedicalRecords2>
    {
        bool UpdateRecordsStatus(GP_BigMedicalRecords2 bigMedicalRecords2Model);
        bool Handle(GP_BigMedicalRecords2 bigMedicalRecords2Model);

        bool xiuZhen(GP_BigMedicalRecords2 bigMedicalRecords2Model);
    }
}
