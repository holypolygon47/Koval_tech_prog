using System;

int n;
Console.Write("Введите нечетное N: ");
n = Convert.ToInt32(Console.ReadLine());

if (n % 2 == 0)
{
    Console.WriteLine("N должно быть нечетным, введите другое N");
    n = Convert.ToInt32(Console.ReadLine());
}

int[,] array = new int[n, n];
int num = 1;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        array[i, j] = num++;
    }
}

Console.WriteLine("Массив:");
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(array[i, j].ToString().PadLeft(3) + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("Обход по спирали:");
int x = n / 2, y = n / 2;
Console.Write(array[y, x] + " ");

for (int step = 1; step < n; step++)
{
    for (int i = 0; i < step; i++) // Вправо
    {
        x++;
        Console.Write(array[y, x] + " ");
    }

    for (int i = 0; i < step; i++) // Вниз
    {
        y++;
        Console.Write(array[y, x] + " ");
    }

    step++;
    if (step >= n) break;

    for (int i = 0; i < step; i++) // Влево
    {
        x--;
        Console.Write(array[y, x] + " ");
    }

    for (int i = 0; i < step; i++) // Вверх
    {
        y--;
        Console.Write(array[y, x] + " ");
    }
}