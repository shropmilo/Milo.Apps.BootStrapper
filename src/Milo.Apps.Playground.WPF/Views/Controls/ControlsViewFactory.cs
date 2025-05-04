using Milo.Core.Views;

namespace Milo.Apps.Playground.WPF.Views.Controls
{
    class ControlsViewFactory : MiloViewFactoryBase
    {
        public override Guid UniqueGuid { get; }

        public override object Header => "Sample Controls";

        public override Type ViewType => typeof(ControlsMiloView);

        public override Type ViewMetaType => typeof(ControlsViewMeta);

        public override bool IsAvailable(object context)
        {
            return true;
        }
    }
}
