﻿using System;
int a1, b1, c1, a2, b2, c2;

Console.WriteLine("введите стороны треугольника 1:");
a1 = Convert.ToInt32(Console.ReadLine());
b1 = Convert.ToInt32(Console.ReadLine());
c1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("введите стороны треугольника 2:");
a2 = Convert.ToInt32(Console.ReadLine());
b2 = Convert.ToInt32(Console.ReadLine());
c2 = Convert.ToInt32(Console.ReadLine());

int d1, e1, f1, d2, e2, f2;

d1 = Math.Max(a1, Math.Max(b1, c1));
e1 = Math.Min(a1, Math.Min(b1, c1));
f1 = a1 + b1 + c1 - d1 - e1;

d2 = Math.Max(a2, Math.Max(b2, c2));
e2 = Math.Min(a2, Math.Min(b2, c2));
f2 = a2 + b2 + c2 - d2 - e2;

if (((double)d1 / d2 == (double)e1 / e2) & ((double)e1 / e2 == (double)f1 / f2))
{
    Console.WriteLine("подобны");
}
else
{
    Console.WriteLine("не подобны");
}