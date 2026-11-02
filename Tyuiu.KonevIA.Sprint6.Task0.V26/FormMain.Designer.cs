namespace Tyuiu.KonevIA.Sprint6.Task0.V26;
partial class FormMain
{
    private System.ComponentModel.IContainer components = null;
    private TextBox textBoxInput_KIA;
    private TextBox textBoxResult_KIA;
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        Text = "Спринт 6 | Задание 0 | Вариант 26 | Конев И. А.";
        ClientSize = new Size(760, 360);
        MinimumSize = new Size(680, 380);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 10F);
        var condition = new GroupBox { Text = "Условие", Location = new Point(16, 16), Size = new Size(728, 145), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
        condition.Controls.Add(new Label { Text = "Вычислить значение выражения при x = 3.\nРезультат округлить до трёх знаков после запятой.", Location = new Point(16, 28), AutoSize = true });
        condition.Controls.Add(new Label { Text = "y(x) = (x² + 1) / (3x + 4)", Font = new Font("Segoe UI", 16F), Location = new Point(16, 86), AutoSize = true });
        var input = new GroupBox { Text = "Ввод данных", Location = new Point(16, 178), Size = new Size(340, 90) };
        input.Controls.Add(new Label { Text = "x =", Location = new Point(16, 35), AutoSize = true });
        textBoxInput_KIA = new TextBox { Name = "textBoxInput_KIA", Text = "3", Location = new Point(60, 31), Width = 250, TabIndex = 0 };
        input.Controls.Add(textBoxInput_KIA);
        var output = new GroupBox { Text = "Вывод данных", Location = new Point(374, 178), Size = new Size(370, 90) };
        output.Controls.Add(new Label { Text = "y =", Location = new Point(16, 35), AutoSize = true });
        textBoxResult_KIA = new TextBox { Name = "textBoxResult_KIA", ReadOnly = true, Location = new Point(60, 31), Width = 285, TabIndex = 1 };
        output.Controls.Add(textBoxResult_KIA);
        var help = new Button { Text = "Справка", Location = new Point(474, 290), Size = new Size(120, 42), TabIndex = 3 };
        help.Click += buttonHelp_KIA_Click;
        var calculate = new Button { Text = "Выполнить", Location = new Point(610, 290), Size = new Size(134, 42), TabIndex = 2 };
        calculate.Click += buttonCalculate_KIA_Click;
        AcceptButton = calculate;
        Controls.AddRange(new Control[] { condition, input, output, help, calculate });
    }
}
