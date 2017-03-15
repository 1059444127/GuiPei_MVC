using GP.IBLL;
using GP.IDAL;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.BLL
{
    public partial class GP_QuestionnaireService : BaseService<GP_Questionnaire>, IGP_QuestionnaireService //crud
    {
        public IGP_QuestionnaireDal questionnaireDal { get; set; }

        public bool AddAndUpdateQS(GP_Questionnaire questionnaireModel, GP_StudentsRotaryInformation2 rotaryInfoModel)
        {
            return questionnaireDal.AddAndUpdateQS(questionnaireModel, rotaryInfoModel);
        }
    }
}
