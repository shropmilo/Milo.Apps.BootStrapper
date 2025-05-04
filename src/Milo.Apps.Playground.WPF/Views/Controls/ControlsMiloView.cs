using System.Windows;
using Milo.Core.Views;

namespace Milo.Apps.Playground.WPF.Views.Controls
{
    /// <summary>
    ///
    /// </summary>
    public class ControlsMiloView : MiloViewBase
    {
        static ControlsMiloView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ControlsMiloView), new FrameworkPropertyMetadata(typeof(ControlsMiloView)));
        }
    }

    public class ControlsViewMeta : MiloViewMetaBase
    {
        public override Guid UniqueGuid { get; }

        public override object Header { get; }

        public override object Context { get; set; }
    }
}
