//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Mini_Adventure
{
    public class Enemies
    {

        public string EnemyClass = "";
        public int Health = 0;
        public int Damage = 0;
        public int Gold = 0;


        public void FightPlayer(Adventurer player, int taunts)
        {
            //AttackChance starts at 1 (100%) and decreases every time the taunt counter goes up
            double AttackChance = 1.0 - (0.2 * taunts);
            
            Random rnd = new Random();
            double roll = rnd.NextDouble();

            if (roll <= AttackChance)
            {
                Console.WriteLine($"{EnemyClass} Attacks!!");
                player.Health -= Damage;
                if (player.Health < 0)
                {
                    player.Health = 0;
                }
                Console.WriteLine($"{player.Name} health is now at {player.Health}");
                GameMechanics.PressEnterToContinue();
            }
            else
            {
                Console.WriteLine($"{EnemyClass} misses attack!");
                GameMechanics.PressEnterToContinue();
            }
        }

        public static Enemies InitiateNewEnemy(int enemyDefeated)
        {
            Console.WriteLine("New enemy apears!");
            Enemies enemy = Enemies.CreateNewEnemy(Enemies.SelectRandomMonster());
            enemy.Damage += (enemyDefeated * 10);
            enemy.ShowEnemySatus();
            GameMechanics.PressEnterToContinue();
            return enemy;
        }

        public void ShowEnemySatus()
        {
            Console.WriteLine($"Enemy class: {EnemyClass}\nHealth: {Health}\nDamage: {Damage}\nGold to drop: {Gold}");
        }

        public string CreateRandomLoot()
        {
            string[] loot = ["Map Fragment", "Bread", "Medalion", "Letter", "Empty Bottle"];
            Random rnd = new();
            int randomLoot = rnd.Next(0, 5);
            return loot[randomLoot];
        }

        public static string SelectRandomMonster()
        {
            string[] enemies = ["Giant Rat", "Goblin", "Skeleton", "Bandit"];
            Random rnd = new();
            int randomEnemy = rnd.Next(0, 4);
            return enemies[randomEnemy];
        }

        public static Enemies CreateNewEnemy(string enemyType)
        {
            Enemies enemy = new Enemies();
            switch (enemyType)
            {
                case "Giant Rat":
                    enemy.EnemyClass = enemyType;
                    enemy.Health = 100;
                    enemy.Damage = 30;
                    enemy.Gold = 20;
                    break;
                case "Goblin":
                    enemy.EnemyClass = enemyType;
                    enemy.Health = 160;
                    enemy.Damage = 50;
                    enemy.Gold = 40;
                    break;
                case "Skeleton":
                    enemy.EnemyClass = enemyType;
                    enemy.Health = 120;
                    enemy.Damage = 30;
                    enemy.Gold = 20;
                    break;
                case "Bandit":
                    enemy.EnemyClass = enemyType;
                    enemy.Health = 140;
                    enemy.Damage = 60;
                    enemy.Gold = 50;
                    break;
            }
            return enemy;
        }


    }
}
