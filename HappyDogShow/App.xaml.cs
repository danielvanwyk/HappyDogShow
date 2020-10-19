using HappyDogShow.Data;
using HappyDogShow.Data.Migrations;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HappyDogShow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Bootstrapper bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            PerformBackup();

            //try
            //{
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<HappyDogShowContext, Data.Migrations.Configuration>());

            //    using (var db = new HappyDogShowContext())
            //    {
            //        var breeds = db.Breeds.Where(b => b.Name == "Great Dane");
            //        int count = breeds.Count();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.IO.File.WriteAllText("logfile.error.txt", ex.Message);
            //}

            bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private static void PerformBackup()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["HappyDogShowDBConnectionString"].ConnectionString;
                var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);
                string backupFileName = string.Format("HappyDogShow.Database.Backup.{0}.{1}.bak", sqlConStrBuilder.InitialCatalog, DateTime.Now.ToString("yyyyMMdd.HHmmss"));
                string query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'", sqlConStrBuilder.InitialCatalog, backupFileName);

                using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }

        public App()
    : base()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            this.Exit += App_Exit;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            PerformBackup();
        }

        private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //log.Fatal("unhandled exception", e.Exception);
            MetroWindow metroWindow = Application.Current.MainWindow as MetroWindow;
            metroWindow.ShowMessageAsync("Unexpected problem", string.Format("We hit an unexpected problem.  Please let us know about this, and keep the following detail handy:\n{0}", e.Exception.Message), MessageDialogStyle.Affirmative);
            e.Handled = true;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // do stuff here with the modules that need to be closed
            if (bootstrapper != null)
            {
                bootstrapper.Stop();
            }

            base.OnExit(e);
        }

    }
}
