using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExerciseV2
{
    public class Shop<T> where T : Armory
    {
        List<T> weapons = new List<T>();
        
        public void AddWeapon(T storeweapons)
        {
            weapons.Add(storeweapons);
        }

        public T FindWeapon(int id)
        {
            foreach (T Weapon in weapons)
            {
                if (Weapon.id == id)
                {
                    return Weapon;
                }
            }
            return null;  
        }
        
    }
}
