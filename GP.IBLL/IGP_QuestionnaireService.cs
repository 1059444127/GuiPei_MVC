using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IBLL
{
    public partial interface IGP_QuestionnaireService : IBaseService<GP_Questionnaire>
    {
        bool AddAndUpdateQS(GP_Questionnaire questionnaireModel, GP_StudentsRotaryInformation2 rotaryInfoModel);
    }
}
