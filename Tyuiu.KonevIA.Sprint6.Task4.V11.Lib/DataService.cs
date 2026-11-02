using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task4.V11.Lib;
public class DataService : ISprint6Task4V11
{
    public double[] GetMassFunction(int startValue, int stopValue)
    {
        if (stopValue < startValue)
            throw new ArgumentException("Конец диапазона должен быть не меньше начала.");
        var values = new double[stopValue - startValue + 1];
        for (int i = 0; i < values.Length; i++)
        {
            double x = (double)startValue + i;
            double denominator = 2 - 2 * x;
            values[i] = denominator == 0 ? 0 : Math.Round(Math.Cos(x) + Math.Sin(x) / denominator - 4 * x, 2);
        }
        return values;
    }
}

