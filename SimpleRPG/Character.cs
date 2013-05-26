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
         */
        public void initialize()
        {
            level = 1;
            maxHealth = 40;
            health = maxHealth;
            damage = 5;
            money = 100;
            exp = 0;
            reqExp = 45;

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
            string[] commands = new string[] { "\n[A]ttack ", "\n[M]agic ", "\n[I]tems ", "\n[F]lee " };
            string[] commandsShortcut = { "a", "m", "i", "f" }; //NOTE: The length of this array must match the length of commands
            int arrowLoc = 0;
            bool resolved = false;
            do
            {
                Console.Clear();
                //Monster.displayMonster();

                //print the commands and current arrow
                for (int i = 0; i <= arrowLoc; i++)
                {
                    Console.Write(commands[i]);
                }
                Console.Write("\x2190"); //left triangle 25C4 or 25C0, 25C0 not working
                for (int k = arrowLoc + 1; k < commands.Length; k++)
                {
                    Console.Write(commands[k]);
                }

                //get the next command
                ConsoleKeyInfo pressed;
                pressed = Console.ReadKey(false);
                String pressedString = pressed.Key.ToString();
                if (pressedString.Equals("Enter", StringComparison.Ordinal))
                {
                    pressedString = commandsShortcut[arrowLoc];
                }
                Console.Clear();

                //execute the command
                switch (pressedString)
                {
                    case "a":
                    case "A":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You attack!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        resolved = true;
                        break;
                    case "m":
                    case "M":
                        Console.WriteLine("Magic!");
                        //p1.listMagic
                        break;
                    case "i":
                    case "I":
                        Console.WriteLine("Items!");
                        //p1.listItems
                        break;
                    case "f":
                    case "F":
                        Console.WriteLine("Flee");
                        break;
                    case "DownArrow":
                        if (arrowLoc < 3)//TODO get rid of magic numbers
                        {
                            arrowLoc += 1;
                        }
                        break;
                    case "UpArrow":
                        if (arrowLoc > 0)
                        {
                            arrowLoc -= 1;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (!resolved);
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
