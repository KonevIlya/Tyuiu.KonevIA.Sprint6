namespace Tyuiu.KonevIA.Sprint6.Task2.V4;
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}


