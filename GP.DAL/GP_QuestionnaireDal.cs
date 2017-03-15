using GP.IDAL;
using GP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.DAL
{
    public partial class GP_QuestionnaireDal : BaseDal<GP_Questionnaire>, IGP_QuestionnaireDal
    {
        DbContext Db = DbContextFactory.CreateDbContext();
        public bool AddAndUpdateQS(GP_Questionnaire questionnaireModel, GP_StudentsRotaryInformation2 rotaryInfoModel)
        {
            Db.Set<GP_Questionnaire>().Add(questionnaireModel);

            DbEntityEntry<GP_StudentsRotaryInformation2> entry = Db.Entry<GP_StudentsRotaryInformation2>(rotaryInfoModel); 
            entry.State = EntityState.Unchanged;
            entry.Property(u=>u.QuestionnaireStatus).IsModified = true;

            return Db.SaveChanges()>0;
        }
    }
}
