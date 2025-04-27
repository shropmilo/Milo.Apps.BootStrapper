using System.Windows;
using Milo.Core;
using Milo.Core.BootStrap;

namespace Milo.Apps.Bootstrapper.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Get Splashscreen up and going - we'll load the re
            base.OnStartup(e);

            var splash = new MiloSplashScreen();
            splash.Show();

       
            var services = new PcServiceManager();
            services.Start();
            MiloCore.Start(services);

            if (MiloCore.Services?.GetService<IMiloBootStrapApplication>() is { } application)
            {
                splash.Progress = application.Name;

                application.Start();

                splash.Close();
            }
        }
    }
}
