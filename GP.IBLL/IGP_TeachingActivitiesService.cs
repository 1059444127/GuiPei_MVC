using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
    public partial interface IGP_TeachingActivitiesService : IBaseService<GP_TeachingActivities>
    {
        bool Handle(GP_TeachingActivities teachingActivitiesModel);
    }
}
