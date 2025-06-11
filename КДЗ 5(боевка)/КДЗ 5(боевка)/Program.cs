using System;
using System.Collections.Generic;

namespace TextRPG
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; protected set; }
        public int Damage { get; protected set; }
        public int Experience { get; set; }
        public int Level { get; set; } = 1;

        public List<string> Inventory { get; protected set; } = new List<string>();
        public int Arrows { get; set; } = 0; 
        public int Mana { get; set; } = 0;  

        public abstract void Attack(Character target);

        public void UseItem(string item)
        {
            if (Inventory.Contains(item))
            {
                if (item == "Зелье здоровья")
                {
                    Console.Clear();
                    Health = Math.Min(Health + 30, MaxHealth);
                    Console.WriteLine($"{Name} использовал зелье здоровья (+30 HP)!");
                }
                else if (item == "Зелье маны")
                {
                    Console.Clear();
                    Mana += 20;
                    Console.WriteLine($"{Name} использовал зелье маны (+20 MP)!");
                }

                Inventory.Remove(item);
            }
            else
            {
                Console.WriteLine("Такого предмета нет в инвентаре!");
            }
        }

        public bool IsAlive => Health > 0;

        public void LevelUp()
        {
            if (Experience >= Level * 100)
            {
                Experience -= Level * 100;
                Level++;
                MaxHealth += 10;
                Health = MaxHealth;
                Damage += 2;
                Console.WriteLine($"\n{Name} достиг {Level} уровня! +10 к максимальному здоровью, +2 к урону!");
            }
        }
    }
    class Archer : Character
    {
        public Archer()
        {
            Name = "Стрелок";
            Health = MaxHealth = 80;
            Damage = 15;
            Arrows = 10;
            Inventory.AddRange(new[] { "Зелье здоровья", "Зелье здоровья" });
        }

        public override void Attack(Character target)
        {
            if (Arrows > 0)
            {
                Console.WriteLine($"{Name} стреляет в {target.Name} и наносит {Damage} урона!");
                target.Health -= Damage;
                Arrows--;
                Console.WriteLine($"Осталось стрел: {Arrows}");
            }
            else
            {
                Console.WriteLine($"{Name} пытается стрелять, но стрелы закончились!");
            }
        }
    }

    class Mage : Character
    {
        public Mage()
        {
            Name = "Маг";
            Health = MaxHealth = 60;
            Damage = 25;
            Mana = 50;
            Inventory.AddRange(new[] { "Зелье здоровья", "Зелье маны" });
        }

        public override void Attack(Character target)
        {
            if (Mana >= 10)
            {
                Console.WriteLine($"{Name} бросает огненный шар в {target.Name} и наносит {Damage} урона!");
                target.Health -= Damage;
                Mana -= 10;
                Console.WriteLine($"Осталось маны: {Mana}");
            }
            else
            {
                Console.WriteLine($"{Name} пытается атаковать, но не хватает маны!");
            }
        }
    }

    class Warrior : Character
    {
        public Warrior()
        {
            Name = "Воин";
            Health = MaxHealth = 100;
            Damage = 20;
            Inventory.AddRange(new[] { "Зелье здоровья", "Зелье здоровья" });
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} бьёт мечом {target.Name} и наносит {Damage} урона!");
            target.Health -= Damage;
        }
    }

    class Program
    {
        static Character CreateCharacter()
        {
            Console.WriteLine("Выберите класс персонажа:");
            Console.WriteLine("1. Стрелок (80 HP, 15 урона, стрелы)");
            Console.WriteLine("2. Маг (60 HP, 25 урона, мана)");
            Console.WriteLine("3. Воин (100 HP, 20 урона)");

            while (true)
            {
                Console.Write("Ваш выбор (1-3): ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": return new Archer();
                    case "2": return new Mage();
                    case "3": return new Warrior();
                    default: Console.WriteLine("Некорректный ввод!"); break;
                }
            }
        }

        static Character CreateEnemy(Random rnd)
        {
            int choice = rnd.Next(1, 4);

            switch (choice)
            {
                case 1: return new Archer() { Name = "Вражеский стрелок" };
                case 2: return new Mage() { Name = "Вражеский маг" };
                case 3: return new Warrior() { Name = "Вражеский воин" };
                default: return new Warrior() { Name = "Враг" };
            }
        }

        static void ShowStatus(Character player, Character enemy)
        {
            Console.WriteLine($"\n{player.Name} (Ур.{player.Level}): {player.Health}/{player.MaxHealth} HP");
            Console.WriteLine($"{enemy.Name}: {enemy.Health}/{enemy.MaxHealth} HP");

            if (player is Archer a) Console.WriteLine($"Стрелы: {a.Arrows}");
            if (player is Mage m) Console.WriteLine($"Мана: {m.Mana}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Игра");
            var rnd = new Random();
            var player = CreateCharacter();

            bool playing = true;
            while (playing)
            {
                var enemy = CreateEnemy(rnd);
                Console.WriteLine($"\nПоявился {enemy.Name}! Начинается битва!");

                while (player.IsAlive && enemy.IsAlive)
                {
                    ShowStatus(player, enemy);

                    Console.WriteLine("\nВаш ход:");
                    Console.WriteLine("1. Атаковать");
                    Console.WriteLine("2. Использовать предмет");
                    Console.Write("Выберите действие: ");

                    var choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.Clear();
                        player.Attack(enemy);
                    }
                    else if (choice == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Инвентарь:");
                        for (int i = 0; i < player.Inventory.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {player.Inventory[i]}");
                        }

                        Console.Write("Выберите предмет (или 0 для отмены): ");
                        if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= player.Inventory.Count)
                        {
                            player.UseItem(player.Inventory[itemIndex - 1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пропуск хода из-за неверного ввода!");
                    }

                    if (enemy.IsAlive)
                    {
                        Console.WriteLine($"\nХод {enemy.Name}...");
                        if (rnd.Next(0, 4) == 0 && enemy.Inventory.Count > 0) 
                        {
                            enemy.UseItem(enemy.Inventory[0]);
                        }
                        else
                        {
                            enemy.Attack(player);
                        }
                    }
                }

                if (player.IsAlive)
                {
                    int expGain = 50 + rnd.Next(0, 30);
                    player.Experience += expGain;
                    Console.WriteLine($"\nВы победили! Получено {expGain} опыта.");
                    player.LevelUp();

                    player.Health = player.MaxHealth;
                    if (player is Archer a) a.Arrows = 10;
                    if (player is Mage m) m.Mana = 50;

                    Console.WriteLine("\nПосле боя вы восстановили здоровье и ресурсы.");
                    ShowStatus(player, enemy);

                    Console.Write("\nХотите продолжить сражения? (да/нет): ");
                    playing = Console.ReadLine().ToLower() == "да";
                }
                else
                {
                    Console.WriteLine("\nВы проиграли! Игра окончена.");
                    playing = false;
                }
            }

            Console.WriteLine($"\nИгра завершена. Ваш персонаж достиг {player.Level} уровня.");
        }
    }
}