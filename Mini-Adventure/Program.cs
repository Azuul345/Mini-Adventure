using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace Mini_Adventure
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to this Mini-Adventure!");
            Console.WriteLine("Enter your adventure name: ");
            string advName = Console.ReadLine();
            //Control for choosing class
            string advClass = GameMechanics.ClassSelectionCheck("Choose your class: (W)arrior or (M)age");

            //class initiation
            Adventurer player = Adventurer.ClassInitiation(advName, advClass);
            player.ShowPlayerStatus();
            
            

            bool isAlive = true;
            while (isAlive)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[----------MENU----------]");
                Console.WriteLine("What your next move? - Select nr\n(1): Adventure\n" +
                    "(2): Rest at Bonfire (Refil Mana & Gain 40+HP, Cost: -15 Gold)\n" +
                    "(3): Check Player Status\n(4): Open Inventory\n(5): SHOP - Raise Damage and Health for 80 gold \n(6): Quite Game");
                Console.ResetColor();
                int playerChoice = GameMechanics.CheckForCorrectIntValue("Select option:  ");

                switch (playerChoice)
                {
                    case 1:
                        Enemies enemy = Enemies.InitiateNewEnemy(player.EnemyDefeated);
                        isAlive = GameMechanics.FightLoop(player, enemy);
                        break;
                    case 2:
                        player.RestAtBondfire();
                        break;
                    case 3:
                        player.ShowPlayerStatus();
                        break;
                    case 4:
                        GameMechanics.ShowCaseInventory(player.inventory);
                        break;
                    case 5:
                        player.RaiseDamageAndHealth();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for playing");
                        isAlive = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            }
            Console.ReadKey();
        }



    }
}
