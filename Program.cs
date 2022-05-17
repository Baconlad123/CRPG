using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Logan Chriscaden 2022
namespace CRPG
{
    class Program
    {

        private static Player _player = new Player("P. Laier", 10, 10, 20, 0, 1);


        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            InventoryItem sword = new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1);
            InventoryItem club = new InventoryItem(World.ItemByID(World.ITEM_ID_CLUB), 1);
            _player.Inventory.Add(sword);


            while (true)
            {
                Console.Write(">  ");
                string userInput = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();

                if(cleanedInput == "exit")
                {
                    break;
                }
                ParseInput(cleanedInput);

            }
            
        }
        public static void ParseInput(string input)
        {
            if(input.Contains("help")||input == "h")
            {
                Console.WriteLine("Help is coming later... stay tuned.");
            }
            else if (input.Contains("look")||input == "l")
            {
                DisplayCurrentLocation();
            }
            else if (input.Contains("north")|| input == "n")
            {
                _player.MoveNorth();
            }
            else if (input.Contains("east")||input == "e")
            {
                _player.MoveEast();
            }
            else if (input.Contains("south")||input == "s")
            {
                _player.MoveSouth();
            }
            else if (input.Contains("west")||input == "w")
            {
                _player.MoveWest();
            }else if(input.Contains("debug"))
            {
                GameEngine.DebugInfo();
            }else if (input == "inventory" || input == "i")
            {
                Console.WriteLine("\nCurrent Inventory:");
                foreach(InventoryItem invItem in _player.Inventory)
                {
                    Console.WriteLine($"\t{invItem.Details.Name} : {invItem.Quantity}");
                }
            }else if (input == "stats")
            {
                Console.WriteLine($"\nStats for {_player.Name}");
                Console.WriteLine($"\t Current HP; \t{_player.CurrentHitPoints}");
                Console.WriteLine($"\t Maximum HP; \t{_player.MaxHitPoints}");
                Console.WriteLine($"\t XP; \t\t{_player.XP}");
                Console.WriteLine($"\t Level; \t{_player.Level}");
                Console.WriteLine($"\t Gold; \t\t{_player.Gold}");
            }else if (input == "quests")
            {
                if(_player.Quests.Count == 0)
                {
                    Console.WriteLine("You do not have any quests");
                }
                else
                {
                    foreach (PlayerQuest playerQuest in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuest.Details.Name, playerQuest.IsCompleted ? "Completed" : "Incomplete");
                    }

                }

            }else if (input.Contains("attack"))
            {
                if(_player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("There is nothign here to attack.");
                }
                else
                {
                    if(_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You do not have a weapon.");
                    }
                    else
                    {
                        _player.UseWeapon(_player.CurrentWeapon);
                    }
                }
            }

            else
            {
                Console.WriteLine("I don't understand, sorry.");
            }

        }

        public static void DisplayCurrentLocation()
        {
            Console.WriteLine($"\nYou are at: {_player.CurrentLocation.Name}");
            if(_player.CurrentLocation.Description != "")
            {
                Console.WriteLine($"\t{_player.CurrentLocation.Description}\n");
            }

        }

    }

}
