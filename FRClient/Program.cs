using FavoRetweeter;
using KAPLibNet;

// TODO:IME! IME!
// TODO:暇なときに逆連動する機能も欲しいなァ。


namespace FRClient
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

            try {
                ApplicationConfiguration.Initialize();

                Application.Run(new FRClientForm());
            } catch (Exception ex) {
                MessageBox.Show(
                    $"{ex.Message}\n\n{ex.StackTrace}", 
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            } finally {
                ViewerSetting.Save();
            }
        }
    }
}