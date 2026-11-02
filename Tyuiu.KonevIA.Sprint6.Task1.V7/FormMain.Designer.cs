namespace Tyuiu.KonevIA.Sprint6.Task1.V7;
partial class FormMain
{
    private System.ComponentModel.IContainer components = null;
    private TextBox textBoxStart_KIA;
    private TextBox textBoxStop_KIA;
    private TextBox textBoxResult_KIA;
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        Text = "Спринт 6 | Задание 1 | Вариант 7 | Конев И. А.";
        ClientSize = new Size(850, 460);
        MinimumSize = new Size(866, 499);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 10F);
        var condition = new GroupBox { Text = "Условие", Location = new Point(16, 16), Size = new Size(470, 220) };
        condition.Controls.Add(new Label { Text = "Табулировать функцию на отрезке [-5; 5]\nс шагом 1. Округлить значения до двух знаков.\nПри делении на ноль вернуть 0.", Location = new Point(16, 30), AutoSize = true });
        condition.Controls.Add(new Label { Text = "F(x) = (2x − 3) / (cos(x) + x) + 5", Font = new Font("Segoe UI", 15F), Location = new Point(16, 130), AutoSize = true });
        var input = new GroupBox { Text = "Ввод данных", Location = new Point(16, 250), Size = new Size(470, 100) };
        input.Controls.Add(new Label { Text = "Начало:", Location = new Point(16, 30), AutoSize = true });
        input.Controls.Add(new Label { Text = "Конец:", Location = new Point(250, 30), AutoSize = true });
        textBoxStart_KIA = new TextBox { Name = "textBoxStart_KIA", Text = "-5", Location = new Point(16, 56), Width = 190, TabIndex = 0 };
        textBoxStop_KIA = new TextBox { Name = "textBoxStop_KIA", Text = "5", Location = new Point(250, 56), Width = 190, TabIndex = 1 };
        input.Controls.AddRange(new Control[] { textBoxStart_KIA, textBoxStop_KIA });
        var output = new GroupBox { Text = "Вывод данных", Location = new Point(502, 16), Size = new Size(332, 428), Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
        textBoxResult_KIA = new TextBox { Name = "textBoxResult_KIA", Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Both, WordWrap = false, Font = new Font("Consolas", 11F), Dock = DockStyle.Fill, TabIndex = 4 };
        output.Controls.Add(textBoxResult_KIA);
        var help = new Button { Text = "Справка", Location = new Point(214, 376), Size = new Size(120, 44), TabIndex = 3 };
        help.Click += buttonHelp_KIA_Click;
        var calculate = new Button { Text = "Выполнить", Location = new Point(350, 376), Size = new Size(136, 44), TabIndex = 2 };
        calculate.Click += buttonCalculate_KIA_Click;
        AcceptButton = calculate;
        Controls.AddRange(new Control[] { condition, input, output, help, calculate });
    }
}
