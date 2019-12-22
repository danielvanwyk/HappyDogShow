using HappyDogShow.Data;
using HappyDogShow.Data.Migrations;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
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

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HappyDogShowContext, Configuration>());

            using (var db = new HappyDogShowContext())
            {
                var breeds = db.Breeds.Where(b => b.Name == "Great Dane");
                int count = breeds.Count();
            }

            bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        public App()
    : base()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
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
