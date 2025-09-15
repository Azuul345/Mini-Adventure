//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Mini_Adventure
{
    public class GameMechanics
    {
        public static bool FightLoop(Adventurer player, Enemies enemy)
        {

            bool inBattle = true;
            bool isAlive = true;
            int taunts = 0;
            

            while (inBattle)
            {
                if (enemy.Health == 0)
                {
                    player.Gold += enemy.Gold;
                    Console.WriteLine($"{player.Name} Recived {enemy.Gold} Gold");
                    inBattle = false;
                    player.EnemyDefeated += 1;
                    string loot = enemy.CreateRandomLoot();
                    Console.WriteLine($"{enemy.EnemyClass} dropped {loot}");
                    player.inventory.Add(loot);
                    GameMechanics.PressEnterToContinue();


                }
                else if (player.Health == 0)
                {
                    isAlive = false;
                    inBattle = false;
                    Console.WriteLine($"\n\nGame Over.\nYou collected {player.Gold} gold coins and defeated {player.EnemyDefeated} Enemies");

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chose your action! Select nr");
                    Console.WriteLine("(1): Attack! \n(2): Heal \n(3): Taunt? \n(4): Run away!");
                    Console.ResetColor();
                    int battleChoice = CheckForCorrectIntValue("What will you do?: ");

                    switch (battleChoice)
                    {
                        case 1:
                            player.FightEnemy(enemy);
                            Console.WriteLine($"{player.Name} Attacks!");
                            Console.WriteLine($"{enemy.EnemyClass} health decrease to {enemy.Health}");
                            break;
                        case 2:
                            player.HealWithMana();
                            Console.WriteLine($"{player.Name}s helth is now at {player.Health} and has {player.Mana} Mana left");
                            GameMechanics.PressEnterToContinue();
                            break;
                        case 3:
                            taunts = Taunt(player, enemy, taunts);
                            Console.WriteLine($"Taunt counter: {taunts}");
                            GameMechanics.PressEnterToContinue();
                            break;
                        case 4:
                            Console.WriteLine("Tactical Retreat");
                            inBattle = false;
                            GameMechanics.PressEnterToContinue();
                            continue;
                        default:
                            Console.WriteLine("Enter a valid option");
                            break;


                    }
                    if (enemy.Health != 0)
                    {
                        enemy.FightPlayer(player, taunts);
                    }
                }
            }
            return isAlive;
        }


        public static int Taunt(Adventurer player, Enemies enemy, int tauntCounter)
        {
            if (tauntCounter < 5)
            {
                Console.WriteLine($"{player.Name} Taunted {enemy.EnemyClass} for a 20% increase in missed attacks");

                tauntCounter += 1;
            }
            else
            {
                Console.WriteLine("Max amount of taunts reached");
            }
            return tauntCounter;
        }


        public static void ShowCaseInventory(List<string> inventory)
        {   //List to keep track of items
            List<string> seen = [];
            Console.WriteLine($"Inventory:");

            for (int i = 0; i < inventory.Count; i++)
            {
                string currentItem = inventory[i];
                // if item has been handeld  
                if (seen.Contains(currentItem))
                {
                    continue; //continue to next itteration
                }

                int count = 1;
                //(i + 1) to not compare same item twice
                for (int j = (i + 1); j < inventory.Count; j++)
                {
                    if (inventory[j] == currentItem)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"{count}x - {currentItem}");
                seen.Add(currentItem);
            }
            GameMechanics.PressEnterToContinue();
        }

        public static string ClassSelectionCheck(string ChoseCLass)
        {
            bool chosingClass = true;
            string advclass = "";
            while (chosingClass)
            {
                Console.WriteLine(ChoseCLass);
                string choice = Console.ReadLine().ToLower();
                if (choice == "w" || choice == "warrior")
                {
                    advclass = "Warrior";
                    chosingClass = false;
                }
                else if (choice == "m" || choice == "mage")
                {
                    advclass = "Mage";
                    chosingClass = false;
                }
                else
                {
                    Console.WriteLine("Unavalible class- Enter W or M");
                    continue;
                }
            }
            return advclass;
        }

        public static void PressEnterToContinue()
        {
            Console.Write("Press Enter contine: ");
            Console.ReadLine();
                 
        }

        public static int CheckForCorrectIntValue(string EnterValue)
        {

            int result = 0;
            while (true)
            {
                Console.Write(EnterValue);
                string value = Console.ReadLine();
                // Exception handling
                try
                {
                    result = Convert.ToInt32(value); // Attempt to convert string to int
                    break;
                }
                catch
                {   // Exception handling for invalid input
                    Console.WriteLine("Wrong input, enter a number value");
                }
            }
            return result;  // Return the validated numeric input
        }

    }
}
