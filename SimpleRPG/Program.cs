using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            //game variables
            Session thisSession = new Session();
            Monster curMonster;
            bool playing = true;
            Console.CursorVisible = false;
            //make the character
            Console.Write("Please input your character's name!  ");
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

        }
    }

    /**
     * Contains infomation on the player, including inventory, exp, and status
     */
    class Character
    {
        
        String name;
        public int maxHealth;
        int health;
        public int damage;
        int money;
        double exp;
        int level;
        double reqExp;

        public Character(String newname)
        {
            name = newname;

        }

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
        public void writeStats()
        {
            Console.WriteLine(" Your name is {0} and you have {1} experience", name, exp);
            Console.WriteLine("Your health is {0} out of {1}", health, maxHealth);
            Console.WriteLine("You have {0} boondollars", money);
            Console.ReadLine();
        }

        public void levelUp()
        {
            maxHealth = (int)(maxHealth * 1.11);
            damage += 3;
            exp = exp - reqExp;
            reqExp = 40 + Math.Pow(20.0, (1 + 0.05 * level)) + 5 * level;

        }


        public void getCommand()
        {
            string[] commands = new string[] { "\n[A]ttack ", "\n[M]agic ", "\n[I]tems ", "\n[F]lee " };
            string[] commandsShortcut = {"a", "m", "i", "f"};
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
                Console.Write("\x2190");
                for (int k = arrowLoc+1; k < 4; k++)
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
                        Console.WriteLine("colortest");
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
                        if (arrowLoc >0)
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
         * 10 + 20^(1 + level*0.05) + 5*level
         *  1 = 38
         *  2 = 46
         *  3 = 56
         *  5 = 77
         *  10 = 149
         * */
    }

    /**
     * Contains information on different monsters.
     */
    class Monster
    {
        
        int damage;
        int maxHealth;
        int health;

        public Monster(int ndamage, int nmax)
        {
            damage = ndamage;
            maxHealth = nmax;
        }


    }


    class Session
    {
        Random rnd = new Random();

        public Monster generateMonster(Character p1)
        {

            int ndamage = (int)(rnd.NextDouble() * p1.damage * 1.2) + 5;
            int nmax = (int)(rnd.NextDouble() * p1.maxHealth * 1.2) + 10;
            Console.WriteLine("This monster's damage is {0} and health is {1}", ndamage, nmax);
            Console.ReadLine();
            
            Monster newMonster = new Monster(ndamage, nmax);
            return newMonster;

        }

    }
}
