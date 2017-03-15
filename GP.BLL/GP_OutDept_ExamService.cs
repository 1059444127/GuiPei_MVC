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
    public partial class GP_OutDept_ExamService : BaseService<GP_OutDept_Exam>, IGP_OutDept_ExamService //crud
    {
        DbContext Db = DbContextFactory.CreateDbContext();
        public bool AddAndUpdate(GP_OutDept_Exam outDeptExamModel, GP_StudentsRotaryInformation2 studentsRotaryInformation2Model)
        {
            //出科状态修改
            Db.Set<GP_StudentsRotaryInformation2>().Add(studentsRotaryInformation2Model);
            DbEntityEntry<GP_StudentsRotaryInformation2> entry = Db.Entry<GP_StudentsRotaryInformation2>(studentsRotaryInformation2Model);
            entry.State = EntityState.Unchanged;
            entry.Property(u => u.OutdeptStatus).IsModified = true;
            //新增考核
            Db.Set<GP_OutDept_Exam>().Add(outDeptExamModel);

            return Db.SaveChanges() > 0;
        }
    }
}
