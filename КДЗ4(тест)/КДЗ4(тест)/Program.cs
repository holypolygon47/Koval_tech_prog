using System;
using System.Diagnostics;

class Program
{
    class Question
    {
        public string Text;
        public string[] Options;
        public int Correct; 

        public Question(string text, string[] options, int correct)
        {
            Text = text;
            Options = options;
            Correct = correct;
        }
    }

    static void Main()
    {
        var questions = new Question[]
        {
            new Question("Что такое C#?", new[] {
                "База данных", "Язык программирования", "Операционная система", "Браузер"
            }, 1),

            new Question("Как начинается метод в C#?", new[] {
                "start()", "main()", "Main()", "run()"
            }, 2),

            new Question("Что такое переменная?", new[] {
                "Цикл", "Тип данных", "Имя класса", "Область памяти с именем"
            }, 3),

            new Question("Какой тип для целого числа?", new[] {
                "float", "int", "string", "bool"
            }, 1),

            new Question("Что делает Console.WriteLine()?", new[] {
                "Читает строку", "Выводит в консоль", "Удаляет файл", "Закрывает программу"
            }, 1),

            new Question("Как объявить массив из 3 чисел?", new[] {
                "int[] a = [1,2,3];", "int a = {1,2,3};", "int[] a = new int[3];", "int[] a = {1,2,3};"
            }, 3),

            new Question("Какой оператор используется для условий?", new[] {
                "if", "when", "for", "loop"
            }, 0),

            new Question("Что такое class в C#?", new[] {
                "Цикл", "Условие", "Объект", "Шаблон для объектов"
            }, 3),

            new Question("Какой тип для текста?", new[] {
                "int", "bool", "string", "double"
            }, 2),

            new Question("Что такое bool?", new[] {
                "Тип текста", "Логический тип", "Целое число", "Символ"
            }, 1),
        };

        int correct = 0;
        var timer = Stopwatch.StartNew();

        for (int i = 0; i < questions.Length; i++)
        {
            Console.Clear();
            Console.WriteLine($"Вопрос {i + 1}/{questions.Length}:");
            Console.WriteLine(questions[i].Text);
            for (int j = 0; j < 4; j++)
                Console.WriteLine($"{j + 1}. {questions[i].Options[j]}");

            int answer = GetAnswer();
            if (answer == questions[i].Correct + 1)
                correct++;
        }

        timer.Stop();
        Console.Clear();
        Console.WriteLine("Тест завершён!");
        Console.WriteLine($"Правильных ответов: {correct} из {questions.Length}");
        Console.WriteLine(correct >= 7 ? "Тест пройден!" : "Тест не пройден");
        Console.WriteLine($"Время: {timer.Elapsed.TotalSeconds:F1} секунд");
        Console.ReadKey();
    }

    static int GetAnswer()
    {
        while (true)
        {
            Console.Write("Ваш ответ (1-4): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
                return choice;
            Console.WriteLine("Ошибка. Введите число от 1 до 4.");
        }
    }
}