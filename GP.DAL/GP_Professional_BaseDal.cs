using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Model;
using GP.IDAL;
using System.Linq.Expressions;  
using System.Data.Entity;

namespace GP.DAL
{
    public partial class GP_Professional_BaseDal : BaseDal<GP_Professional_Base>, IGP_Professional_BaseDal
    {
        DbContext Db = DbContextFactory.CreateDbContext();
        public IQueryable<GP_Professional_Base> LoadEntities(Expression<Func<GP_Professional_Base, bool>> whereLambda,Expression<Func<GP_Professional_Base, string>> orderByLambda)
        {
            return Db.Set<GP_Professional_Base>().Where(whereLambda).OrderBy<GP_Professional_Base, string>(orderByLambda).AsQueryable();
        }
    }
}
