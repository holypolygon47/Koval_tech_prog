using System;

class Program
{
    static void Main()
    {
        char[,] pole = new char[3, 3]; 
        bool igrokX = true; 
        bool komp = false; 
        bool konec = false; 

        Console.WriteLine("1 - играть с другом");
        Console.WriteLine("2 - играть с компьютером");
        int vibor = int.Parse(Console.ReadLine());
        if (vibor == 2) komp = true;

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                pole[i, j] = ' ';

        while (!konec)
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(pole[i, j] + " ");
                Console.WriteLine();
            }

            if (igrokX || !komp)
            {
                Console.WriteLine("Ход " + (igrokX ? "X" : "O"));
                Console.Write("Введите строку (1-3): ");
                int x = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Введите столбец (1-3): ");
                int y = int.Parse(Console.ReadLine()) - 1;

                if (pole[x, y] == ' ')
                    pole[x, y] = igrokX ? 'X' : 'O';
                else
                {
                    Console.WriteLine("здесь уже занято");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Ход компьютера:");
                Random rand = new Random();
                int x, y;
                do
                {
                    x = rand.Next(0, 3);
                    y = rand.Next(0, 3);
                } while (pole[x, y] != ' ');
                pole[x, y] = 'O';
            }

            for (int i = 0; i < 3; i++)
            {
                // строки
                if (pole[i, 0] == pole[i, 1] && pole[i, 1] == pole[i, 2] && pole[i, 0] != ' ')
                {
                    Console.WriteLine("Победил " + pole[i, 0] + "!");
                    konec = true;
                }
                // столбцы
                if (pole[0, i] == pole[1, i] && pole[1, i] == pole[2, i] && pole[0, i] != ' ')
                {
                    Console.WriteLine("Победил " + pole[0, i] + "!");
                    konec = true;
                }
            }
            // диагонали
            if (pole[0, 0] == pole[1, 1] && pole[1, 1] == pole[2, 2] && pole[0, 0] != ' ')
            {
                Console.WriteLine("Победил " + pole[0, 0] + "!");
                konec = true;
            }
            if (pole[0, 2] == pole[1, 1] && pole[1, 1] == pole[2, 0] && pole[0, 2] != ' ')
            {
                Console.WriteLine("Победил " + pole[0, 2] + "!");
                konec = true;
            }

            // проверка ничьи
            bool netHoda = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (pole[i, j] == ' ') netHoda = false;
            if (netHoda && !konec)
            {
                Console.WriteLine("Ничья!");
                konec = true;
            }

            if (!konec) igrokX = !igrokX;
        }
    }
}