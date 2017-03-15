using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.DAL;
using GP.IDAL;
using System.Linq.Expressions;

namespace GP.BLL
{
   public abstract class BaseService<T> where T:class ,new ()
    {

       public IDbSession CurrentDbSession
       {
           get
           {
               // return new DBSession();//暂时
               return DbSessionFactory.CreateDbSession();
           }
       }

       DbContext Db = DbContextFactory.CreateDbContext();
        public IDAL.IBaseDal<T> CurrentDal { get; set; }
        //public abstract void SetCurrentDal();

        //public IDbSession CurrentDbSession { get; set; }

        //public BaseService()
        //{
        //    SetCurrentDal();//子类一定要实现抽象方法。
        //}
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {

            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadOrderEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.LoadOrderEntities(whereLambda,orderByLambda,isAsc);
           
        }
        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex , out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<S>(pageSize, pageIndex, out totalCount, whereLambda, orderbyLambda, isAsc);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            //return CurrentDbSession.SaveChanges();
            return Db.SaveChanges()>0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            CurrentDal.UpdateEntity(entity);
            //return CurrentDbSession.SaveChanges();
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            //CurrentDbSession.SaveChanges();
           return Db.SaveChanges()>0;
        }
    }
}
