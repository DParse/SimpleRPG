using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleRPG
{
    class Program
    {
        /**
         * Main game loop
         */
        static void Main(string[] args)
        {
            //game variables
            Session thisSession = new Session();
            Monster curMonster;
            bool playing = true;
            Console.CursorVisible = false;

            //make the character
            Console.Write("Please input your character's name! ");
            String name = Console.ReadLine();
            Character p1 = new Character(name);
            p1.initialize();
            p1.writeStats();


            //the game loop: encounter a monster, fight, get rewards, go to town
            while (playing)
            {
                Console.Clear();
                curMonster = thisSession.generateMonster(p1);
                p1.getCommand();
            }

        }//end main
    }//end class
}
