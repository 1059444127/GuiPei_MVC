using GP.DAL;
using GP.IBLL;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.BLL
{
    public partial class GP_TeachingActivitiesService : BaseService<GP_TeachingActivities>, IGP_TeachingActivitiesService //crud
    {
        DbContext Db = DbContextFactory.CreateDbContext();
        #region 指导医师审核
        public bool Handle(GP_TeachingActivities teachingActivitiesModel)
        {
            Db.Set<GP_TeachingActivities>().Add(teachingActivitiesModel);
            DbEntityEntry<GP_TeachingActivities> entry = Db.Entry<GP_TeachingActivities>(teachingActivitiesModel);
            entry.State = EntityState.Unchanged;
            entry.Property(u => u.TeacherCheck).IsModified = true;

            return Db.SaveChanges() > 0;
        } 
        #endregion
    }
}
