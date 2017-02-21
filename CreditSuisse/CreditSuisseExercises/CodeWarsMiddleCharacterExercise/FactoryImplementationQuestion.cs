using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace CreditSuisseExercises
{
    public class FactoryImplementation1
    {
        public Position CreateNewPosition(int id)
        {
            switch (id)
            {
                case 0: return new Manager();
                case 1: return new Clerk();
                case 2: return new Clerk();
                case 3: return new Programmer();
            }
            throw new EntityNotFoundException();
        }

    }

    public class FactoryImplementation2
    {
        public Position CreateNewPosition(int id)
        {            
            var test = Type.GetType(ConfigurationManager.AppSettings["0"]);

            var answer1 = Activator.CreateInstance(Type.GetType("CreditSuisseExercises." + ConfigurationManager.AppSettings["0"]));
            var answer2 = Activator.CreateInstance(Type.GetType("CreditSuisseExercises." + ConfigurationManager.AppSettings["1"]));
            var answer3 = Activator.CreateInstance(Type.GetType("CreditSuisseExercises." + ConfigurationManager.AppSettings["2"]));
            var answer4 = Activator.CreateInstance(Type.GetType("CreditSuisseExercises." + ConfigurationManager.AppSettings["3"]));

            switch (id)
            {
                case 0: return answer1 as Position;
                case 1: return answer2 as Position;
                case 2: return answer3 as Position;
                case 3: return answer4 as Position;
            }
            throw new EntityNotFoundException();
        }

    }
}
