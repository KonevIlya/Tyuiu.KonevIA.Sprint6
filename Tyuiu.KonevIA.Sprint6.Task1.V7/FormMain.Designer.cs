using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task1.V7;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private TextBox textBoxStart_KIA,textBoxStop_KIA,textBoxResult_KIA;
    protected override void Dispose(bool disposing) {if(disposing)components?.Dispose();base.Dispose(disposing);}
    private void InitializeComponent()
    {
        Ui.Setup(this,1,7,940,470);
        var layout=Ui.Layout(2,2); layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,65));layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,35));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent,100));layout.RowStyles.Add(new RowStyle(SizeType.Absolute,92));
        layout.Controls.Add(Ui.Condition("Протабулировать F(x) = (2x − 3) / (cos(x) + x) + 5\nна заданном диапазоне [-5; 5] с шагом 1.\nРезультат вывести в виде таблицы.\nОкруглить до двух знаков. При делении на ноль вернуть 0."),0,0);
        textBoxResult_KIA=Ui.Text("textBoxResult_KIA");
        var result=Ui.Group("Вывод данных — результат:",textBoxResult_KIA);layout.Controls.Add(result,1,0);layout.SetRowSpan(result,2);
        var bottom=Ui.Layout(3,1);bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,112));bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,135));
        textBoxStart_KIA=new TextBox{Text="-5"};textBoxStop_KIA=new TextBox{Text="5"};
        bottom.Controls.Add(Ui.Range(textBoxStart_KIA,textBoxStop_KIA),0,0);
        bottom.Controls.Add(Ui.Help(this,1,7),1,0);bottom.Controls.Add(Ui.Button("Выполнить",buttonCalculate_KIA_Click,Color.Green),2,0);
        layout.Controls.Add(bottom,0,1);Controls.Add(layout);
    }
}
