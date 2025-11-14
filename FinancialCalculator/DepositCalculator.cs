namespace FinancialCalculator;

public class DepositCalculator
{
    public static void Calculate()
    {
        Console.Clear();
        Console.WriteLine("=== КАЛЬКУЛЯТОР ВКЛАДОВ ===");

        double principal = InputHelper.ReadPositiveDouble("Сумма вклада (руб): ");
        int months = InputHelper.ReadPositiveInt("Срок вклада (месяцев): ");
        double annualRate = InputHelper.ReadNonNegativeDouble("Процентная ставка (% годовых): ");

        Console.Write("Тип вклада (1 - с капитализацией, 2 - без капитализации): ");
        string typeChoice = Console.ReadLine()?.Trim();
        bool withCapitalization = typeChoice == "1";

        double finalAmount;
        double income;

        if (withCapitalization)
        {
            double monthlyRate = annualRate / 100 / 12;
            finalAmount = principal * Math.Pow(1 + monthlyRate, months);
        }
        else
        {
            income = principal * annualRate / 100 * months / 12;
            finalAmount = principal + income;
        }

        income = finalAmount - principal;

        Console.WriteLine("\n--- РЕЗУЛЬТАТ ---");
        Console.WriteLine($"Доход по вкладу: {income:F2} руб.");
        Console.WriteLine($"Итоговая сумма: {finalAmount:F2} руб.");
        Console.WriteLine($"Тип: {(withCapitalization ? "с капитализацией" : "без капитализации")}");
    }
}