using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.IDAL;
using GP.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GP.DAL
{
   public class LoginDal:BaseDal<GP_Login>,ILoginDal
    {
       DbContext Db = DbContextFactory.CreateDbContext();
      
       public bool UpdatePwd(GP_Login loginModel)
       {
           //将实体对象加入ef对象容器中，并获取未包装类对象
           DbEntityEntry<GP_Login> entry = Db.Entry<GP_Login>(loginModel);
           //EF跟踪这个对象的状态变化
           //Db.Set<GP_Login>().Attach(loginModel);

           //将未包装类对象状态设置为unchanged
           entry.State=EntityState.Unchanged;
           //设置被改变的属性
           entry.Property("password").IsModified = true;
           Db.SaveChanges();
           return true;
       }
    }
}
