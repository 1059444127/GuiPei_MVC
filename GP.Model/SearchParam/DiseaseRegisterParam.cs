using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Model.SearchParam
{
    public class DiseaseRegisterParam:BaseParam
    {
        public string DeptName { get; set; }
        public string DiseaseName { get; set; }
        public string RequiredNum { get; set; }
        public string MasterDegree { get; set; }
    }
}
