using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GP.Model;

namespace GP.DAL
{
   public class DbContextFactory
    {
       public static DbContext CreateDbContext()
       {
           DbContext dbContext=CallContext.GetData("dbContext") as DbContext;
           if (dbContext == null)
           {
               dbContext=new GP_SystemEntities();
               CallContext.SetData("dbContext",dbContext);
           }
           return dbContext;
       }
    }
}
