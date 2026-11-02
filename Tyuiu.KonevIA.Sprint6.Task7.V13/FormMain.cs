using Tyuiu.KonevIA.Sprint6.Task7.V13.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task7.V13;
public partial class FormMain : Form
{
    private int[,] result;
    public FormMain() => InitializeComponent();
    private static void ShowMatrix(DataGridView grid, int[,] matrix)
    {
        grid.Columns.Clear();
        for(int j=0;j<matrix.GetLength(1);j++) grid.Columns.Add("Column"+j,(j+1).ToString());
        grid.RowCount=matrix.GetLength(0);
        for(int i=0;i<matrix.GetLength(0);i++)
            for(int j=0;j<matrix.GetLength(1);j++) grid[j,i].Value=matrix[i,j];
    }
    private void OpenFile(object sender, EventArgs e)
    {
        using var dialog=new OpenFileDialog { Filter="CSV (*.csv)|*.csv|Все файлы (*.*)|*.*",FileName="InPutFileTask7V13.csv" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        try
        {
            var service=new DataService();
            int[,] input=service.ReadMatrix(dialog.FileName);
            if(input.GetLength(1)<6) throw new FormatException("В матрице должно быть не менее шести столбцов.");
            int[,] output=service.GetMatrix(dialog.FileName);
            ShowMatrix(dataGridViewIn,input);
            ShowMatrix(dataGridViewOut,output);
            result=output; saveButton.Enabled=true;
            pathLabel.Text=dialog.FileName;
        }
        catch(Exception ex) when(ex is IOException || ex is UnauthorizedAccessException || ex is FormatException || ex is OverflowException)
        { MessageBox.Show(this,ex.Message,"Ошибка чтения CSV"); }
    }
    private void SaveFile(object sender, EventArgs e)
    {
        using var dialog=new SaveFileDialog { Filter="CSV (*.csv)|*.csv",FileName="OutPutFileTask7.csv" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        try { new DataService().SaveMatrix(dialog.FileName,result); }
        catch(Exception ex) when(ex is IOException || ex is UnauthorizedAccessException)
        { MessageBox.Show(this,ex.Message,"Ошибка сохранения"); }
    }
}
