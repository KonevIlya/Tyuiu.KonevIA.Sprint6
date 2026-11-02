using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task1.V7.Lib;
public class DataService : ISprint6Task1V7
{
    public double[] GetMassFunction(int startValue, int stopValue)
    {
        if (stopValue < startValue)
            throw new ArgumentException("Конец диапазона должен быть не меньше начала.");
        var values = new double[stopValue - startValue + 1];
        for (int i = 0; i < values.Length; i++)
        {
            double x = (double)startValue + i;
            double denominator = Math.Cos(x) + x;
            values[i] = denominator == 0 ? 0 : Math.Round((2 * x - 3) / denominator + 5, 2);
        }
        return values;
    }
}
