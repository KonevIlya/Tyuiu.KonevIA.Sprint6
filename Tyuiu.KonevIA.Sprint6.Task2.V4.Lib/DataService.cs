using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task2.V4.Lib;
public class DataService : ISprint6Task2V4
{
    public double[] GetMassFunction(int startValue, int stopValue)
    {
        if (stopValue < startValue)
            throw new ArgumentException("Конец диапазона должен быть не меньше начала.");
        var values = new double[stopValue - startValue + 1];
        for (int i = 0; i < values.Length; i++)
        {
            double x = (double)startValue + i;
            double denominator = Math.Sin(x) + 2;
            values[i] = denominator == 0 ? 0 : Math.Round((5 * x + 2.5) / denominator + 2 * x + 2, 2);
        }
        return values;
    }
}

