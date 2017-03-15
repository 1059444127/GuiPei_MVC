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
    public partial class GP_BigMedicalRecords2Service : BaseService<GP_BigMedicalRecords2>, IGP_BigMedicalRecords2Service //crud
    {
        DbContext Db = DbContextFactory.CreateDbContext();

        #region 提交大病历  更新RecordsStatus字段
        public bool UpdateRecordsStatus(GP_BigMedicalRecords2 bigMedicalRecords2Model)
        {
            Db.Set<GP_BigMedicalRecords2>().Add(bigMedicalRecords2Model);
            DbEntityEntry<GP_BigMedicalRecords2> entry = Db.Entry<GP_BigMedicalRecords2>(bigMedicalRecords2Model);
            entry.State = EntityState.Unchanged;
            entry.Property(u => u.RecordsStatus).IsModified = true;
            return Db.SaveChanges() > 0;
        } 
        #endregion




        #region 指导医师  审核
        public bool Handle(GP_BigMedicalRecords2 bigMedicalRecords2Model)
        {
            Db.Set<GP_BigMedicalRecords2>().Add(bigMedicalRecords2Model);
            DbEntityEntry<GP_BigMedicalRecords2> entry = Db.Entry<GP_BigMedicalRecords2>(bigMedicalRecords2Model);
            entry.State = EntityState.Unchanged;
            entry.Property(u => u.TeacherCheck).IsModified = true;

            return Db.SaveChanges() > 0;
        } 
        #endregion




        #region 指导医师进行修正诊断
        public bool xiuZhen(GP_BigMedicalRecords2 bigMedicalRecords2Model)
        {
             Db.Set<GP_BigMedicalRecords2>().Add(bigMedicalRecords2Model);
            DbEntityEntry<GP_BigMedicalRecords2> entry = Db.Entry<GP_BigMedicalRecords2>(bigMedicalRecords2Model);
            entry.State = EntityState.Unchanged; 

            entry.Property(u => u.XZZDuan).IsModified = true;
            entry.Property(u => u.Reviewer).IsModified = true;
            entry.Property(u => u.ReviewerDate).IsModified = true;

            return Db.SaveChanges() > 0;
        } 
        #endregion
    }
}
