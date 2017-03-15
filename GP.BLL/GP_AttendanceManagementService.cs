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
    public partial class GP_AttendanceManagementService : BaseService<GP_AttendanceManagement>, IGP_AttendanceManagementService //crud
    {
        DbContext Db = DbContextFactory.CreateDbContext();
        public bool Handle(GP_AttendanceManagement attendanceManagementModel)
        {
            Db.Set<GP_AttendanceManagement>().Add(attendanceManagementModel);
            DbEntityEntry<GP_AttendanceManagement> entry = Db.Entry<GP_AttendanceManagement>(attendanceManagementModel);
            entry.State = EntityState.Unchanged;
            entry.Property(u => u.TeacherCheck).IsModified = true;

            return Db.SaveChanges() > 0;
        }
    }
}
