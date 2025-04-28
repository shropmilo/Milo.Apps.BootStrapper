using System.Windows;
using Milo.Core;
using Milo.Core.Messaging;
using Milo.Core.Views;

namespace Milo.Apps.Playground.WPF
{
    /// <summary>
    /// Interaction logic for PlaygroundMainWindow.xaml
    /// </summary>
    public partial class PlaygroundMainWindow : Window
    {
        public IMiloMessageService? MessageService { get; }

        public IMiloViewManager? ViewManager { get; }

        public PlaygroundMainWindow()
        {
            MessageService = MiloCore.Services.GetService<IMiloMessageService>();
            ViewManager = MiloCore.Services.GetService<IMiloViewManager>();

            InitializeComponent();
        }
    }
}
