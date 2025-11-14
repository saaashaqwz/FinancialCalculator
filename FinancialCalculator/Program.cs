namespace FinancialCalculator;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool exit = false;
        while (!exit)
        {
            ShowMenu();
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    LoanCalculator.Calculate();
                    break;
                case "2":
                    CurrencyConverter.Convert();
                    break;
                case "3":
                    DepositCalculator.Calculate();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("До свидания!");
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== ФИНАНСОВЫЙ КАЛЬКУЛЯТОР ===");
        Console.WriteLine("1. Расчет кредита");
        Console.WriteLine("2. Конвертер валют");
        Console.WriteLine("3. Калькулятор вкладов");
        Console.WriteLine("4. Выход");
        Console.Write("Выберите опцию: ");
    }
}