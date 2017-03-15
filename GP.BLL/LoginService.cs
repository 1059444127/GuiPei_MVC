using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.DAL;
using GP.IBLL;
using GP.IDAL;
using GP.Model;

namespace GP.BLL
{
   public class LoginService:BaseService<GP_Login>,ILoginService
    {
       
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = CurrentDbSession.LoginDal; 
        //}

        //批量删除
       //public bool DeleteEntities(List<int> list)
       //{
       //    var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
       //    foreach (var userInfo in userInfoList)
       //    {
       //        this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
       //    }
       //    return this.CurrentDBSession.SaveChanges();
       //}
       public ILoginDal loginDal { get; set; }
       public bool UpdatePwd(GP_Login loginModel)
       {
         return loginDal.UpdatePwd(loginModel);
          
       }
    }
}
