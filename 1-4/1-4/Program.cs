using System;
int a, b, c, res, count;
Console.WriteLine("Введите три числа");
Console.WriteLine("первое:");
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("второе:");
b = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("третье:");
c = Convert.ToInt32(Console.ReadLine());

res = 0;

for (int i = 0; i < 32; i++)
{
    count = ((a >> i) & 1) + ((b >> i) & 1) + ((c >> i) & 1);

    if (count >= 2)
    {
        res |= (1 << i);
    }
}

Console.WriteLine($"Новое число: {res}");