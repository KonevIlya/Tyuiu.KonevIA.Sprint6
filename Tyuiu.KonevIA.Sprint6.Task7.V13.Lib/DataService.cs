using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task7.V13.Lib;
public class DataService : ISprint6Task7V13
{
    public int[,] LoadMatrix(string path)
    {
        string[] lines = File.ReadAllLines(path).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        if (lines.Length == 0) return new int[0, 0];
        char separator = lines[0].Contains(';') ? ';' : ',';
        int columns = lines[0].Split(separator).Length;
        var matrix = new int[lines.Length, columns];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] cells = lines[i].Split(separator);
            if (cells.Length != columns) throw new FormatException("Строки матрицы имеют разную длину.");
            for (int j = 0; j < columns; j++)
                matrix[i, j] = int.Parse(cells[j].Trim());
        }
        return matrix;
    }
    public int[,] ReadMatrix(string path) => GetMatrix(path);
    public int[,] GetMatrix(string path)
    {
        int[,] matrix = LoadMatrix(path);
        if (matrix.GetLength(1) < 6) return matrix;
        for (int i = 0; i < matrix.GetLength(0); i++)
            if (matrix[i, 5] > 0 && matrix[i, 5] % 2 == 0)
                matrix[i, 5] = 111;
        return matrix;
    }
    public void SaveMatrix(string path, int[,] matrix)
    {
        using var writer = new StreamWriter(path);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var row = new string[matrix.GetLength(1)];
            for (int j = 0; j < row.Length; j++) row[j] = matrix[i, j].ToString();
            writer.WriteLine(string.Join(";", row));
        }
    }
}

