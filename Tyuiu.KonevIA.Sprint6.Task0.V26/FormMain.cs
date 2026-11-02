using System.Globalization;
using Tyuiu.KonevIA.Sprint6.Task0.V26.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task0.V26;
public partial class FormMain : Form
{
    public FormMain() => InitializeComponent();
    private void buttonCalculate_KIA_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(textBoxInput_KIA.Text, out int x))
        {
            MessageBox.Show(this, "Введите целое число x.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBoxInput_KIA.Focus();
            return;
        }
        textBoxResult_KIA.Text = new DataService().Calculate(x).ToString(CultureInfo.GetCultureInfo("ru-RU"));
    }
    private void buttonHelp_KIA_Click(object sender, EventArgs e) =>
        MessageBox.Show(this, "Выполнил: Конев Илья Андреевич\nГруппа: НТм-25-1\nСпринт 6 | Задание 0 | Вариант 26", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
