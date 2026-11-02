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
        help.Click+=(s,e)=>MessageBox.Show(this,"Конев Илья Андреевич\nНТм-25-1\nСпринт 6 | Задание 7 | Вариант 13","О программе");
        toolbar.Controls.Add(actions); toolbar.Controls.Add(help);
        var condition=new GroupBox { Text="Условие:",Dock=DockStyle.Top,Height=92,Padding=new Padding(10) };
        condition.Controls.Add(new Label { Dock=DockStyle.Fill,Font=new Font("Consolas",10F),Text="Дан файл InPutFileTask7V13.csv с матрицей целых чисел. Загрузить файл через\nOpenFileDialog в dataGridViewIn. В шестом столбце заменить положительные чётные\nэлементы на 111. Результат вывести в dataGridViewOut и сохранить через\nSaveFileDialog в OutPutFileTask7.csv." });
        var split=new SplitContainer { Dock=DockStyle.Fill,Orientation=Orientation.Vertical,SplitterWidth=6,Size=new Size(1000,350),SplitterDistance=575 };
        var input=new GroupBox { Text="Ввод:",Dock=DockStyle.Fill,Padding=new Padding(10) };
        var output=new GroupBox { Text="Вывод:",Dock=DockStyle.Fill,Padding=new Padding(10) };
        dataGridViewIn=CreateGrid("dataGridViewIn"); dataGridViewOut=CreateGrid("dataGridViewOut");
        input.Controls.Add(dataGridViewIn); output.Controls.Add(dataGridViewOut);
        split.Panel1.Controls.Add(input); split.Panel2.Controls.Add(output);
        pathLabel=new Label { Text="Файл не выбран",Dock=DockStyle.Bottom,Height=22,AutoEllipsis=true };
        Controls.Add(split); Controls.Add(pathLabel); Controls.Add(condition); Controls.Add(toolbar);
    }
}
