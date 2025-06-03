using System;
using System.Linq;

class igra
{
    static void Main()
    {
        int rezhim;
        int chislo1;
        int chislo2;
        int trying;
        int korovi;
        int biki;
        bool h1;
        bool h2;

        chislo1 = 0;
        chislo2 = 0;
        korovi = 0;
        biki = 0;
        trying = 0;

        Console.WriteLine("Выберите режим");
        Console.WriteLine("против игрока 1, против комьпютера 2");
        rezhim = int.Parse(Console.ReadLine());

        if (rezhim != 2) //ввод игроком
        {
            Console.WriteLine("Игрок 1, введите задуманное число");
            chislo1 = int.Parse(Console.ReadLine());
        }
        else if (rezhim == 2) //ввод пк
        {
            Random rnd = new Random();
            chislo1 = rnd.Next(1000, 9999);
        }
        int[] digits1 = new int[4]; //число в массив
        {
            digits1[0] = chislo1 / 1000;
            digits1[1] = (chislo1 / 100) % 10;
            digits1[2] = (chislo1 / 10) % 10;
            digits1[3] = chislo1 % 10;
        }
        h2 = digits1.Length == digits1.Distinct().Count(); //проверка массива на уникальность
        while ((!h2) & (rezhim == 2))
        {
            Random rnd = new Random();
            chislo1 = rnd.Next(1000, 9999);
            digits1 = new int[4];
            {
                digits1[0] = chislo1 / 1000;
                digits1[1] = (chislo1 / 100) % 10;
                digits1[2] = (chislo1 / 10) % 10;
                digits1[3] = chislo1 % 10;
            }
            h2 = digits1.Length == digits1.Distinct().Count();
        }
        Console.WriteLine(chislo1);
        Console.Clear();
        while ((!h2) & (rezhim == 1))
        {
            Console.WriteLine("Игрок 1, цифры не должны повторяться, введите другое число");
            chislo1 = int.Parse(Console.ReadLine());
            digits1 = new int[4];
            {
                digits1[0] = chislo1 / 1000;
                digits1[1] = (chislo1 / 100) % 10;
                digits1[2] = (chislo1 / 10) % 10;
                digits1[3] = chislo1 % 10;
            }
            h2 = digits1.Length == digits1.Distinct().Count();
        }
        while (chislo1 != chislo2)
        {
            Console.WriteLine("Игрок 2, введите свое число");
            chislo2 = int.Parse(Console.ReadLine());
            int[] digits2 = new int[4];
            {
                digits2[0] = chislo2 / 1000;
                digits2[1] = (chislo2 / 100) % 10;
                digits2[2] = (chislo2 / 10) % 10;
                digits2[3] = chislo2 % 10;
            }
            korovi = 0;  // Обнуляем счетчики перед каждой проверкой
            biki = 0;

            for (int i = 0; i < 4; i++)
            {
                h1 = digits1.Contains(digits2[i]);
                if ((h1 == true) & digits2[i] != digits1[i])
                {
                    korovi++;
                }
                if (digits2[i] == digits1[i])
                {
                    biki++;
                }
            }
            trying++;
            Console.WriteLine("коров " + korovi + " быков " + biki);
        }
    }
}