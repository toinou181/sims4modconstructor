using Sims4ModConstructor.Tests;

namespace Sims4ModConstructor;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // Run tests if --test argument is provided
        if (args.Length > 0 && args[0] == "--test")
        {
            FunctionalTest.RunTests();
            return;
        }
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }    
}