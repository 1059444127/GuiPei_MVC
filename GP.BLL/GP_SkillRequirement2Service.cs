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
    public partial class GP_SkillRequirement2Service : BaseService<GP_SkillRequirement2>, IGP_SkillRequirement2Service
    {
       DbContext Db = DbContextFactory.CreateDbContext();

       #region 更新操作
       public bool UpdateSkillRequirement2(GP_SkillRequirement2 skillRequirement2Model)
       {
           Db.Set<GP_SkillRequirement2>().Add(skillRequirement2Model);
           DbEntityEntry<GP_SkillRequirement2> entry = Db.Entry<GP_SkillRequirement2>(skillRequirement2Model);
           entry.State = EntityState.Unchanged;
           entry.Property(u => u.SkillName).IsModified = true;
           entry.Property(u => u.PatientName).IsModified = true;
           entry.Property(u => u.CaseNum).IsModified = true;
           entry.Property(u => u.IsOk).IsModified = true;
           entry.Property(u => u.OperateDate).IsModified = true;
           entry.Property(u => u.Comment).IsModified = true;
           return Db.SaveChanges() > 0;
       }
       #endregion




       #region 指导医师审核
       public bool Handle(GP_SkillRequirement2 skillRequirement2Model)
       {
           Db.Set<GP_SkillRequirement2>().Add(skillRequirement2Model);
           DbEntityEntry<GP_SkillRequirement2> entry = Db.Entry<GP_SkillRequirement2>(skillRequirement2Model);
           entry.State = EntityState.Unchanged;
           entry.Property(u => u.TeacherCheck).IsModified = true;

           return Db.SaveChanges() > 0;
       } 
       #endregion
    }
}
