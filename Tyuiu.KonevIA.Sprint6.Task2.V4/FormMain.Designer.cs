namespace Tyuiu.KonevIA.Sprint6.Task2.V4;
partial class FormMain
{
    private System.ComponentModel.IContainer components = null;
    private TextBox textBoxStart_KIA;
    private TextBox textBoxStop_KIA;
    private DataGridView dataGridViewResult_KIA;
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        Text = "Спринт 6 | Задание 2 | Вариант 4 | Конев И. А.";
        ClientSize = new Size(850, 460);
        MinimumSize = new Size(866, 499);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 10F);
        var condition = new GroupBox { Text = "Условие", Location = new Point(16, 16), Size = new Size(470, 220) };
        condition.Controls.Add(new Label { Text = "Табулировать функцию на отрезке [-5; 5]\nс шагом 1. Округлить значения до двух знаков.\nПри делении на ноль вернуть 0.", Location = new Point(16, 30), AutoSize = true });
        condition.Controls.Add(new Label { Text = "F(x) = (5x + 2,5) / (sin(x) + 2) + 2x + 2", Font = new Font("Segoe UI", 12F), Location = new Point(16, 130), AutoSize = true });
        var input = new GroupBox { Text = "Ввод данных", Location = new Point(16, 250), Size = new Size(470, 100) };
        input.Controls.Add(new Label { Text = "Начало:", Location = new Point(16, 30), AutoSize = true });
        input.Controls.Add(new Label { Text = "Конец:", Location = new Point(250, 30), AutoSize = true });
        textBoxStart_KIA = new TextBox { Name = "textBoxStart_KIA", Text = "-5", Location = new Point(16, 56), Width = 190, TabIndex = 0 };
        textBoxStop_KIA = new TextBox { Name = "textBoxStop_KIA", Text = "5", Location = new Point(250, 56), Width = 190, TabIndex = 1 };
        input.Controls.AddRange(new Control[] { textBoxStart_KIA, textBoxStop_KIA });
        var output = new GroupBox { Text = "Вывод данных", Location = new Point(502, 16), Size = new Size(332, 428), Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
        dataGridViewResult_KIA = new DataGridView
        {
            Name = "dataGridViewResult_KIA", Dock = DockStyle.Fill,
            ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
            RowHeadersVisible = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = SystemColors.Window, TabIndex = 4
        };
        dataGridViewResult_KIA.Columns.Add("X", "x");
        dataGridViewResult_KIA.Columns.Add("Fx", "F(x)");
        dataGridViewResult_KIA.Columns[1].DefaultCellStyle.Format = "F2";
        dataGridViewResult_KIA.Columns[1].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
        output.Controls.Add(dataGridViewResult_KIA);
        var help = new Button { Text = "Справка", Location = new Point(214, 376), Size = new Size(120, 44), TabIndex = 3 };
        help.Click += buttonHelp_KIA_Click;
        var calculate = new Button { Text = "Выполнить", Location = new Point(350, 376), Size = new Size(136, 44), TabIndex = 2 };
        calculate.Click += buttonCalculate_KIA_Click;
        AcceptButton = calculate;
        Controls.AddRange(new Control[] { condition, input, output, help, calculate });
    }
}

