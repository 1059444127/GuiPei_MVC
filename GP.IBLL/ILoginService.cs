using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Model;

namespace GP.IBLL
{
    public interface ILoginService:IBaseService<GP_Login>
    {
        bool UpdatePwd(GP_Login loginModel);
    }
}
