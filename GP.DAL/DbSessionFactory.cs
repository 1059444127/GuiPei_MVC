using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GP.IDAL;

namespace GP.DAL
{
   public class DbSessionFactory
    {
       public static IDbSession CreateDbSession()
       {
           IDAL.IDbSession DbSession = (IDAL.IDbSession)CallContext.GetData("dbSession");
           if (DbSession == null)
           {
               DbSession = new DbSession();
               CallContext.SetData("dbSession", DbSession);
           }
           return DbSession;
       }

    }
}
