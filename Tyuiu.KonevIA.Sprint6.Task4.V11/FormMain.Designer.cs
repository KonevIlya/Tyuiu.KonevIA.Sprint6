namespace Tyuiu.KonevIA.Sprint6.Task4.V11;
partial class FormMain
{
    private System.ComponentModel.IContainer components = null;
    private TextBox startBox, stopBox, resultBox;
    private Panel graph;
    private Button saveButton;
    protected override void Dispose(bool disposing)
    {
        if(disposing) components?.Dispose();
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        Text="Спринт 6 | Задание 4 | Вариант 11 | Конев И. А.";
        ClientSize=new Size(1050,600); MinimumSize=new Size(1066,639);
        StartPosition=FormStartPosition.CenterScreen; Font=new Font("Segoe UI",10F);
        var condition=new GroupBox { Text="Условие", Location=new Point(16,16),Size=new Size(1018,100) };
        condition.Controls.Add(new Label { Text="F(x) = cos(x) + sin(x) / (2 − 2x) − 4x\nДиапазон [-5; 5], шаг 1. При делении на ноль вернуть 0. Округлить до двух знаков.", AutoSize=true,Location=new Point(16,28) });
        var input=new GroupBox { Text="Ввод данных",Location=new Point(16,130),Size=new Size(400,100) };
        input.Controls.Add(new Label { Text="Начало:",Location=new Point(16,27),AutoSize=true });
        input.Controls.Add(new Label { Text="Конец:",Location=new Point(210,27),AutoSize=true });
        startBox=new TextBox { Text="-5",Location=new Point(16,55),Width=170 };
        stopBox=new TextBox { Text="5",Location=new Point(210,55),Width=170 };
        input.Controls.AddRange(new Control[]{startBox,stopBox});
        var result=new GroupBox { Text="Таблица значений",Location=new Point(16,245),Size=new Size(400,330) };
        resultBox=new TextBox { Multiline=true,ReadOnly=true,ScrollBars=ScrollBars.Both,WordWrap=false,Dock=DockStyle.Fill,Font=new Font("Consolas",11F) };
        result.Controls.Add(resultBox);
        var graphBox=new GroupBox { Text="График функции",Location=new Point(432,130),Size=new Size(602,375) };
        graph=new Panel { Dock=DockStyle.Fill,BackColor=Color.White };
        graph.Paint+=DrawGraph; graph.Resize+=(s,e)=>graph.Invalidate(); graphBox.Controls.Add(graph);
        var run=new Button { Text="Выполнить",Location=new Point(890,530),Size=new Size(144,44) }; run.Click+=Calculate;
        saveButton=new Button { Text="Сохранить",Location=new Point(730,530),Size=new Size(144,44),Enabled=false }; saveButton.Click+=Save;
        var help=new Button { Text="Справка",Location=new Point(570,530),Size=new Size(144,44) };
        help.Click+=(s,e)=>MessageBox.Show(this,"Конев Илья Андреевич\nНТм-25-1\nСпринт 6 | Задание 4 | Вариант 11","О программе");
        AcceptButton=run;
        Controls.AddRange(new Control[]{condition,input,result,graphBox,run,saveButton,help});
    }
}
