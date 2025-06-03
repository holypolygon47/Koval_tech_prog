﻿using System;

Console.WriteLine("Введите S: ");
string S = Console.ReadLine();
Console.WriteLine("Введите S1: ");
string S1 = Console.ReadLine();
static int Count(string S1, string S)
{
    int count = (S.Length - S.Replace(S1, "").Length) / S1.Length;
    return count;
}
Console.WriteLine($"количество вхождений S1 в S: {Count(S1, S)}");