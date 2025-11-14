namespace FinancialCalculator;

public class InputHelper
{
    public static double ReadPositiveDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            Console.WriteLine("Ошибка: введите положительное число");
        }
    }

    public static int ReadPositiveInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            Console.WriteLine("Ошибка: введите положительное целое число");
        }
    }
    
    public static double ReadNonNegativeDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;
            Console.WriteLine("Ошибка: введите неотрицательное число");
        }
    }

    public static string ReadCurrency(string prompt)
    {
        string[] valid = { "RUB", "USD", "EUR" };
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim().ToUpper();
            if (Array.IndexOf(valid, input) != -1)
                return input;
            Console.WriteLine("Ошибка: поддерживаются только RUB, USD, EUR");
        }
    }
}