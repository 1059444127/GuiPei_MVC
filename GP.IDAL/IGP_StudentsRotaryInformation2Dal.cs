using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IDAL
{
   public partial interface IGP_StudentsRotaryInformation2Dal:IBaseDal<GP_StudentsRotaryInformation2>
    {
       bool UpdateApplication(GP_StudentsRotaryInformation2 rotaryInfoModel);
    }
}
