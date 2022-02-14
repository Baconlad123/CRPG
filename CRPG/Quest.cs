using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CRPG
{
    public class Quest
    {
        public int ID;
        public string Name;
        public string Description;
        public int RewardXP;
        public int RewardGold;
        public Item RewardItem;
        public List<QuestCompletionItem> QuestCompletionItems;

        public Quest(int iD, string name, string description, int rewardXP, int rewardGold)
        {
            ID = iD;
            Name = name;
            Description = description;
            RewardXP = rewardXP;
            RewardGold = rewardGold;

            QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}
