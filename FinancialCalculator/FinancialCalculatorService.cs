namespace FinancialCalculator;

public class FinancialCalculatorService
{
    public static (double Monthly, double Total, double Overpayment) Calculate(double principal, int months, double annualRate)
    {
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

        return (monthlyPayment, totalPayment, overpayment);
    }
}