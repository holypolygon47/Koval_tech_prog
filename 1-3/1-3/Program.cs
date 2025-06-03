using System;
double a, b, c, d;
Console.WriteLine("введите коэффиценты a, b, c");
Console.WriteLine("a:");
a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("b:");
b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("c:");
c = Convert.ToDouble(Console.ReadLine());
d = Math.Pow(b, 2) - 4 * a * c;

if (a == 0)
{
    Console.WriteLine($"x={-c / b}");
}
else
{
    Console.WriteLine($"дискриминант = {d}");
    if (d < 0)
    {
        Console.WriteLine("корней нет");
    }
    else if (d == 0)
    {
        Console.WriteLine($"x={-b / (2 * a)}");
    }
    else
    {
        if (a == 0)
        {
            Console.WriteLine($"x={-c / b}");
        }
        else
        {
            Console.WriteLine($"2 корня, х1={(-b + Math.Pow(d, 0.5)) / (2 * a)}, x2={(-b - Math.Pow(d, 0.5)) / (2 * a)}");
        }
    }
}

