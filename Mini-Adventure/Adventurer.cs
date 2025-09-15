//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Mini_Adventure
{
    public class Adventurer
    {
        public string Name = "HeroX";
        public string AdvClass = "";
        public int MaxHealth = 0;
        public int Health = 0;
        public int Damage = 0;
        public int MaxMana = 0;
        public int Mana = 0;
        public int Gold = 0;
        public int EnemyDefeated = 0;
        public List<string> inventory = [];

        public void RaiseDamageAndHealth()
        {
            if (Gold < 80)
            {
                Console.WriteLine("Insufficent Gold");
            }
            else
            {
                Gold -= 80;
                Damage += 50;
                MaxHealth += 50;
                Health = MaxHealth;
                Console.WriteLine($"{Name} has incresed their damage to {Damage} and Max health to {MaxHealth} \nAmount of Golf left: {Gold}");
            }
            GameMechanics.PressEnterToContinue();
        }

        public void HealWithMana()
        {
            if (Mana < 15)
            {
                Console.WriteLine("Insufficent mana to heal");
            }
            else if (Health >= (MaxHealth - 40))
            {
                Health = MaxHealth;
                Mana -= 15;
                //Console.WriteLine($"{player.Name}s helth is now at {player.Health} and has {player.Mana} left");

            }
            else
            {
                Health += 40;
                Mana -= 15;
                //Console.WriteLine($"{player.Name}s helth is now at {player.Health} and has {player.Mana} left");
            }
        }

        public void FightEnemy(Enemies foe)
        {
            foe.Health -= Damage;
            if (foe.Health < 0)
            {
                foe.Health = 0;
            }
        }

        public void RestAtBondfire()
        {
            if (Health == MaxHealth || Gold < 15)
            {
                Console.WriteLine($"Unable to heal");
            }
            else if (Health >= (MaxHealth - 60))
            {
                Health = MaxHealth;
                Gold -= 15;
            }
            else
            {
                Health += 60;
                Gold -= 15;
            }

            Mana = MaxMana;
            Console.WriteLine($"Player Health:{Health} Mana:{Mana}, Amount of Gold: {Gold}");
            GameMechanics.PressEnterToContinue();
        }


        public void ShowPlayerStatus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"***Player Satus***\nName: {Name}\nClass: {AdvClass}\nHealth: {Health}\n" +
            $"Damage: {Damage}\nMana: {Mana}\nGold: {Gold} \nEnemies Defeated: {EnemyDefeated} ");
            Console.ResetColor();
            GameMechanics.PressEnterToContinue();
        }

        public static Adventurer ClassInitiation(string name, string advclass)
        {
            Adventurer player = new Adventurer();
            player.Name = name;
            player.AdvClass = advclass;
            if (advclass == "Mage")
            {
                player.MaxHealth = 400;
                player.Health = player.MaxHealth;
                player.Damage = 70;
                player.MaxMana = 60;
                player.Mana = player.MaxMana;
                player.Gold = 15;
            }
            else if (advclass == "Warrior")
            {
                player.MaxHealth = 460;
                player.Health = player.MaxHealth;
                player.Damage = 50;
                player.MaxMana = 30;
                player.Mana = player.MaxMana;
                player.Gold = 30;
            }
            return player;
        }
    }
}
