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
        Monster curMonster;

        /**
         * Generates a new monster at an appropriate difficulty for the player to fight
         * 
         * @param Character p1
         *      The character for which the monster is being generated
         *      
         * @return Monster
         *      The monster generated
         */
        public void generateMonster(Character p1)
        {

            int ndamage = (int)(rnd.NextDouble() * p1.damage * 1.2) + 5;
            int nmax = (int)(rnd.NextDouble() * p1.maxHealth * 1.2) + 10;
            Console.WriteLine("This monster's damage is {0} and health is {1}", ndamage, nmax);
            Console.ReadLine();

            curMonster = new Monster(ndamage, nmax);
            curMonster.initialize();

        }

        public bool continuePlaying()
        {
            Console.Clear();
            Console.WriteLine("Would you like to continue playing?");
            string[] tf = {"\n[Y]es ", "\n[N]o"};
            string[] tfs = {"y", "n"};
            int stay = choice(tf, tfs);
            if (stay == 0)
            {
                return true;
            }
            return false;
        }

        public void displayMonster()
        {
            curMonster.display();
        }

        /**
         * Given a number of choices and their shortcuts, uses user input
         * to return the index of the choice made. The original text leading to the menu is lost.
         * It is recommended that one of the choices is to redisplay the original text.
         * 
         * @param string[] choices
         *      The Text that will be displayed describing the player's available choices
         *      
         * @param string[] shortcut
         *      The one-keypress shortcut to select a choice. Typically surrounded by [] 
         *      in the 'choices' string[]. Must be the same length as choices and
         *      each index must correspond correctly.
         *      
         * @return int
         *      The index of the choice made in both choices and shortcut. -1 if
         *      the choice failed for any reason - this likely means the user selected
         *      a choice that was not in shortcut
         */
        public int choice(string[] choices, string[] shortcut)
        {
            if (choices.Length != shortcut.Length)
            {
                Console.Write("An error occured: The number of choices is not equal to the number of  " +
                    "number of shortcuts");
                Console.Read();
                return -1;
            }

            //prepare shortcuts
            for (int i = 0; i < shortcut.Length; i++)
            {
                shortcut[i] = shortcut[i].ToLower();
            }
            int arrowLoc = 0;
            while(true) // fine here, we don't want to break until we get a valid choice,
                        // so return will kick us out
            {
                //write the commands and the arrow
                for (int i = 0; i <= arrowLoc; i++)
                {
                    Console.Write(choices[i]);
                }
                Console.Write("\x2190"); //left triangle 25C4 or 25C0, 25C0 not working
                for (int k = arrowLoc + 1; k < choices.Length; k++)
                {
                    Console.Write(choices[k]);
                }

                //get the next command
                ConsoleKeyInfo pressed;
                pressed = Console.ReadKey(false);
                String pressedString = pressed.Key.ToString();
                if (pressedString.Equals("Enter", StringComparison.Ordinal))
                { // handle arrow nav
                    return arrowLoc;
                }
                else if (pressedString.Equals("DownArrow", StringComparison.Ordinal))
                { //handle arrow nav
                    if (arrowLoc < choices.Length - 1)
                    {
                        arrowLoc += 1;
                    }
                }
                else if (pressedString.Equals("UpArrow", StringComparison.Ordinal))
                { //handle arrow nav
                    if (arrowLoc > 0)
                    {
                        arrowLoc -= 1;
                    }
                }
                else
                { //a non nav key was pressed

                    //search for the key in shortcuts
                    Console.WriteLine("\nPressedstring: {0}", pressedString);
                    pressedString = pressedString.ToLower();
                    Console.WriteLine("After ToLower; {0}", pressedString);
                    for (int i = 0; i < shortcut.Length; i++)
                    {

                        Console.WriteLine("Testing {0}", shortcut[i]);
                        if (pressedString.Equals(shortcut[i], StringComparison.Ordinal))
                        {
                            return i;

                        }
                    }
                    //The user selected a key not in shortcuts. Bad user!
                    return -1;
           

                }
                Console.Clear();
            
            }

            Console.WriteLine("\nThe choice failed.");
            Console.Read();
            return -1;
        }
    }
}