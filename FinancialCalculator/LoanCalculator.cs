namespace FinancialCalculator;

public class LoanCalculator
{
    public static void Calculate()
    {
        Console.Clear();
        Console.WriteLine("=== РАСЧЕТ КРЕДИТА ===");

        double principal = InputHelper.ReadPositiveDouble("Сумма кредита (руб): ");
        int months = InputHelper.ReadPositiveInt("Срок кредита (месяцев): ");
        double annualRate = InputHelper.ReadNonNegativeDouble("Процентная ставка (% годовых): ");

        double monthlyRate = annualRate / 100 / 12;
        double monthlyPayment;

        if (monthlyRate == 0)
        {
            monthlyPayment = principal / months;
        }
        else
        {
            double power = Math.Pow(1 + monthlyRate, months);
            monthlyPayment = principal * (monthlyRate * power) / (power - 1);
        }

        double totalPayment = monthlyPayment * months;
        double overpayment = totalPayment - principal;

        Console.WriteLine("\n--- РЕЗУЛЬТАТ ---");
        Console.WriteLine($"Ежемесячный платеж: {monthlyPayment:F2} руб.");
        Console.WriteLine($"Общая сумма выплат: {totalPayment:F2} руб.");
        Console.WriteLine($"Переплата по кредиту: {overpayment:F2} руб.");
    }
}