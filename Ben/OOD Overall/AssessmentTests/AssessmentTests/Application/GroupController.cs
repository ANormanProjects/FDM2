using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GroupController
    {


        public Dictionary<String, Trainee> diction { get; set; }

        DatabaseReader dbreader;

        DatabaseWriter dbwriter;


        public GroupController(DatabaseWriter dbwrite, DatabaseReader dbread)
        {
            dbwriter = dbwrite;
            dbreader = dbread;
            
        }



        public Dictionary<string, Trainee> GetAllTrainees()
        {
            return dbreader.ReadGroup();
        }

        public void AddTrainee(Trainee traineeToAdd)
        {
            dbwriter.AddTrainee(traineeToAdd);
        }

        public void RemoveTraineeByUsername(string username)
        {
            dbwriter.DeleteTraineeByUsername(username);
        }
    }
}
