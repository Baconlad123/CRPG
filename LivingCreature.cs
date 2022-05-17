using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CRPG
{
    public class LivingCreature
    {
        public int CurrentHitPoints;
        public int MaxHitPoints;

        public LivingCreature(int currentHitPoints, int maxHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaxHitPoints = maxHitPoints;
        }
        public LivingCreature()
        {

        }
    }
}
