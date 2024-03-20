using System;

using Microsoft.UI.Xaml;

#if WINDOWS
using System.Diagnostics;

using Windows.ApplicationModel;

using WinUICommunity;

#endif

using Prism.Ioc;
using Prism.Modularity;
using Prism;
using Prism.DryIoc;
using Prism.Events;
using Prism.Navigation.Regions;
using Uno.Extensions.Hosting;


using Microsoft.UI.Windowing;
using Windows.UI.WindowManagement;
using WinUIEx;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;

namespace Weather.History
{
    public sealed partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var moduleManager = Container.Resolve<IModuleManager>();

            moduleManager.LoadModuleCompleted += OnModuleLoaded;

            moduleManager.Run();
        }

        private void OnModuleLoaded(object sender, LoadModuleCompletedEventArgs e)
        {
            if (e.Error is null)
            {
//                Log4.Debug($"Module loaded : {e.ModuleInfo.ModuleName} [{e.ModuleInfo.State}]");
            }
            else
            {
  //              Log4.Error(e.Error);
            }
        }

        protected override UIElement CreateShell()
        {
            //           var shell = Container.Resolve<Shell>();
            //#if WINDOWS
            //            shell.Loaded += (s, e) =>
            //            {
            //                MainXamlRoot = (s as UIElement).XamlRoot;
            //            };
            //#endif
            //            return shell;

            return new UserControl();
        }

        protected override void Initialize(IApplicationBuilder builder)
        {
            base.Initialize(builder);

            Window = builder.Window;

            Window.Hide();

            Window.AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;

            ThemeService = new ThemeService();
            ThemeService.PaintTitleBarButtons();
            ThemeService.Initialize(Window);

            MaxWindow();
        }

        protected override void OnInitialized()
        {
//            var settingsProvider = Container.Resolve<ISettingsProvider>();

//            SwitchTheme(settingsProvider.ThemeMode);
//#if WINDOWS
//            var proc = Process.GetCurrentProcess();
//            var hwnd = proc.MainWindowHandle;
//            var geoService = Container.Resolve<IGeoService>();
//            var appService = new AppServiceHost(hwnd, geoService);

//            appService.Start();
//#endif
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }
    }
}
