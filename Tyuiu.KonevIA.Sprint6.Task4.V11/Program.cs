namespace Tyuiu.KonevIA.Sprint6.Task4.V11;
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}


