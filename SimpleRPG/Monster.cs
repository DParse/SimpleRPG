using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleRPG
{


    /**
     * Contains information on different monsters.
     */
    class Monster
    {

        int damage;         //The monster's damage modifier
        int maxHealth;      //The monster's maximum health
        int health;         //The monster's current health

        /**
         * Constructor: Monster
         * Creates a monster with specified damage modifier and max health
         * 
         * @param int ndamage
         *      The damage modifier of the monster
         *      
         * @param int nmax
         *      The maximum health of the monster
         *      
         * @return none
         */
        public Monster(int ndamage, int nmax)
        {
            damage = ndamage;
            maxHealth = nmax;
        }


        /**
         * Initializes the monster 
         */
        public void initialize()
        {
            health = maxHealth;
        }

    }
}