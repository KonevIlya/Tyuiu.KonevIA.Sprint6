namespace Tyuiu.KonevIA.Sprint6.Task1.V7;
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}

