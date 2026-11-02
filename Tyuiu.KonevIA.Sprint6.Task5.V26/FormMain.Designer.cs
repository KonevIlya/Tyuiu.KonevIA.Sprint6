namespace Tyuiu.KonevIA.Sprint6.Task5.V26;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private DataGridView grid;
    private Panel chart;
    private Label pathLabel;
    protected override void Dispose(bool disposing)
    {
        if(disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        Text="Спринт 6 | Задание 5 | Вариант 26 | Конев И. А.";
        ClientSize=new Size(1000,550); MinimumSize=new Size(1016,589);
        Font=new Font("Segoe UI",10F); StartPosition=FormStartPosition.CenterScreen;
        var condition=new GroupBox { Text="Условие",Location=new Point(16,16),Size=new Size(968,90) };
        condition.Controls.Add(new Label { Text="Прочитать InPutFileTask5V26.txt. Вывести числа, кратные 5, в DataGridView.\nПостроить диаграмму. Вещественные значения округлить до трёх знаков.",Location=new Point(16,28),AutoSize=true });
        var tableBox=new GroupBox { Text="Числа, кратные 5",Location=new Point(16,122),Size=new Size(290,340) };
        grid=new DataGridView { Name="dataGridViewResult_KIA",Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,RowHeadersVisible=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill,BackgroundColor=Color.White };
        grid.Columns.Add("Number","№"); grid.Columns.Add("Value","Значение");
        grid.Columns[1].DefaultCellStyle.Format="F3";
        grid.Columns[1].DefaultCellStyle.FormatProvider=System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
        tableBox.Controls.Add(grid);
        var chartBox=new GroupBox { Text="Диаграмма",Location=new Point(322,122),Size=new Size(662,340) };
        chart=new Panel { Dock=DockStyle.Fill,BackColor=Color.White }; chart.Paint+=DrawChart; chart.Resize+=(s,e)=>chart.Invalidate();
        chartBox.Controls.Add(chart);
        pathLabel=new Label { Text="Файл не выбран",Location=new Point(16,480),Size=new Size(610,50),AutoEllipsis=true };
        var open=new Button { Text="Открыть файл",Location=new Point(820,480),Size=new Size(164,44) }; open.Click+=OpenFile;
        var help=new Button { Text="Справка",Location=new Point(650,480),Size=new Size(150,44) };
        help.Click+=(s,e)=>MessageBox.Show(this,"Конев Илья Андреевич\nНТм-25-1\nСпринт 6 | Задание 5 | Вариант 26","О программе");
        Controls.AddRange(new Control[]{condition,tableBox,chartBox,pathLabel,open,help});
    }
}
