using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.UI;
using WinUICommunity;

namespace Weather.History
{
    internal static class AppEx
    {
        internal static void PaintTitleBarButtons(this IThemeService themeService)
        {
            themeService.ConfigTitleBar(new TitleBarCustomization
            {
                LightTitleBarButtons = new TitleBarButtons
                {
                    ButtonBackgroundColor = Colors.Azure,
                    ButtonForegroundColor = Colors.DarkGreen,
                    BackgroundColor = Colors.Brown,
                    ForegroundColor = Colors.Honeydew
                },
                DarkTitleBarButtons = new TitleBarButtons
                {
                    ButtonBackgroundColor = Colors.Tan,
                    ButtonForegroundColor = Colors.Teal,
                    BackgroundColor = Colors.Violet,
                    ForegroundColor = Colors.CadetBlue
                }
            });
        }
    }
}
