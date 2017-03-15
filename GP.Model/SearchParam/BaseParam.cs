using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Model.SearchParam
{
   public class BaseParam
    {
       public string Name { get; set; }
       public string TrainingBaseCode { get; set; }
       public int PageIndex { get; set; }
       public int PageSize { get;set; }
       public int TotalCount { get; set; }
    }
}
