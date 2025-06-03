using System;
static double fact(double n)
{
    double answ = 1;
    for (double i = 1; i <= n; i++)
        answ *= i;

    return answ;
}
double x, e;

Console.WriteLine("введите x, входящий в диапазон [-1; 1]:");

x = Convert.ToDouble(Console.ReadLine());
e = 1;

while (!(-1 <= x && x <= 1))
{
    Console.WriteLine("x не входит в диапазон [-1; 1]. введите другой x");
    x = Convert.ToDouble(Console.ReadLine());
}

for (double i = 1; ; i++)
{
    e += Math.Pow(x, i) / fact(i);
    if (Math.Pow(x, i) / fact(i) < 0.000001)
    {
        break;
    }
}
Console.WriteLine($"e^x= {e}");