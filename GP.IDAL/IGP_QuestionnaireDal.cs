using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.IDAL
{
    public partial interface IGP_QuestionnaireDal : IBaseDal<GP_Questionnaire>
    {
        bool AddAndUpdateQS(GP_Questionnaire questionnaireModel, GP_StudentsRotaryInformation2 rotaryInfoModel);
    }  
}
