#if WINDOWS
using Windows.Foundation;
using Windows.Graphics;

using Microsoft.UI.Xaml;


using System.Runtime.InteropServices;

using WinUIEx;

using Vanara.PInvoke;
#endif

using System;

using Microsoft.UI.Windowing;
#if WINDOWS
using WinUICommunity;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Media;
#endif
#if ANDROID
using Android.Views;
#endif

namespace Weather.History
{
    public sealed partial class App
    {
        internal static IThemeService ThemeService;
        internal static Window Window;

#if WINDOWS
        internal static XamlRoot MainXamlRoot { get; private set; }
#endif

        internal static void EnableClicksOnTitlebar(FrameworkElement inputElement)
        {
            var nonClientInputSrc = InputNonClientPointerSource.GetForWindowId(Window.AppWindow.Id);

            GeneralTransform transformTxtBox = inputElement.TransformToVisual(null);
            Rect bounds = transformTxtBox.TransformBounds(new Rect(0, 0, inputElement.ActualWidth, inputElement.ActualHeight));

            // Windows.Graphics.RectInt32[] rects defines the area which allows click throughs in custom titlebar
            // it is non dpi-aware client coordinates. Hence, we convert dpi aware coordinates to non-dpi coordinates
            var scale = GeneralHelper.GetRasterizationScaleForElement(inputElement);
            var transparentRect = new RectInt32(
                _X: (int)Math.Round(bounds.X * scale),
                _Y: (int)Math.Round(bounds.Y * scale),
                _Width: (int)Math.Round(bounds.Width * scale),
                _Height: (int)Math.Round(bounds.Height * scale)
            );
            var rects = new RectInt32[] { transparentRect };

            nonClientInputSrc.SetRegionRects(NonClientRegionKind.Passthrough, rects); // areas defined will be click through and c
        }

        private static void MaxWindow()
        {
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(Window);

            User32.ShowWindow(hwnd, ShowWindowCommand.SW_MAXIMIZE);

            Window.Show();
        }

        private static void FullScreenWindow()
        {
            Window.SetWindowPresenter(AppWindowPresenterKind.FullScreen);
        }

        internal static void SwitchDefaultMode()
        {
#if WINDOWS
            ThemeService.SetElementTheme(ElementTheme.Default);
#endif
        }

        internal static void SwitchDarkMode()
        {
            ThemeService.SetElementTheme(ElementTheme.Dark);
        }

        internal static void SwitchLightMode()
        {
#if WINDOWS
            ThemeService.SetElementTheme(ElementTheme.Light);
#endif
        }
    }
}
