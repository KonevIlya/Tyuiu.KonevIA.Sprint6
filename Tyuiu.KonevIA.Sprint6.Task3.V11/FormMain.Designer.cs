namespace Tyuiu.KonevIA.Sprint6.Task3.V11;
partial class FormMain
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dataGridViewInput_KIA;
    private DataGridView dataGridViewResult_KIA;
    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private static DataGridView CreateGrid(string name, bool readOnly)
    {
        var grid = new DataGridView { Name = name, ReadOnly = readOnly, Dock = DockStyle.Fill,
            AllowUserToAddRows = false, AllowUserToDeleteRows = false, RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = SystemColors.Window };
        for (int i = 0; i < 5; i++) grid.Columns.Add("Column" + i, (i+1).ToString());
        return grid;
    }
    private void InitializeComponent()
    {
        Text = "Спринт 6 | Задание 3 | Вариант 11 | Конев И. А.";
        ClientSize = new Size(880, 420);
        MinimumSize = new Size(896, 459);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 10F);
        var condition = new GroupBox { Text = "Условие", Location = new Point(16,16), Size = new Size(848,86) };
        condition.Controls.Add(new Label { Text = "Дана матрица 5 × 5. Отсортировать первый столбец по возрастанию.\nОстальные столбцы сохранить. Результат вывести в DataGridView.", Location = new Point(16,28), AutoSize = true });
        var input = new GroupBox { Text = "Исходная матрица", Location = new Point(16,118), Size = new Size(416,210) };
        var output = new GroupBox { Text = "Результат", Location = new Point(448,118), Size = new Size(416,210) };
        dataGridViewInput_KIA = CreateGrid("dataGridViewInput_KIA", false);
        dataGridViewResult_KIA = CreateGrid("dataGridViewResult_KIA", true);
        input.Controls.Add(dataGridViewInput_KIA);
        output.Controls.Add(dataGridViewResult_KIA);
        var help = new Button { Text = "Справка", Location = new Point(594,354), Size = new Size(120,44) };
        help.Click += buttonHelp_KIA_Click;
        var calculate = new Button { Text = "Выполнить", Location = new Point(730,354), Size = new Size(134,44) };
        calculate.Click += buttonCalculate_KIA_Click;
        AcceptButton = calculate;
        Controls.AddRange(new Control[] { condition, input, output, help, calculate });
    }
}
