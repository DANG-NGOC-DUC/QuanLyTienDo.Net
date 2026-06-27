using System.Windows;
using WorkProgressManagement.Helpers;

namespace WorkProgressManagement
{
    public partial class App : Application
    {
        public App()
        {
            SQLiteDatabaseInitializer.InitializeDatabase();
        }
    }
}