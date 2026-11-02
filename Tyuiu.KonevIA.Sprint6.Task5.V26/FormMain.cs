using Tyuiu.KonevIA.Sprint6.Task5.V26.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task5.V26;
public partial class FormMain : Form
{
    private double[] values=Array.Empty<double>();
    public FormMain() => InitializeComponent();
    private void OpenFile(object sender, EventArgs e)
    {
        using var dialog=new OpenFileDialog { Filter="Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",FileName="InPutFileTask5V26.txt" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        try
        {
            double[] loaded=new DataService().LoadFromDataFile(dialog.FileName);
            values=loaded;
            grid.Rows.Clear();
            for(int i=0;i<values.Length;i++) grid.Rows.Add(i+1,values[i]);
            pathLabel.Text=dialog.FileName;
            chart.Invalidate();
            if(values.Length==0) MessageBox.Show(this,"В файле нет чисел, кратных 5.","Результат");
        }
        catch(Exception ex) when(ex is IOException || ex is UnauthorizedAccessException || ex is FormatException || ex is OverflowException)
        { MessageBox.Show(this,"Не удалось прочитать файл: "+ex.Message,"Ошибка чтения"); }
    }
    private void DrawChart(object sender, PaintEventArgs e)
    {
        if(values.Length==0) return;
        var g=e.Graphics;
        g.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        float left=65,top=25,width=chart.Width-90,height=chart.Height-70;
        if(width<=0 || height<=0) return;
        double min=Math.Min(0,values.Min()),max=Math.Max(0,values.Max());
        if(min==max) max=min+1;
        double margin=(max-min)*0.08; min-=margin; max+=margin;
        float Y(double value)=>top+(float)((max-value)/(max-min))*height;
        for(int i=0;i<=4;i++)
        {
            float y=top+height*i/4;
            g.DrawLine(Pens.Gainsboro,left,y,left+width,y);
            g.DrawString((max-(max-min)*i/4).ToString("0.###"),Font,Brushes.DimGray,0,y-8);
        }
        float zero=Y(0),step=width/values.Length;
        g.DrawLine(Pens.Gray,left,zero,left+width,zero);
        for(int i=0;i<values.Length;i++)
        {
            float y=Y(values[i]),barWidth=Math.Max(1,step*0.7f),x=left+step*i+step*0.15f;
            g.FillRectangle(Brushes.RoyalBlue,x,Math.Min(y,zero),barWidth,Math.Max(1,Math.Abs(y-zero)));
            if(values.Length<=20) g.DrawString((i+1).ToString(),Font,Brushes.Black,x,top+height+7);
        }
        g.DrawString("Значение",Font,Brushes.Black,left,2);
    }
}
