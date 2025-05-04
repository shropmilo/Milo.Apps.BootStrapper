using System.Windows;
using Milo.Controls.WPF;
using Milo.Core.Views;

namespace Milo.Apps.Playground.WPF.Views
{
    /// <summary>
    ///
    /// </summary>
    public class MiloViewBase : MiloSection, IMiloView
    {
        public IMiloViewMeta Meta { get; private set; }

        static MiloViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MiloViewBase), new FrameworkPropertyMetadata(typeof(MiloViewBase)));
        }

        public void Initialise(IMiloViewMeta meta)
        {
            Meta = meta;
        }
    }
}
