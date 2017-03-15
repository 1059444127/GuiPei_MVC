using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Model;
using GP.IBLL;
using GP.IDAL;
using System.Linq.Expressions;

namespace GP.BLL
{
    public partial class GP_Professional_BaseService : BaseService<GP_Professional_Base>, IGP_Professional_BaseService
    {
        public IGP_Professional_BaseDal professionalBaseDal { get; set; }
        public IQueryable<GP_Professional_Base> LoadEntities(Expression<Func<GP_Professional_Base, bool>> whereLambda, Expression<Func<GP_Professional_Base, string>> orderByLambda)
        {
            return professionalBaseDal.LoadEntities(whereLambda, orderByLambda);
        }
    }
}
