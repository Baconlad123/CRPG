using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRPG
{
    public class World
    {
        public static readonly string WorldName = "Wjorl";
        public static readonly List<Location> Locations = new List<Location>();

        //Location IDs
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_FOREST = 2;
        public const int LOCATION_ID_LAB = 3;

        //Constructor for the world
        static World()
        {
            PopulateLocations();
        }

        private static void PopulateLocations()
        {
            //Create the locations
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your childhood home");
            Location forest = new Location(LOCATION_ID_FOREST, "Forest", "A thick wooded area");
            Location lab = new Location(LOCATION_ID_LAB, "Lab", "A clean lookling lab with nice equipment");

            //Link the locations together
            home.LocationToNorth = forest;
            forest.LocationToEast = lab;
            lab.LocationToWest = forest;
            forest.LocationToSouth = home;

            //Create the list of locations
            Locations.Add(home);
            Locations.Add(forest);
            Locations.Add(lab);
        
        }


    }
}
