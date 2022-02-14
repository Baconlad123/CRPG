using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class Player:LivingCreature 
    {
        public string Name;
        public int Gold;
        public int XP;
        public int Level;
        public Location CurrentLocation;
        public List<InventoryItem> Inventory;
        public List<PlayerQuest> Quests;

        public Player(string name, int currentHitPoints, int maxHitPoints, int gold, int xP, int level):base(currentHitPoints,maxHitPoints)
        {
            Name = name;
            Gold = gold;
            XP = xP;
            Level = level;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public Player()
        {

        }

        public void MoveTo(Location loc)
        {
            CurrentLocation = loc;
        }

        public void MoveNorth()
        {
            if(CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
            }
            else
            {
                Console.WriteLine("You cannot move North.");
            }
        }
        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
            {
                MoveTo(CurrentLocation.LocationToEast);
            }
            else
            {
                Console.WriteLine("You cannot move East.");
            }
        }
        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
            }
            else
            {
                Console.WriteLine("You cannot move South.");
            }
        }
        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
            }
            else
            {
                Console.WriteLine("You cannot move West.");
            }
        }


    }

}
