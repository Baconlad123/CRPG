using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CRPG
{
    public class PlayerQuest
    {
        public Quest Details;
        public bool IsCompleted;

        public PlayerQuest(Quest details, bool isCompleted)
        {
            Details = details;
            IsCompleted = isCompleted;
        }
    }
}
