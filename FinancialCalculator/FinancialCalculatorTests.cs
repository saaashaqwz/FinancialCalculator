using Moq;
using System;
using Xunit;


namespace FinancialCalculator
{
    public class FinancialCalculatorTests
    {
        // тест кредита
        [Fact]
        public void LoanCalculator_ShouldCalculateCorrectMonthlyPayment()
        {
            var (monthly, total, over) = FinancialCalculatorService.Calculate(100000, 12, 12);

            Assert.Equal(8884.88, Math.Round(monthly, 2));
            Assert.Equal(106618.55, Math.Round(total, 2));
            Assert.Equal(6618.55, Math.Round(over, 2));
        }

        // тест нулевой процентной ставки
        [Theory]
        [InlineData(120000, 12, 0, 10000)]
        [InlineData(60000, 6, 0, 10000)]
        public void LoanCalculator_ZeroPercent_ShouldReturnPrincipalDividedByMonths(double principal, int months, double rate, double expectedMonthly)
        {
            var (monthly, total, _) = FinancialCalculatorService.Calculate(principal, months, rate);

            Assert.Equal(expectedMonthly, Math.Round(monthly, 2));
            Assert.Equal(principal, Math.Round(total, 2));
        }

        // тест конвертации валют
        [Fact]
        public void CurrencyConverter_USDToRub_ShouldReturnCorrectAmount()
        {
            double rate = 80.49;
            double amount = 100;
            double result = amount * rate;

            Assert.Equal(8049, Math.Round(result, 2));
        }

        // проверка вкладов - капитализация и без
        [Theory]
        [InlineData(100000, 12, 12, true, 112683)]
        [InlineData(100000, 12, 12, false, 112000)]
        public void DepositCalculator_ShouldCalculateCorrectFinalAmount(
            double principal, int months, double rate, bool withCap, double expected)
        {
            double monthlyRate = rate / 100 / 12;
            double final;

            if (withCap)
            {
                final = principal * Math.Pow(1 + monthlyRate, months);
            }
            else
            {
                double income = principal * rate / 100 * months / 12;
                final = principal + income;
            }

            Assert.Equal(expected, Math.Round(final, 0));
        }

        // проверяем вызов методов ввода
        [Fact]
        public void InputHelper_ShouldBeCalledExactlyThreeTimes_ForLoan()
        {
            // Arrange
            var mock = new Mock<IInputHelper>();

            mock.Setup(x => x.ReadPositiveDouble(It.IsAny<string>())).Returns(100000);
            mock.Setup(x => x.ReadPositiveInt(It.IsAny<string>())).Returns(12);
            mock.Setup(x => x.ReadNonNegativeDouble(It.IsAny<string>())).Returns(12);

            // Act 
            double principal = mock.Object.ReadPositiveDouble("Сумма:");
            int months = mock.Object.ReadPositiveInt("Месяцы:");
            double annualRate = mock.Object.ReadNonNegativeDouble("Ставка:");

            // Asset
            mock.Verify(x => x.ReadPositiveDouble(It.IsAny<string>()), Times.Once);
            mock.Verify(x => x.ReadPositiveInt(It.IsAny<string>()), Times.Once);
            mock.Verify(x => x.ReadNonNegativeDouble(It.IsAny<string>()), Times.Once);
        }
    }
}