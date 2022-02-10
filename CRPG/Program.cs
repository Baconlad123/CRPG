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

        private static Player _player = new Player();


        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.Name = "P. Laier";

            Console.ReadLine();
        }
    }
}
