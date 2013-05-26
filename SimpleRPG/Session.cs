using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleRPG
{


    class Session
    {
        //class variables
        Random rnd = new Random();  //the random generator, currently used for making monsters

        /**
         * Generates a new monster at an appropriate difficulty for the player to fight
         * 
         * @param Character p1
         *      The character for which the monster is being generated
         *      
         * @return Monster
         *      The monster generated
         */
        public Monster generateMonster(Character p1)
        {

            int ndamage = (int)(rnd.NextDouble() * p1.damage * 1.2) + 5;
            int nmax = (int)(rnd.NextDouble() * p1.maxHealth * 1.2) + 10;
            Console.WriteLine("This monster's damage is {0} and health is {1}", ndamage, nmax);
            Console.ReadLine();

            Monster newMonster = new Monster(ndamage, nmax);
            newMonster.initialize();
            return newMonster;

        }

    }
}