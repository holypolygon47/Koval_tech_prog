using System;

// Рекурсивный факториал
static int FactorialRec(int n)
{
    if (n <= 1) return 1;
    return n * FactorialRec(n - 1);
}

// Итеративный факториал
static int FactorialIter(int n)
{
    int result = 1;
    for (int i = 2; i <= n; i++)
        result *= i;
    return result;
}

// Рекурсивный фибоначчи
static int FibonacciRec(int n)
{
    if (n <= 1) return n;
    return FibonacciRec(n - 1) + FibonacciRec(n - 2);
}

// Итеративный фибоначчи
static int FibonacciIter(int n)
{
    if (n <= 1) return n;
    int a = 0, b = 1;
    for (int i = 2; i <= n; i++)
    {
        int temp = a + b;
        a = b;
        b = temp;
    }
    return b;
}

Console.WriteLine("Факториал 5 (рекурсивно): " + FactorialRec(5));
Console.WriteLine("Факториал 5 (итеративно): " + FactorialIter(5));
Console.WriteLine("Фибоначчи 7 (рекурсивно): " + FibonacciRec(7));
Console.WriteLine("Фибоначчи 7 (итеративно): " + FibonacciIter(7));
