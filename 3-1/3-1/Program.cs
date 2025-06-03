using System;
static string ToBin(int num, int bits = 32)
{
    return Convert.ToString(num, 2).PadLeft(bits, '0');
}

int num1, num2;

Console.Write("Введите первое число: ");
num1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите второе число: ");
num2 = Convert.ToInt32(Console.ReadLine());

string binary1 = ToBin(num1);
string binary2 = ToBin(num2);

Console.WriteLine($"Первое число в двоичном виде: {binary1}");
Console.WriteLine($"Второе число в двоичном виде: {binary2}");

int sum = num1 + num2;
string binarySum = ToBin(sum);

Console.WriteLine($"Сумма в двоичном виде:        {binarySum}");
Console.WriteLine($"Сумма в десятичном виде: {sum}");