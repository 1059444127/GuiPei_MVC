using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IDAL
{
    public interface IDbSession
    {
        DbContext Db { get; }
        //ILoginDal LoginDal { get; set; }
        bool SaveChanges();
    }
}
