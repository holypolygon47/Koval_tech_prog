using System;

int N, K, n, znak;

Console.WriteLine("введите делимое");
N = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("введите делитель");
K = Convert.ToInt32(Console.ReadLine());

if (K == 0)
{
    Console.WriteLine("на ноль делить нельзя");
}

n = 0;
znak = 1;

if (((N < 0) & (K >= 0)) | ((N > 0) & (K <= 0)))
    znak = -1;

N = Math.Abs(N);
K = Math.Abs(K);

while (N >= K)
{
    N -= K;
    n++;
}

Console.WriteLine($"целая часть {znak * n}, остаток {N}");