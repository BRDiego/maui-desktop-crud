using DesktopMauiCrud.MauiCrud.Core.Exceptions;

namespace DesktopMauiCrud.MauiCrud.Core
{
    public class BrownianMotionCalculator
    {
        public double[] GenerateBrownianMotion(double volatilityPercentage, double desiredAverageReturn,
            double initialPrice, int numDays)
        {
            if (numDays < 2)
            {
                InvalidFlowException.Raise();
            }

            Random rand = new();

            double[] prices = new double[numDays];
            prices[0] = initialPrice;

            for (int i = 1; i < numDays; i++)
            {
                double sample1 = 1.0 - rand.NextDouble();
                double sample2 = 1.0 - rand.NextDouble();
                double dayRandVariance = Math.Sqrt(-2.0 * Math.Log(sample1)) * Math.Cos(2.0 * Math.PI * sample2);

                double retornoDiario = desiredAverageReturn + volatilityPercentage * dayRandVariance;

                prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
            }

            return prices;
        }
    }
}
