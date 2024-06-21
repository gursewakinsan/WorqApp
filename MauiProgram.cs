using Mopups.Hosting;
using ZXing.Net.Maui.Controls;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace WorqApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
                .ConfigureMopups()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("PoppinsBold.ttf", "PoppinsBoldFontFamily");
                    fonts.AddFont("PoppinsExtraBold.ttf", "PoppinsExtraBoldFontFamily");
                    fonts.AddFont("PoppinsRegular.ttf", "PoppinsRegularFontFamily");
                    fonts.AddFont("PoppinsSemiBold.ttf", "PoppinsSemiBoldFontFamily");
                    fonts.AddFont("SFProDisplayBold.ttf", "SFProDisplayBoldFontFamily");
                    fonts.AddFont("SFProDisplayLight.ttf", "SFProDisplayLightFontFamily");
                    fonts.AddFont("SFProDisplayMedium.ttf", "SFProDisplayMediumFontFamily");
                    fonts.AddFont("SFProDisplayRegular.ttf", "SFProRegularFontFamily");
                    fonts.AddFont("SFProDisplaySemibold.ttf", "SFProSemiboldFontFamily");
                    fonts.AddFont("MaterialDesignIcons.ttf", "MaterialFontFamily");
                });
            RegisterHandler();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        static void RegisterHandler()
        {
            //Entry Handler
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });

            //Picker Handler
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}
