using HappyDogShow.Infrastructure;
using HappyDogShow.ViewModels;
using HappyDogShow.Views;
using HappyDogShow.Modules.Dogs;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using System.Windows.Data;
using HappyDogShow.Infrastructure.WPF.Infrastructure;
using System.Windows.Controls.Primitives;

namespace HappyDogShow
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            IShellView v = Container.Resolve<IShellView>();
            v.ViewModel = Container.Resolve<IShellViewViewModel>();

            return (v as System.Windows.DependencyObject);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IShellView, ShellView>(new HierarchicalLifetimeManager());
            Container.RegisterType<IShellViewViewModel, ShellViewViewModel>(new HierarchicalLifetimeManager());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();

            catalog.AddModule(typeof(DogsModule));

            return catalog;
        }

        internal void Stop()
        {
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            //RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();

            RegionAdapterMappings mappings = Container.Resolve<RegionAdapterMappings>();
            mappings.RegisterMapping(typeof(Selector), Container.Resolve<SelectorRegionAdapter>());
            mappings.RegisterMapping(typeof(ItemsControl), Container.Resolve<ItemsControlRegionAdapter>());
            mappings.RegisterMapping(typeof(ContentControl), Container.Resolve<MyContentControlRegionAdapter>());

            //mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            //mappings.RegisterMapping(typeof(DockPanel), Container.Resolve<DockPanelRegionAdapter>());

            return mappings;
        }

    }

    public class MyContentControlRegionAdapter : ContentControlRegionAdapter  //RegionAdapterBase<ContentControl>
    {
        public MyContentControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, ContentControl regionTarget)
        {
            if (regionTarget == null) throw new ArgumentNullException("regionTarget");
            bool contentIsSet = regionTarget.Content != null;
            contentIsSet = contentIsSet || (BindingOperations.GetBinding(regionTarget, ContentControl.ContentProperty) != null);

            if (contentIsSet)
            {
                throw new InvalidOperationException();
            }

            region.ActiveViews.CollectionChanged += delegate
            {
                var content = region.ActiveViews.FirstOrDefault();

                if (content != null)
                {
                    if (content is IViewViewModel)
                    {
                        var newContent = (content as IViewViewModel).View;
                        regionTarget.Content = newContent;
                    }
                    else
                        regionTarget.Content = content;
                }
                else
                {
                    regionTarget.Content = content;
                }

                //regionTarget.Content = region.ActiveViews.FirstOrDefault();
            };

            region.Views.CollectionChanged += (sender, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add && region.ActiveViews.Count() == 0)
                {
                    region.Activate(e.NewItems[0]);
                }
            };
        }

        //protected override IRegion CreateRegion()
        //{
        //    return new SingleActiveRegion();
        //}
    }

}
