using LeftModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LeftModule
{
    public class ModuleLoader : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var reginManager = containerProvider.Resolve<IRegionManager>();
            reginManager.RegisterViewWithRegion("LeftRegion",typeof(MessageVIew));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
