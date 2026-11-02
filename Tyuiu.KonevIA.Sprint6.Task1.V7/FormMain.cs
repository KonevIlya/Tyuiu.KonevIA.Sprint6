using System.Globalization;
using System.Text;
using Tyuiu.KonevIA.Sprint6.Task1.V7.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task1.V7;
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
        var table = new StringBuilder("    x           F(x)\r\n-----------------------\r\n");
        var culture = CultureInfo.GetCultureInfo("ru-RU");
        for (int i = 0; i < values.Length; i++)
            table.AppendLine($"{(long)start + i,5}   {values[i].ToString("F2", culture),12}");
        textBoxResult_KIA.Text = table.ToString();
    }
    private void buttonHelp_KIA_Click(object sender, EventArgs e) =>
        MessageBox.Show(this, "Выполнил: Конев Илья Андреевич\nГруппа: НТм-25-1\nСпринт 6 | Задание 1 | Вариант 7", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
