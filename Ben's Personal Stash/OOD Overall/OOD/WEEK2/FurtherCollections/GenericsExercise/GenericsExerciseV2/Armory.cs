using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExerciseV2
{
    public abstract class Armory
    {
        public int id { get; set; }
        public string name { get; set; }

    }

    public class Axe : Armory
    {
        public int blades { get; set; }
    }

    public class Sword : Armory
    {
        public int length { get; set; }
    }

    public class Hammer : Armory
    {
        public int weight { get; set; }
    }
}
