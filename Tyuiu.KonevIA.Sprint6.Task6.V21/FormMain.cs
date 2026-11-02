using Tyuiu.KonevIA.Sprint6.Task6.V21.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task6.V21;
public partial class FormMain : Form
{
    private string selectedPath;
    public FormMain() => InitializeComponent();
    private void OpenFile(object sender, EventArgs e)
    {
        using var dialog=new OpenFileDialog { Filter="Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",FileName="InPutFileTask6V21.txt" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        try
        {
            string text=File.ReadAllText(dialog.FileName);
            selectedPath=dialog.FileName;
            textBoxIn.Text=text;
            textBoxOut.Clear();
            pathLabel.Text=selectedPath;
            runButton.Enabled=true;
        }
        catch(Exception ex) when(ex is IOException || ex is UnauthorizedAccessException)
        { MessageBox.Show(this,ex.Message,"Ошибка чтения"); }
    }
    private void Run(object sender, EventArgs e)
    {
        try { textBoxOut.Text=new DataService().CollectTextFromFile(selectedPath); }
        catch(Exception ex) when(ex is IOException || ex is UnauthorizedAccessException)
        { MessageBox.Show(this,ex.Message,"Ошибка чтения"); }
    }
}
