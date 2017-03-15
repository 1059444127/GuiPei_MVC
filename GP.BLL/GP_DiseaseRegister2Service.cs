using GP.IBLL;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.DAL;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace GP.BLL
{
    public partial class GP_Disease_Register2Service : BaseService<GP_Disease_Register2>, IGP_Disease_Register2Service
    {
        DbContext Db = DbContextFactory.CreateDbContext();

        #region 多条件搜索
        /// <summary>
        /// 多条件搜索
        /// </summary>
        /// <param name="diseaseRegisterParam"></param>
        /// <returns></returns>
        public IQueryable<GP_Disease_Register2> LoadSearchEntities(Model.SearchParam.DiseaseRegisterParam diseaseRegisterParam)
        {
            var temp = CurrentDal.LoadEntities(u => (u.students_name == diseaseRegisterParam.Name) && (u.training_base_code == diseaseRegisterParam.TrainingBaseCode));
            if (!string.IsNullOrEmpty(diseaseRegisterParam.DeptName))
            {
                temp = temp.Where<GP_Disease_Register2>(u => u.dept_name.Contains(diseaseRegisterParam.DeptName));
            }
            if (!string.IsNullOrEmpty(diseaseRegisterParam.DiseaseName))
            {
                temp = temp.Where<GP_Disease_Register2>(u => u.disease_name.Contains(diseaseRegisterParam.DiseaseName));
            }
            if (!string.IsNullOrEmpty(diseaseRegisterParam.RequiredNum))
            {
                temp = temp.Where<GP_Disease_Register2>(u => u.required_num == diseaseRegisterParam.RequiredNum);
            }
            if (!string.IsNullOrEmpty(diseaseRegisterParam.MasterDegree))
            {
                temp = temp.Where<GP_Disease_Register2>(u => u.master_degree.Contains(diseaseRegisterParam.MasterDegree));
            }
            diseaseRegisterParam.TotalCount = temp.Count();
            return temp.OrderByDescending<GP_Disease_Register2, string>(u => u.register_date).Skip<GP_Disease_Register2>((diseaseRegisterParam.PageIndex - 1) * diseaseRegisterParam.PageSize).Take<GP_Disease_Register2>(diseaseRegisterParam.PageSize);

        } 
        #endregion

       #region 更新操作
        public bool UpdateDiseaseRegister2(GP_Disease_Register2 diseaseRegister2Model)
        {
            Db.Set<GP_Disease_Register2>().Add(diseaseRegister2Model);
            DbEntityEntry<GP_Disease_Register2> entry = Db.Entry<GP_Disease_Register2>(diseaseRegister2Model);
            entry.State = EntityState.Unchanged;
            entry.Property(u=>u.disease_name).IsModified = true;
            entry.Property(u => u.patient_name).IsModified = true;
            entry.Property(u => u.case_num).IsModified = true;
            entry.Property(u => u.main_diagnosis).IsModified = true;
            entry.Property(u => u.secondary_diagnosis).IsModified = true;
            entry.Property(u => u.is_charge).IsModified = true;
            entry.Property(u => u.is_rescue).IsModified = true; 
            entry.Property(u => u.cure_measure).IsModified = true; 
            entry.Property(u => u.visit_date).IsModified = true;
            entry.Property(u => u.condition).IsModified = true;
            entry.Property(u => u.comment).IsModified = true;
            return Db.SaveChanges()>0;
        } 
        #endregion




        #region 指导医师审核
        public bool Handle(GP_Disease_Register2 diseaseRegister2Model)
        {
            Db.Set<GP_Disease_Register2>().Add(diseaseRegister2Model);
            DbEntityEntry<GP_Disease_Register2> entry = Db.Entry<GP_Disease_Register2>(diseaseRegister2Model);
            entry.State = EntityState.Unchanged;
            entry.Property(u => u.teacher_check).IsModified = true;

            return Db.SaveChanges() > 0;
        } 
        #endregion
    }
}
