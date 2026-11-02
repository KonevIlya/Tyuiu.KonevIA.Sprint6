using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task2.V4;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private TextBox textBoxStart_KIA,textBoxStop_KIA;
    private DataGridView dataGridViewResult_KIA;
    private FunctionPlot plot;
    protected override void Dispose(bool disposing){if(disposing)components?.Dispose();base.Dispose(disposing);}
    private void InitializeComponent()
    {
        Ui.Setup(this,2,4,1180,520);
        var layout=Ui.Layout(2,2);layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,48));layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,52));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent,100));layout.RowStyles.Add(new RowStyle(SizeType.Absolute,92));
        layout.Controls.Add(Ui.Condition("Протабулировать функцию\nF(x) = (5x + 2,5) / (sin(x) + 2) + 2x + 2\nна диапазоне [-5; 5], шаг 1.\nРезультат вывести в DataGridView\nи построить график функции.\nОкруглить до двух знаков.\nПри делении на ноль вернуть 0."),0,0);
        var output=Ui.Layout(2,1);output.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,150));output.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
        dataGridViewResult_KIA=Ui.Grid("dataGridViewResult_KIA");dataGridViewResult_KIA.Columns.Add("X","X");dataGridViewResult_KIA.Columns.Add("Fx","F(X)");
        dataGridViewResult_KIA.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewResult_KIA.Columns[1].DefaultCellStyle.Format="F2";
        dataGridViewResult_KIA.Columns[1].DefaultCellStyle.FormatProvider=System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
        plot=new FunctionPlot();output.Controls.Add(dataGridViewResult_KIA,0,0);output.Controls.Add(plot,1,0);
        var result=Ui.Group("Вывод данных:",output);layout.Controls.Add(result,1,0);layout.SetRowSpan(result,2);
        var bottom=Ui.Layout(3,1);bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,112));bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,125));
        textBoxStart_KIA=new TextBox{Text="-5"};textBoxStop_KIA=new TextBox{Text="5"};bottom.Controls.Add(Ui.Range(textBoxStart_KIA,textBoxStop_KIA),0,0);
        bottom.Controls.Add(Ui.Help(this,2,4),1,0);bottom.Controls.Add(Ui.Button("Выполнить",buttonCalculate_KIA_Click,Color.Green),2,0);
        layout.Controls.Add(bottom,0,1);Controls.Add(layout);
    }
}
