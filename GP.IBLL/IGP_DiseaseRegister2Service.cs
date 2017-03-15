using GP.Model;
using GP.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
    public partial interface IGP_Disease_Register2Service : IBaseService<GP_Disease_Register2>
    {
        IQueryable<GP_Disease_Register2> LoadSearchEntities(DiseaseRegisterParam diseaseRegisterParam);
        bool UpdateDiseaseRegister2(GP_Disease_Register2 diseaseRegister2Model);
        bool Handle(GP_Disease_Register2 diseaseRegister2Model);
    }
}
