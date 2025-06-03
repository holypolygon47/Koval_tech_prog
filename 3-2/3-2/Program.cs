using System;

int radius = 5; // радиус можно поменять

for (int y = -radius; y <= radius; y++)
{
    for (int x = -radius; x <= radius; x++)
    {
        if (Math.Abs(x * x + y * y - radius * radius) < radius)
        {
            Console.Write("*");
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.WriteLine();
}