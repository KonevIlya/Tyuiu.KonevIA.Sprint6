using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task5.V26.Lib;
public class DataService : ISprint6Task5V26
{
    public double[] LoadFromDataFile(string path)
    {
        var result = new List<double>();
        foreach (string token in File.ReadAllText(path).Split(new[] {' ', '\t', '\r', '\n', ';'}, StringSplitOptions.RemoveEmptyEntries))
        {
            double value = double.Parse(token.Replace(',', '.'), CultureInfo.InvariantCulture);
            if (value % 5 == 0)
                result.Add(Math.Round(value, 3));
        }
        return result.ToArray();
    }
}
