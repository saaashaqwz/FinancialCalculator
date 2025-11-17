namespace FinancialCalculator;

public class CurrencyConverter
{
    private static readonly Dictionary<string, Dictionary<string, double>> Rates = new()
    {
        { "USD", new Dictionary<string, double> { { "RUB", 80.49 } } },
        { "EUR", new Dictionary<string, double> { { "RUB", 94.02 }, { "USD", 1.16 } } },
        { "RUB", new Dictionary<string, double>() }
    };

    static CurrencyConverter()
    {
        Rates["RUB"]["USD"] = 1 / Rates["USD"]["RUB"];
        Rates["RUB"]["EUR"] = 1 / Rates["EUR"]["RUB"];
        Rates["USD"]["EUR"] = 1 / Rates["EUR"]["USD"];
    }

    public static void Convert()
    {
        Console.Clear();
        Console.WriteLine("=== КОНВЕРТЕР ВАЛЮТ ===");

        string from = InputHelper.ReadCurrency("Исходная валюта (RUB, USD, EUR): ");
        string to = InputHelper.ReadCurrency("Целевая валюта (RUB, USD, EUR): ");
        double amount = InputHelper.ReadPositiveDouble("Сумма для конвертации: ");

        if (from == to)
        {
            Console.WriteLine($"\n{amount:F2} {from} = {amount:F2} {to}");
            return;
        }

        if (!Rates.ContainsKey(from) || !Rates[from].ContainsKey(to))
        {
            Console.WriteLine("Ошибка: конвертация между выбранными валютами не поддерживается.");
            return;
        }

        double rate = Rates[from][to];
        double result = amount * rate;

        Console.WriteLine($"\n{amount:F2} {from} = {result:F2} {to}");
    }
}