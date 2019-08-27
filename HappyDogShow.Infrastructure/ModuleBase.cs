using HappyDogShow.Infrastructure.WPF;
using HappyDogShow.Infrastructure.WPF.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure
{
    public abstract class ModuleBase : IModule
    {
        protected IRegionManager RegionManager { get; private set; }
        protected IUnityContainer Container { get; private set; }

        public ModuleBase(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterTypes();
            InitializeModule();
        }

        protected abstract void InitializeModule();

        protected abstract void RegisterTypes();

        protected void RegisterViewWithRegionUsingViewModel<T>(string regionName) where T : IViewViewModel
        {
            IViewViewModel vm = Container.Resolve<T>();
            RegionManager.Regions[regionName].Add(vm.View);
        }

    }
}
