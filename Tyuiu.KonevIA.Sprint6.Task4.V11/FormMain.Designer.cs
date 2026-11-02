using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task4.V11;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private TextBox startBox,stopBox,resultBox;
    private Panel graph;
    private Button saveButton;
    protected override void Dispose(bool disposing){if(disposing)components?.Dispose();base.Dispose(disposing);}
    private void InitializeComponent()
    {
        Ui.Setup(this,4,11,1180,650);
        var layout=Ui.Layout(1,2);layout.RowStyles.Add(new RowStyle(SizeType.Absolute,112));layout.RowStyles.Add(new RowStyle(SizeType.Percent,100));
        var header=Ui.Layout(5,1);header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,280));for(int i=0;i<3;i++)header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,115));
        header.Controls.Add(Ui.Condition("F(x) = cos(x) + sin(x)/(2 − 2x) − 4x\nДиапазон [-5; 5], шаг 1. Округлить до 2 знаков.\nПри делении на ноль вернуть 0.\nВывести таблицу и график, сохранить в файл."),0,0);
        startBox=new TextBox{Text="-5"};stopBox=new TextBox{Text="5"};header.Controls.Add(Ui.Range(startBox,stopBox),1,0);
        header.Controls.Add(Ui.Button("Выполнить",Calculate,Color.Green),2,0);saveButton=Ui.Button("Сохранить",Save,Color.RoyalBlue);saveButton.Enabled=false;header.Controls.Add(saveButton,3,0);header.Controls.Add(Ui.Help(this,4,11),4,0);
        var split=new SplitContainer{Dock=DockStyle.Fill,Size=new Size(1150,500),SplitterDistance=300};
        resultBox=Ui.Text("textBoxResult_KIA");split.Panel1.Controls.Add(Ui.Group("Вывод:",resultBox));
        graph=new Panel{Dock=DockStyle.Fill,BackColor=Color.White};graph.Paint+=DrawGraph;graph.Resize+=(s,e)=>graph.Invalidate();split.Panel2.Controls.Add(graph);
        layout.Controls.Add(header,0,0);layout.Controls.Add(split,0,1);Controls.Add(layout);
    }
}
