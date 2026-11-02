namespace Tyuiu.KonevIA.Sprint6.Task6.V21;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private TextBox textBoxIn, textBoxOut;
    private Button runButton;
    private Label pathLabel;
    protected override void Dispose(bool disposing)
    {
        if(disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        Text="Спринт 6 | Задание 6 | Вариант 21 | Конев И. А.";
        ClientSize=new Size(1000,560); MinimumSize=new Size(1016,599);
        Font=new Font("Segoe UI",10F); StartPosition=FormStartPosition.CenterScreen;
        var condition=new GroupBox { Text="Условие",Location=new Point(16,16),Size=new Size(968,90) };
        condition.Controls.Add(new Label { Text="Загрузить InPutFileTask6V21.txt через диалог выбора файла.\nВывести в результирующую строку слова, содержащие латинскую букву g.",Location=new Point(16,28),AutoSize=true });
        var input=new GroupBox { Text="Исходный текст",Location=new Point(16,122),Size=new Size(476,340) };
        var output=new GroupBox { Text="Результат",Location=new Point(508,122),Size=new Size(476,340) };
        textBoxIn=new TextBox { Name="textBoxIn",Multiline=true,ReadOnly=true,ScrollBars=ScrollBars.Both,Dock=DockStyle.Fill };
        textBoxOut=new TextBox { Name="textBoxOut",Multiline=true,ReadOnly=true,ScrollBars=ScrollBars.Both,Dock=DockStyle.Fill };
        input.Controls.Add(textBoxIn); output.Controls.Add(textBoxOut);
        pathLabel=new Label { Text="Файл не выбран",Location=new Point(16,480),Size=new Size(450,60),AutoEllipsis=true };
        var open=new Button { Text="Открыть файл",Location=new Point(492,480),Size=new Size(152,44) }; open.Click+=OpenFile;
        var help=new Button { Text="Справка",Location=new Point(662,480),Size=new Size(152,44) };
        help.Click+=(s,e)=>MessageBox.Show(this,"Конев Илья Андреевич\nНТм-25-1\nСпринт 6 | Задание 6 | Вариант 21","О программе");
        runButton=new Button { Text="Выполнить",Location=new Point(832,480),Size=new Size(152,44),Enabled=false }; runButton.Click+=Run;
        Controls.AddRange(new Control[]{condition,input,output,pathLabel,open,help,runButton});
    }
}
