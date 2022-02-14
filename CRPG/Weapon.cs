using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace CRPG
{
    public class Weapon : Item
    {
        public int MaxDamage;
        public int MinDamage;

        public Weapon(int id, string name, string namePlural, int minDamage, int maxDamage): base(id,name,namePlural)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
    }
}
