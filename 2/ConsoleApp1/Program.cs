using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Простой калькулятор");
        Console.WriteLine("===================");

        while (true)
        {
            try
            {
                Console.Write("Введите первое число: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите оператор (+, -, *, /, %, ^): ");
                char operation = Convert.ToChar(Console.ReadLine());

                Console.Write("Введите второе число: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = Calculate(num1, num2, operation);
                Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Неверный формат ввода!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: Деление на ноль!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.Write("\nПродолжить? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                break;

            Console.WriteLine();
        }
    }

    static double Calculate(double a, double b, char operation)
    {
        return operation switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => b != 0 ? a / b : throw new DivideByZeroException(),
            '%' => a % b,
            '^' => Math.Pow(a, b),
            _ => throw new ArgumentException("Неизвестная операция")
        };
    }
}