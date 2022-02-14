using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.2";

        public static void Initialize()
        {
            Console.WriteLine($"Initializing Game Engine Versoin {Version}");
            Console.WriteLine($"\n\nWelcome to the world of {World.WorldName}");
            Console.WriteLine();
            World.ListLocations();
            //World.ListItems();
            //World.ListMonsters();
            //World.ListQuests();
        }

    }

}
