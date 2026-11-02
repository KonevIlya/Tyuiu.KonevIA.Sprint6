using System.Globalization;
using System.Text;
using Tyuiu.KonevIA.Sprint6.Task4.V11.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task4.V11;
public partial class FormMain : Form
{
    private double[] values = Array.Empty<double>();
    private int rangeStart;
    public FormMain() => InitializeComponent();
    private void Calculate(object sender, EventArgs e)
    {
        if (!int.TryParse(startBox.Text, out int start) || !int.TryParse(stopBox.Text, out int stop) || stop < start || (long)stop-start > 10000)
        {
            MessageBox.Show(this, "Введите целые границы: начало ≤ конец, до 10001 точки.", "Ошибка ввода");
            return;
        }
        rangeStart = start;
        values = new DataService().GetMassFunction(start, stop);
        var table = new StringBuilder("    x           F(x)\r\n-----------------------\r\n");
        for (int i=0; i<values.Length; i++)
            table.AppendLine($"{(long)start+i,5}   {values[i].ToString("F2", CultureInfo.GetCultureInfo("ru-RU")),12}");
        resultBox.Text = table.ToString();
        graph.Invalidate();
        saveButton.Enabled = true;
    }
    private void Save(object sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog { FileName = "OutPutFileTask4V11.txt", Filter = "Текстовый файл (*.txt)|*.txt", InitialDirectory = Path.GetTempPath() };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try { File.WriteAllText(dialog.FileName, resultBox.Text); }
        catch (IOException ex) { MessageBox.Show(this, ex.Message, "Не удалось сохранить файл"); }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(this, ex.Message, "Не удалось сохранить файл"); }
    }
    private void DrawGraph(object sender, PaintEventArgs e)
    {
        if (values.Length == 0) return;
        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        float left=60, top=25, width=graph.ClientSize.Width-85, height=graph.ClientSize.Height-70;
        if (width<=0 || height<=0) return;
        double min=Math.Min(0,values.Min()), max=Math.Max(0,values.Max());
        if(max==min) max=min+1;
        double margin=(max-min)*0.08; min-=margin; max+=margin;
        float X(int i) => left+(values.Length==1 ? width/2 : width*i/(values.Length-1));
        float Y(double y) => top+(float)((max-y)/(max-min))*height;
        using var gridPen=new Pen(Color.Gainsboro);
        for(int i=0;i<=4;i++)
        {
            float y=top+height*i/4;
            g.DrawLine(gridPen,left,y,left+width,y);
            g.DrawString((max-(max-min)*i/4).ToString("0.##"),Font,Brushes.DimGray,2,y-8);
        }
        g.DrawRectangle(Pens.Gray,left,top,width,height);
        g.DrawLine(Pens.Gray,left,Y(0),left+width,Y(0));
        if(rangeStart<=0 && (long)rangeStart+values.Length-1>=0)
            g.DrawLine(Pens.Gray,X(-rangeStart),top,X(-rangeStart),top+height);
        using var linePen=new Pen(Color.RoyalBlue,2);
        for(int i=0;i<values.Length;i++)
        {
            // Не соединять точки через разрыв функции при x = 1.
            if(i>0 && (long)rangeStart+i!=1 && (long)rangeStart+i-1!=1)
                g.DrawLine(linePen,X(i-1),Y(values[i-1]),X(i),Y(values[i]));
            g.FillEllipse(Brushes.RoyalBlue,X(i)-3,Y(values[i])-3,6,6);
        }
        g.DrawString(rangeStart.ToString(),Font,Brushes.Black,left,top+height+8);
        g.DrawString(((long)rangeStart+values.Length-1).ToString(),Font,Brushes.Black,left+width-20,top+height+8);
        g.DrawString("x",Font,Brushes.Black,left+width+5,Y(0));
        g.DrawString("F(x)",Font,Brushes.Black,left,3);
    }
}
