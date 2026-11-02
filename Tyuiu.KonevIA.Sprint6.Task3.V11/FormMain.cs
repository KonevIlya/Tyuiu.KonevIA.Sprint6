using Tyuiu.KonevIA.Sprint6.Task3.V11.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task3.V11;
public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
        int[,] matrix = { {27,-15,14,2,27}, {-8,14,-10,33,0}, {1,7,-11,-11,23}, {-13,-20,15,-16,34}, {-3,1,-1,5,1} };
        ShowMatrix(dataGridViewInput_KIA, matrix);
    }
    private static void ShowMatrix(DataGridView grid, int[,] matrix)
    {
        grid.RowCount = matrix.GetLength(0);
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                grid[j, i].Value = matrix[i, j];
    }
    private void buttonCalculate_KIA_Click(object sender, EventArgs e)
    {
        dataGridViewInput_KIA.EndEdit();
        var matrix = new int[5,5];
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                if (!int.TryParse(Convert.ToString(dataGridViewInput_KIA[j,i].Value), out matrix[i,j]))
                {
                    MessageBox.Show(this, $"Введите целое число: строка {i+1}, столбец {j+1}.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
        ShowMatrix(dataGridViewResult_KIA, new DataService().Calculate(matrix));
    }
    private void buttonHelp_KIA_Click(object sender, EventArgs e) =>
        MessageBox.Show(this, "Выполнил: Конев Илья Андреевич\nГруппа: НТм-25-1\nСпринт 6 | Задание 3 | Вариант 11", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
