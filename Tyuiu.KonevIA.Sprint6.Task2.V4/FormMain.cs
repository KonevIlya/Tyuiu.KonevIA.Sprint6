using System.Globalization;
using System.Text;
using Tyuiu.KonevIA.Sprint6.Task2.V4.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task2.V4;
public partial class FormMain : Form
{
    public FormMain() => InitializeComponent();
    private void buttonCalculate_KIA_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(textBoxStart_KIA.Text, out int start) ||
            !int.TryParse(textBoxStop_KIA.Text, out int stop) || stop < start || (long)stop - start > 10000)
        {
            MessageBox.Show(this, "Введите целые границы: начало ≤ конец, не более 10001 точки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        double[] values = new DataService().GetMassFunction(start, stop);
        dataGridViewResult_KIA.Rows.Clear();
        for (int i = 0; i < values.Length; i++)
            dataGridViewResult_KIA.Rows.Add((long)start + i, values[i]);
    }
    private void buttonHelp_KIA_Click(object sender, EventArgs e) =>
        MessageBox.Show(this, "Выполнил: Конев Илья Андреевич\nГруппа: НТм-25-1\nСпринт 6 | Задание 2 | Вариант 4", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
}

