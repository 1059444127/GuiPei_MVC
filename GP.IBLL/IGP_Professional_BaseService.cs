using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Model;
using System.Linq.Expressions;

namespace GP.IBLL
{
    public partial interface IGP_Professional_BaseService : IBaseService<GP_Professional_Base>
    {
        IQueryable<GP_Professional_Base> LoadEntities(Expression<Func<GP_Professional_Base, bool>> whereLambda, Expression<Func<GP_Professional_Base, string>> orderByLambda);
    }
}
