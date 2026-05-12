using HID_Test_App.Presenters;
using HID_Test_App.Views;
using HID_Test_App.Services;

namespace HID_Test_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var hidService = new HidService();

            var mainForm = new MainForm(hidService);

            Application.Run(mainForm);
        }
    }
}