﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Logan Chriscaden 2022
namespace CRPG
{
    class Program
    {

        private static Player _player = new Player();


        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.Name = "P. Laier";
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));


            while (true)
            {
                Console.WriteLine("> ");
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
            if(input.Contains("help"))
            {
                Console.WriteLine("Help is coming later... stay tuned.");
            }
            else if (input.Contains("look"))
            {
                DisplayCurrentLocation();
            }
            else if (input.Contains("north"))
            {
                _player.MoveNorth();
            }
            else if (input.Contains("east"))
            {
                _player.MoveEast();
            }
            else if (input.Contains("south"))
            {
                _player.MoveSouth();
            }
            else if (input.Contains("west"))
            {
                _player.MoveWest();
            }
            else
            {
                Console.WriteLine("I don't understand, sorry.");
            }

        }

        private static void DisplayCurrentLocation()
        {
            Console.WriteLine($"You are at: {_player.CurrentLocation.Name}");
            if(_player.CurrentLocation.Description != "")
            {
                Console.WriteLine($"\t{_player.CurrentLocation.Description}\n");
            }

        }

    }

}
