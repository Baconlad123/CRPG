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
        public Weapon CurrentWeapon;
        public List<Weapon> Weapons = new List<Weapon>();

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
            //Check to make sure player has any required items

            if(loc.ItemRequiredToEnter != null)
            {
                //Check for the item
                bool playerHasRequiredItem = false;
                foreach(InventoryItem ii in this.Inventory)
                {
                    if(ii.Details.ID == loc.ItemRequiredToEnter.ID)
                    {
                        playerHasRequiredItem = true;
                        break;
                    }

                }

                if (!playerHasRequiredItem)
                {
                    Console.WriteLine($"You must have a {loc.ItemRequiredToEnter.Name}");
                    return;
                }

            }
            CurrentHitPoints = MaxHitPoints;
            CurrentLocation = loc;
            GameEngine.QuestProcessor(this, loc);
            GameEngine.MonsterProcessor(this, loc);
        }

        public void MoveNorth()
        {
            if(CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
                Program.DisplayCurrentLocation();
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
                Program.DisplayCurrentLocation();
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
                Program.DisplayCurrentLocation();
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
                Program.DisplayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You cannot move West.");
            }
        }

        //----------------------Quests----------------------
        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }


        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }

            }

        }

        //Weapon Work
        public void UseWeapon(Weapon weapon)
        {
            Console.WriteLine("Fight! -- ToDo Finish later");
        }

        public void UpdateWeapons()
        {
            Weapons.Clear();
            foreach(InventoryItem inventoryItem in this.Inventory)
            {
                if(inventoryItem.Details is Weapon)
                {
                    if(inventoryItem.Quantity > 0)
                    {
                        Weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }
        }

    }

}
