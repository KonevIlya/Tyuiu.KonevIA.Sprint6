using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task3.V11.Lib;
public class DataService : ISprint6Task3V11
{
    public int[,] Calculate(int[,] matrix)
    {
        if (matrix.GetLength(1) == 0) return matrix;
        int rows = matrix.GetLength(0);
        var column = new int[rows];
        for (int i = 0; i < rows; i++) column[i] = matrix[i, 0];
        Array.Sort(column);
        for (int i = 0; i < rows; i++) matrix[i, 0] = column[i];
        return matrix;
    }
}
