using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CRPG
{
    public class Monster:LivingCreature
    {
        public int ID;
        public string Name;
        public int MaxDamage;
        public int RewardXP;
        public int RewardGold;
        public List<LootItem> LootTable;

        public Monster(int iD, string name, int maxDamage, int rewardXP, int rewardGold, int currentHitPoints, int maxHitPoints) : base(currentHitPoints, maxHitPoints)
        {
            ID = iD;
            Name = name;
            MaxDamage = maxDamage;
            RewardXP = rewardXP;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
    }
}
