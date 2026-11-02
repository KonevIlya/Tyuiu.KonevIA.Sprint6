using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task0.V26.Lib;
public class DataService : ISprint6Task0V26
{
    public double Calculate(int x) => Math.Round(((double)x * x + 1) / (3.0 * x + 4), 3);
}
