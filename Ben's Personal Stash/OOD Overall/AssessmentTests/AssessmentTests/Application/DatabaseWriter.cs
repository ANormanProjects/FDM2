using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface DatabaseWriter
    {
        void AddTrainee(Trainee traineeToAdd);
        void DeleteTraineeByUsername(string username);
    }
}
