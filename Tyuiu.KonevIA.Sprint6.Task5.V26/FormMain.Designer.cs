using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task5.V26;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private DataGridView grid;
    private Panel chart;
    private Label pathLabel;
    private Button runButton;
    protected override void Dispose(bool disposing){if(disposing)components?.Dispose();base.Dispose(disposing);}
    private void InitializeComponent()
    {
        Ui.Setup(this,5,26,1020,620);
        var layout=Ui.Layout(1,3);layout.RowStyles.Add(new RowStyle(SizeType.Absolute,105));layout.RowStyles.Add(new RowStyle(SizeType.Percent,100));layout.RowStyles.Add(new RowStyle(SizeType.Absolute,24));
        var header=Ui.Layout(4,1);header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));for(int i=0;i<3;i++)header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,120));
        header.Controls.Add(Ui.Condition("Прочитать InPutFileTask5V26.txt. Вывести в DataGridView\nчисла, кратные 5, и построить диаграмму.\nВещественные значения округлить до трёх знаков."),0,0);
        runButton=Ui.Button("Выполнить",ProcessFile,Color.Green);runButton.Enabled=false;header.Controls.Add(runButton,1,0);header.Controls.Add(Ui.Button("Открыть файл",OpenFile,Color.RoyalBlue),2,0);header.Controls.Add(Ui.Help(this,5,26),3,0);
        var output=Ui.Layout(2,1);output.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,180));output.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
        grid=Ui.Grid("dataGridViewResult_KIA");grid.Columns.Add("Number","№");grid.Columns.Add("Value","Значение");grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        grid.Columns[1].DefaultCellStyle.Format="F3";grid.Columns[1].DefaultCellStyle.FormatProvider=System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
        output.Controls.Add(Ui.Group("Вывод данных:",grid),0,0);
        chart=new Panel{Dock=DockStyle.Fill,BackColor=Color.White};chart.Paint+=DrawChart;chart.Resize+=(s,e)=>chart.Invalidate();output.Controls.Add(chart,1,0);
        pathLabel=new Label{Text="Файл не выбран",Dock=DockStyle.Fill,AutoEllipsis=true};
        layout.Controls.Add(header,0,0);layout.Controls.Add(output,0,1);layout.Controls.Add(pathLabel,0,2);Controls.Add(layout);
    }
}
