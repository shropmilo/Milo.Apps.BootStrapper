using System.Windows;
using Milo.Core.BootStrap;

namespace Milo.Apps.Playground.WPF
{
    internal class PlaygroundBootStrapApp : IMiloBootStrapApplication
    {
        public string Name => nameof(PlaygroundBootStrapApp);

        public void Start()
        {
            var main = new PlaygroundMainWindow();
            main.Show();

            Application.Current.MainWindow = main;

            Started?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
           
        }


        public event EventHandler? Started;
    }
}
