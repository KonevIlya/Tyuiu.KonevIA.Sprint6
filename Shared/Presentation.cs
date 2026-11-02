using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
namespace Sprint6Presentation;
internal static class Ui
{
    public static void Setup(Form form,int task,int variant,int width=1050,int height=570)
    {
        form.Text=$"Спринт 6 | Task {task} | Вариант {variant} | Конев И. А.";
        form.ClientSize=new Size(width,height); form.MinimumSize=new Size(850,480);
        form.StartPosition=FormStartPosition.CenterScreen; form.Font=new Font("Segoe UI",9F);
        form.BackColor=SystemColors.Control;
    }
    public static GroupBox Group(string title,Control child)
    {
        var group=new GroupBox { Text=title,Dock=DockStyle.Fill,Padding=new Padding(10) };
        child.Dock=DockStyle.Fill; group.Controls.Add(child); return group;
    }
    public static GroupBox Condition(string text) => Group("Условие:",new Label { Text=text,Font=new Font("Consolas",10F),AutoSize=false });
    public static Button Button(string text,EventHandler click,Color color)
    {
        var button=new Button { Text=text,Size=new Size(112,58),Margin=new Padding(5),BackColor=color,UseVisualStyleBackColor=false };
        button.Click+=click; return button;
    }
    public static void ToolbarIcon(Button button,string caption,string kind)
    {
        var image=new Bitmap(36,36);
        using(var g=Graphics.FromImage(image))
        {
            g.SmoothingMode=SmoothingMode.AntiAlias;
            using var outline=new Pen(Color.SteelBlue,1.5F);
            if(kind=="help")
            {
                g.FillEllipse(Brushes.DodgerBlue,2,2,31,31);
                using var font=new Font("Segoe UI",20F,FontStyle.Bold);
                g.DrawString("?",font,Brushes.White,7,-1);
            }
            else if(kind=="open")
            {
                g.FillRectangle(Brushes.Goldenrod,3,8,14,8);
                g.FillRectangle(Brushes.Gold,3,13,29,18);g.DrawRectangle(Pens.DarkGoldenrod,3,13,29,18);
                g.FillRectangle(Brushes.White,22,19,11,14);g.DrawRectangle(outline,22,19,11,14);
            }
            else if(kind=="save")
            {
                g.FillRectangle(Brushes.SteelBlue,4,3,28,30);g.FillRectangle(Brushes.White,9,4,17,10);g.FillRectangle(Brushes.LightBlue,9,20,18,12);g.DrawRectangle(outline,4,3,28,30);
            }
            else
            {
                g.FillRectangle(Brushes.White,4,3,21,29);g.DrawRectangle(outline,4,3,21,29);
                g.FillPolygon(Brushes.YellowGreen,new[]{new Point(17,19),new Point(25,19),new Point(25,14),new Point(35,24),new Point(25,33),new Point(25,28),new Point(17,28)});
            }
        }
        button.Text=caption;button.Image=image;button.TextImageRelation=TextImageRelation.ImageAboveText;
        button.BackColor=SystemColors.Control;button.Disposed+=(s,e)=>image.Dispose();
    }
    public static Button Help(Form form,int task,int variant)=>Button("Справка",(s,e)=>About(form,task,variant),Color.DodgerBlue);
    public static void About(Form owner,int task,int variant)
    {
        using var dialog=new Form { Text="О программе",ClientSize=new Size(600,245),FormBorderStyle=FormBorderStyle.FixedDialog,MaximizeBox=false,MinimizeBox=false,StartPosition=FormStartPosition.CenterParent };
        var photo=new PictureBox { Location=new Point(16,16),Size=new Size(145,195),SizeMode=PictureBoxSizeMode.Zoom,BorderStyle=BorderStyle.FixedSingle };
        string path=Path.Combine(AppContext.BaseDirectory,"author-photo.jpg");
        if(File.Exists(path)) { using var source=Image.FromFile(path); photo.Image=new Bitmap(source); }
        else dialog.Controls.Add(new Label { Text="Фото автора",Location=new Point(35,100),AutoSize=true });
        dialog.Controls.Add(photo);
        dialog.Controls.Add(new Label { Location=new Point(178,20),Size=new Size(405,155),Text=$"Разработчик: Конев Илья Андреевич\nГруппа: НТм-25-1\n\nПрограмма разработана в рамках изучения языка C#\nТюменский индустриальный университет\n\nВнутреннее имя: Tyuiu.KonevIA.Sprint6.Task{task}.V{variant}" });
        var ok=new Button { Text="ОК",DialogResult=DialogResult.OK,Location=new Point(480,192),Size=new Size(100,32) }; dialog.Controls.Add(ok); dialog.AcceptButton=ok;
        dialog.ShowDialog(owner); photo.Image?.Dispose();
    }
    public static DataGridView Grid(string name,bool readOnly=true) => new DataGridView { Name=name,Dock=DockStyle.Fill,ReadOnly=readOnly,AllowUserToAddRows=false,AllowUserToDeleteRows=false,RowHeadersVisible=false,BackgroundColor=SystemColors.AppWorkspace,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.DisplayedCells };
    public static TextBox Text(string name)=>new TextBox { Name=name,Multiline=true,ReadOnly=true,BackColor=Color.White,ScrollBars=ScrollBars.Both,WordWrap=false,Font=new Font("Consolas",10F),Dock=DockStyle.Fill };
    public static TableLayoutPanel Layout(int columns,int rows)
    {
        var layout=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=columns,RowCount=rows,Padding=new Padding(6) };
        return layout;
    }
    public static Control Range(TextBox start,TextBox stop)
    {
        var panel=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,RowCount=2 };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50)); panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));
        panel.Controls.Add(new Label {Text="Старт шага:",AutoSize=true},0,0); panel.Controls.Add(new Label {Text="Конец шага:",AutoSize=true},1,0);
        start.Dock=DockStyle.Top; stop.Dock=DockStyle.Top; panel.Controls.Add(start,0,1); panel.Controls.Add(stop,1,1);
        return Group("Ввод данных:",panel);
    }
}
internal sealed class FunctionPlot : Control
{
    public double[] Values {get;set;}=Array.Empty<double>();
    public int Start {get;set;}
    public string Title {get;set;}="График функции";
    public FunctionPlot() { DoubleBuffered=true; BackColor=Color.White; Dock=DockStyle.Fill; }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e); var g=e.Graphics; g.SmoothingMode=SmoothingMode.AntiAlias;
        using var titleFont=new Font("Segoe UI",12F,FontStyle.Bold);
        g.DrawString(Title,titleFont,Brushes.Navy,60,10);
        if(Values.Length==0) return;
        float left=60,top=50,w=Width-85,h=Height-100; if(w<=0||h<=0)return;
        double min=Math.Min(0,Values.Min()),max=Math.Max(0,Values.Max()); if(min==max) max=min+1;
        double pad=(max-min)*0.08; min-=pad; max+=pad;
        float X(int i)=>left+(Values.Length==1?w/2:w*i/(Values.Length-1));
        float Y(double y)=>top+(float)((max-y)/(max-min))*h;
        for(int i=0;i<=5;i++) { float y=top+h*i/5; g.DrawLine(Pens.Gray,left,y,left+w,y); g.DrawString((max-(max-min)*i/5).ToString("0.##"),Font,Brushes.Black,2,y-8); }
        int stride=Math.Max(1,(Values.Length-1)/10);
        for(int i=0;i<Values.Length;i+=stride) {g.DrawLine(Pens.LightGray,X(i),top,X(i),top+h);g.DrawString(((long)Start+i).ToString(),Font,Brushes.Black,X(i)-6,top+h+8);}
        g.DrawRectangle(Pens.Black,left,top,w,h);
        using var pen=new Pen(Color.SteelBlue,2);
        for(int i=0;i<Values.Length;i++) { if(i>0)g.DrawLine(pen,X(i-1),Y(Values[i-1]),X(i),Y(Values[i])); g.FillEllipse(Brushes.SteelBlue,X(i)-2,Y(Values[i])-2,4,4); }
    }
}


