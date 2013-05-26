using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleRPG
{
    /**
         * Contains infomation on the player, including inventory, exp, and status
         */
    class Character
    {

        String name;             //The name of the character, chosen by the player
        public int maxHealth;    //The maximum health the player can have
        int health;              //The current health the player has
        public int damage;       //The modifier for damaging attacks the player makes
        int money;               //The amount of money the player can spend
        double exp;              //The current progress towards the next level
        int level;               //The number of times the player has levelled up
        double reqExp;           //The required experience to reach the next level
        Session thisSession;     //The current game session

        /**
         * Constuctor: Character
         * Creates a new character with the specified name
         * 
         * @param String newname
         *      The name of the new character
         *      
         * @return none
         */
        public Character(String newname)
        {
            name = newname;

        }

        /**
         * Sets appropriate values for a new character's
         * health, damage and other stats.
         * 
         * @param Session nsession
         *      The current game session
         */
        public void initialize(Session nsession)
        {
            level = 1;
            maxHealth = 40;
            health = maxHealth;
            damage = 5;
            money = 100;
            exp = 0;
            reqExp = 45;
            thisSession = nsession;
        }

        /**
         * Displays the stats of the character with flavor text
         * 
         * @param none
         * @return none
         */
        public void writeStats()
        {
            Console.WriteLine("Your name is {0} and you have {1} experience", name, exp);
            Console.WriteLine("Your health is {0} out of {1}", health, maxHealth);
            Console.WriteLine("You have {0} boondollars", money);
            Console.ReadLine();
        }

        /**
         * Increases the max health and damage of the player, and updates the new
         * levelup requirements.
         * 
         * @param none
         * @return none
         */
        public void levelUp()
        {
            maxHealth = (int)(maxHealth * 1.11);
            damage += 3;
            exp = exp - reqExp;
            reqExp = 40 + Math.Pow(20.0, (1 + 0.05 * level)) + 5 * level;

        }

        /**
         *  Displays a list of available commands during battle. The user can
         *  press the indicated letter to select a command, or navigate with
         *  arrow keys and enter.
         *  
         * @param none
         * @return none
         */ 
        public void getCommand()
        {
            string[] commands = new string[] { "[A]ttack ", "\n[M]agic ", "\n[I]tems ", "\n[F]lee ", "\n[D]isplay monster " };
            string[] commandsShortcut = { "a", "m", "i", "f", "d" }; //NOTE: The length of this array must match the length of commands

            Console.Clear();
            thisSession.displayMonster();

            //make command choice
            int choice = thisSession.choice(commands, commandsShortcut);
            Console.Clear();
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Attack!");
                    break;
                case 1:
                    Console.WriteLine("Magic!");
                    break;
                case 2:
                    Console.WriteLine("Item!");
                    break;
                case 3:
                    Console.WriteLine("Flee!");
                    break;
                case 4:
                    thisSession.displayMonster();
                    break;
                case -1:
                default:
                    Console.WriteLine("Error");
                    break;
            }
   
            Console.ReadLine();
        }
        /**
         * potential experience algorithms
         * 40 + 20 * level^2.05 - 15 * level^2
         *  1 = 45
         *  2 = 63
         *  3 = 95
         *  10 = 784
         *  25 = 5347
         *  50 = 23342
         *  100 = 101825
         *  
         * 10 + 20^(1 + level*0.05) + 5*level
         *  1 = 38
         *  2 = 46
         *  3 = 56
         *  5 = 77
         *  10 = 149
         * */
    }
}
