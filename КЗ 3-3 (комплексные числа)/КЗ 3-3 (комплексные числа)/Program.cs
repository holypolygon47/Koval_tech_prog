using System;

class ComplexNumber
{
    public double Re { get; }
    public double Im { get; }

    public ComplexNumber(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public override string ToString()
    {
        if (Im == 0) return $"{Re}";
        if (Re == 0) return $"{Im}i";
        var sign = Im > 0 ? "+" : "-";
        return $"{Re} {sign} {Math.Abs(Im)}i";
    }

    public double Modulus() => Math.Sqrt(Re * Re + Im * Im);
    public double Argument() => Math.Atan2(Im, Re); // в радианах

    public ComplexNumber Add(ComplexNumber other) =>
        new ComplexNumber(Re + other.Re, Im + other.Im);

    public ComplexNumber Multiply(ComplexNumber other) =>
        new ComplexNumber(Re * other.Re - Im * other.Im,
                          Re * other.Im + Im * other.Re);

    public ComplexNumber Divide(ComplexNumber other)
    {
        double denom = other.Re * other.Re + other.Im * other.Im;
        double re = (Re * other.Re + Im * other.Im) / denom;
        double im = (Im * other.Re - Re * other.Im) / denom;
        return new ComplexNumber(re, im);
    }

    public ComplexNumber Power(int n)
    {
        double r = Math.Pow(Modulus(), n);
        double theta = Argument() * n;
        return new ComplexNumber(r * Math.Cos(theta), r * Math.Sin(theta));
    }

    public ComplexNumber[] Roots(int n)
    {
        var roots = new ComplexNumber[n];
        double r = Math.Pow(Modulus(), 1.0 / n);
        double theta = Argument();
        for (int k = 0; k < n; k++)
        {
            double angle = (theta + 2 * Math.PI * k) / n;
            roots[k] = new ComplexNumber(r * Math.Cos(angle), r * Math.Sin(angle));
        }
        return roots;
    }
}
class Program
{
    static void Main()
    {
        var a = new ComplexNumber(3, 4);
        var b = new ComplexNumber(1, -2);

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine($"z1 + z2 = {a.Add(b)}");
        Console.WriteLine($"z1 * z2 = {a.Multiply(b)}");
        Console.WriteLine($"z1 / z2 = {a.Divide(b)}");
        Console.WriteLine($"|z1| = {a.Modulus()}");
        Console.WriteLine($"arg(z1) = {a.Argument()} рад");

        Console.WriteLine($"z1^3 = {a.Power(3)}");
        Console.WriteLine($"Корни 3 степени из z1:");
        foreach (var root in a.Roots(3))
            Console.WriteLine(root);
    }
}