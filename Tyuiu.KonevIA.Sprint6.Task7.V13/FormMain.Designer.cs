namespace Tyuiu.KonevIA.Sprint6.Task7.V13;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private DataGridView dataGridViewIn,dataGridViewOut;
    private Button saveButton;
    private Label pathLabel;
    protected override void Dispose(bool disposing)
    {
        if(disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private static DataGridView CreateGrid(string name) => new DataGridView
    {
        Name=name,Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,
        RowHeadersVisible=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.DisplayedCells,BackgroundColor=Color.White
    };
    private void InitializeComponent()
    {
        Text="Спринт 6 | Задание 7 | Вариант 13 | Конев И. А.";
        ClientSize=new Size(1080,560); MinimumSize=new Size(1096,599);
        Font=new Font("Segoe UI",10F); StartPosition=FormStartPosition.CenterScreen;
        var condition=new GroupBox { Text="Условие",Location=new Point(16,16),Size=new Size(1048,90) };
        condition.Controls.Add(new Label { Text="Загрузить матрицу из InPutFileTask7V13.csv. В шестом столбце заменить положительные\nчётные числа на 111. Вывести результат и сохранить в OutPutFileTask7.csv.",Location=new Point(16,28),AutoSize=true });
        var input=new GroupBox { Text="Исходная матрица",Location=new Point(16,122),Size=new Size(516,340) };
        var output=new GroupBox { Text="Результат",Location=new Point(548,122),Size=new Size(516,340) };
        dataGridViewIn=CreateGrid("dataGridViewIn"); dataGridViewOut=CreateGrid("dataGridViewOut");
        input.Controls.Add(dataGridViewIn); output.Controls.Add(dataGridViewOut);
        pathLabel=new Label { Text="Файл не выбран",Location=new Point(16,480),Size=new Size(530,60),AutoEllipsis=true };
        var open=new Button { Text="Открыть CSV",Location=new Point(564,480),Size=new Size(150,44) }; open.Click+=OpenFile;
        var help=new Button { Text="Справка",Location=new Point(738,480),Size=new Size(150,44) };
        help.Click+=(s,e)=>MessageBox.Show(this,"Конев Илья Андреевич\nНТм-25-1\nСпринт 6 | Задание 7 | Вариант 13","О программе");
        saveButton=new Button { Text="Сохранить CSV",Location=new Point(912,480),Size=new Size(152,44),Enabled=false }; saveButton.Click+=SaveFile;
        Controls.AddRange(new Control[]{condition,input,output,pathLabel,open,help,saveButton});
    }
}
