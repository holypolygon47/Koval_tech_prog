using System;
int n, i, j;
Console.WriteLine("введите n");
n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("простые числа не превышающие n:");
for (i = 2; i <= n; i++)
{
    j = 2;
    for (; j <= Math.Sqrt(i); j++)
    {
        if (i % j == 0)
        {
            break;
        }
    }
    if (j > Math.Sqrt(i)) Console.WriteLine(i);
}