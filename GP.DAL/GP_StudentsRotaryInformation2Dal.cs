using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.IDAL;
using System.Data.Entity;
using GP.Model;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace GP.DAL
{
  public partial  class GP_StudentsRotaryInformation2Dal:BaseDal<GP_StudentsRotaryInformation2>,IGP_StudentsRotaryInformation2Dal
    {
        DbContext Db = DbContextFactory.CreateDbContext();

        public bool UpdateApplication(GP_StudentsRotaryInformation2 rotaryInfoModel)
        {
            DbEntityEntry<GP_StudentsRotaryInformation2> entry = Db.Entry<GP_StudentsRotaryInformation2>(rotaryInfoModel);
            
            entry.State = EntityState.Unchanged;
            
            entry.Property(u=>u.OutdeptApplication).IsModified = true;
            Db.SaveChanges();
            return true;
        }
    }
}
