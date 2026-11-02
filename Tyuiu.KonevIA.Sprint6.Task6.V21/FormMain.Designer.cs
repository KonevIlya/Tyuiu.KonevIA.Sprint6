using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task6.V21;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private TextBox textBoxIn,textBoxOut;
    private Button runButton;
    private Label pathLabel;
    protected override void Dispose(bool disposing){if(disposing)components?.Dispose();base.Dispose(disposing);}
    private void InitializeComponent()
    {
        Ui.Setup(this,6,21,1080,650);
        var toolbar=new Panel{Dock=DockStyle.Top,Height=78,BorderStyle=BorderStyle.FixedSingle};
        var open=Ui.Button("📂\nОткрыть",OpenFile,SystemColors.Control);open.Location=new Point(4,4);
        runButton=Ui.Button("➜\nВыполнить",Run,SystemColors.Control);runButton.Location=new Point(124,4);runButton.Enabled=false;
        var help=Ui.Help(this,6,21);help.Text="❔\nО программе";help.Dock=DockStyle.Right;toolbar.Controls.AddRange(new Control[]{open,runButton,help});
        Ui.ToolbarIcon(open,"Открыть","open"); Ui.ToolbarIcon(runButton,"Выполнить","run"); Ui.ToolbarIcon(help,"О программе","help");
        var condition=Ui.Condition("Дан файл InPutFileTask6V21.txt, который может находиться в любом месте на диске.\nЗагрузить файл в textBoxIn через OpenFileDialog. Вывести слова, в которых\nвстречается латинская буква g, в результирующую строку textBoxOut.");condition.Dock=DockStyle.Top;condition.Height=94;
        var split=new SplitContainer{Dock=DockStyle.Fill,Size=new Size(1080,450),SplitterDistance=535};
        textBoxIn=Ui.Text("textBoxIn");textBoxOut=Ui.Text("textBoxOut");textBoxIn.WordWrap=true;textBoxOut.WordWrap=true;
        split.Panel1.Controls.Add(Ui.Group("Ввод:",textBoxIn));split.Panel2.Controls.Add(Ui.Group("Вывод:",textBoxOut));
        pathLabel=new Label{Text="Файл не выбран",Dock=DockStyle.Bottom,Height=22,AutoEllipsis=true};
        Controls.Add(split);Controls.Add(pathLabel);Controls.Add(condition);Controls.Add(toolbar);
    }
}

