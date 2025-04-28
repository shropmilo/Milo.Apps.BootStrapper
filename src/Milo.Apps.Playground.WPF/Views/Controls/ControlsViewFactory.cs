using Milo.Core.Views;

namespace Milo.Apps.Playground.WPF.Views.Controls
{
    class ControlsViewFactory : MiloViewFactoryBase
    {
        public override Guid UniqueGuid { get; }
        
        public override object Header { get; }
        
        public override Type ViewType { get; }
        public override Type ViewMetaType { get; }

        public override bool IsAvailable(object context)
        {
            return true;
        }
    }
}
