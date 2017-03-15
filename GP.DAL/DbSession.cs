using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.IDAL;

namespace GP.DAL
{
   public class DbSession:IDbSession
    {

        public DbContext Db
        {
            get
            {
                return DbContextFactory.CreateDbContext();
            }
        }
        //DbContext Db = DBContextFactory.CreateDbContext();
        #region 抽象工厂封装了类的实例的创建
        //private ILoginDal _LoginDal;
        //public ILoginDal LoginDal
        //{
        //    get
        //    {
        //        if (_LoginDal == null)
        //        {
        //            //_UserInfoDal = new UserInfoDal();
        //            _LoginDal = AbstractFactory.CreateLoginDal();//通过抽象工厂封装了类的实例的创建
        //        }
        //        return _LoginDal;
        //    }
        //    set
        //    {
        //        _LoginDal = value;
        //    }
        //} 
        #endregion
        /// <summary>
        /// 一个业务中经常涉及到对多张操作，我们希望链接一次数据库，完成对张表数据的操作。提高性能。 工作单元模式。
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
