using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
   public partial interface IGP_SkillRequirement2Service
    {
       bool UpdateSkillRequirement2(GP_SkillRequirement2 skillRequirement2Model);
       bool Handle(GP_SkillRequirement2 skillRequirement2Model);
    }
}
