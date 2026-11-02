using Sprint6Presentation;
namespace Tyuiu.KonevIA.Sprint6.Task3.V11;
partial class FormMain
{
    private System.ComponentModel.IContainer components=null;
    private DataGridView dataGridViewInput_KIA,dataGridViewResult_KIA;
    protected override void Dispose(bool disposing){if(disposing)components?.Dispose();base.Dispose(disposing);}
    private void InitializeComponent()
    {
        Ui.Setup(this,3,11,1020,480);
        var layout=Ui.Layout(3,2);layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,34));layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33));layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,33));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent,100));layout.RowStyles.Add(new RowStyle(SizeType.Absolute,65));
        layout.Controls.Add(Ui.Condition("Дана матрица 5 × 5:\n27 -15  14   2  27\n-8  14 -10  33   0\n 1   7 -11 -11  23\n-13 -20 15 -16  34\n-3   1  -1   5   1\n\nВыполнить сортировку\nпо возрастанию\nв первом столбце."),0,0);
        dataGridViewInput_KIA=Ui.Grid("dataGridViewInput_KIA",false);dataGridViewResult_KIA=Ui.Grid("dataGridViewResult_KIA");
        foreach(var grid in new[]{dataGridViewInput_KIA,dataGridViewResult_KIA}) {grid.ColumnHeadersVisible=false;for(int j=0;j<5;j++)grid.Columns.Add("C"+j,"");grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;}
        layout.Controls.Add(Ui.Group("Ввод данных:",dataGridViewInput_KIA),1,0);layout.Controls.Add(Ui.Group("Вывод данных — результат:",dataGridViewResult_KIA),2,0);
        var buttons=new FlowLayoutPanel {Dock=DockStyle.Fill,FlowDirection=FlowDirection.RightToLeft};buttons.Controls.Add(Ui.Button("Выполнить",buttonCalculate_KIA_Click,SystemColors.Control));buttons.Controls.Add(Ui.Help(this,3,11));
        layout.Controls.Add(buttons,0,1);layout.SetColumnSpan(buttons,3);Controls.Add(layout);
    }
}
