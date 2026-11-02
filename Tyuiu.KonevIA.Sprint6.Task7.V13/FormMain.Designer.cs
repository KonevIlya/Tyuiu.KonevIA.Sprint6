using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task7.V13;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private DataGridView dataGridViewIn,dataGridViewOut;
    private Button saveButton,runButton;
    private Label pathLabel;
    protected override void Dispose(bool disposing)
    {
        if(disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private static DataGridView CreateGrid(string name) => new DataGridView
    {
        Name=name,Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,
        RowHeadersVisible=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.DisplayedCells,
        BackgroundColor=SystemColors.AppWorkspace,BorderStyle=BorderStyle.FixedSingle
    };
    private static Button CreateToolbarButton(string name,string symbol,string caption)
    {
        return new Button { Name=name,Text=symbol+"\n"+caption,Size=new Size(96,70),Margin=new Padding(3),
            Font=new Font("Segoe UI",10F),TextAlign=ContentAlignment.MiddleCenter };
    }
    private void InitializeComponent()
    {
        Text="Спринт 6 | Task 7 | Вариант 13 | Конев И. А.";
        ClientSize=new Size(1000,550); MinimumSize=new Size(850,480);
        Font=new Font("Segoe UI",9F); StartPosition=FormStartPosition.CenterScreen;
        var toolbar=new Panel { Dock=DockStyle.Top,Height=80,Padding=new Padding(4),BorderStyle=BorderStyle.FixedSingle };
        var actions=new FlowLayoutPanel { Dock=DockStyle.Left,Width=320,WrapContents=false };
        var open=CreateToolbarButton("buttonOpenFile_KIA","📂","Открыть"); open.Click+=OpenFile;
        runButton=CreateToolbarButton("buttonDone_KIA","➜","Выполнить"); runButton.Enabled=false; runButton.Click+=ProcessFile;
        saveButton=CreateToolbarButton("buttonSaveFile_KIA","💾","Сохранить"); saveButton.Enabled=false; saveButton.Click+=SaveFile;
        actions.Controls.AddRange(new Control[]{open,runButton,saveButton});
        var help=CreateToolbarButton("buttonHelp_KIA","❔","Справка"); help.Dock=DockStyle.Right;
        help.Click+=(s,e)=>Ui.About(this,7,13);

        Ui.ToolbarIcon(open,"Открыть","open"); Ui.ToolbarIcon(runButton,"Выполнить","run"); Ui.ToolbarIcon(saveButton,"Сохранить","save"); Ui.ToolbarIcon(help,"Справка","help");
        toolbar.Controls.Add(actions); toolbar.Controls.Add(help);
        var condition=Ui.Condition("Дан файл InPutFileTask7V13.csv с матрицей целых чисел. Загрузить файл через\nOpenFileDialog в dataGridViewIn. В шестом столбце заменить положительные чётные\nчисла на 111. Результат вывести в dataGridViewOut и сохранить в OutPutFileTask7.csv.");
        condition.Dock=DockStyle.Top; condition.Height=94;
        var split=new SplitContainer{Dock=DockStyle.Fill,Size=new Size(1000,350),SplitterDistance=575,SplitterWidth=6};
        dataGridViewIn=CreateGrid("dataGridViewIn");dataGridViewOut=CreateGrid("dataGridViewOut");
        split.Panel1.Controls.Add(Ui.Group("Ввод:",dataGridViewIn));split.Panel2.Controls.Add(Ui.Group("Вывод:",dataGridViewOut));
        pathLabel=new Label{Text="Файл не выбран",Dock=DockStyle.Bottom,Height=22,AutoEllipsis=true};
        Controls.Add(split);Controls.Add(pathLabel);Controls.Add(condition);Controls.Add(toolbar);
    }
}

