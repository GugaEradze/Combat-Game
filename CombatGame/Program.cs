using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int playerHp = 40;
        int enemyHp = 30;

        int playerAttack = 8;
        int enemyAttack = 6;

        int playerHeal = 10;
        int enemyHeal = 5;

        int maxPlayerHp = 40;
        int maxEnemyHp = 30;

        Random random = new Random();

        Console.WriteLine("Welcome to the Battle Game! Prepare to fight!\n");

        while (playerHp > 0 && enemyHp > 0)
        {
            Console.WriteLine("\n-- Player Turn! --");
            Console.WriteLine($"Player HP: {playerHp}/{maxPlayerHp} | Enemy HP: {enemyHp}/{maxEnemyHp}");
            Console.WriteLine("Enter 'a' To Attack, 'h' To Heal, or 'd' To Defend");

            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    enemyHp -= playerAttack;
                    Console.WriteLine($"You attacked the enemy and dealt {playerAttack} damage!");
                    break;
                case "h":
                    int healAmount = Math.Min(playerHeal, maxPlayerHp - playerHp);
                    playerHp += healAmount;
                    Console.WriteLine($"You healed and restored {healAmount} health points!");
                    break;
                case "d":
                    Console.WriteLine("You defended, reducing damage from the next enemy attack!");
                    break;
                default:
                    Console.WriteLine("Invalid choice! You lose your turn.");
                    break;
            }

            if (enemyHp <= 0)
            {
                break;
            }

            Console.WriteLine("\n-- Enemy Turn! --");
            Console.WriteLine($"Player HP: {playerHp}/{maxPlayerHp} | Enemy HP: {enemyHp}/{maxEnemyHp}");

            int enemyChoice = random.Next(0, 3);

            if (enemyChoice == 0)
            {
                playerHp -= enemyAttack;
                Console.WriteLine($"Enemy attacked and dealt {enemyAttack} damage!");
            }
            else if (enemyChoice == 1)
            {
                int healAmount = Math.Min(enemyHeal, maxEnemyHp - enemyHp);
                enemyHp += healAmount;
                Console.WriteLine($"Enemy healed and restored {healAmount} health points!");
            }
            else
            {
                Console.WriteLine("Enemy defended, reducing damage from the next attack!");
            }
        }

        Console.WriteLine("\n-- Game Over --");
        if (playerHp > 0)
        {
            Console.WriteLine("Congratulations, You Won!");
        }
        else
        {
            Console.WriteLine("You Lose! Better Luck Next Time.");
        }
    }
}
