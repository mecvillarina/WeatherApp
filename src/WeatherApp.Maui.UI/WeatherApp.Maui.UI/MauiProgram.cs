using CommunityToolkit.Maui;
using InputKit.Shared.Controls;
using Mopups.Hosting;
using UraniumUI;

namespace WeatherApp.Maui.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(PrismStartup.Configure)
                .UseMauiCommunityToolkit()
                .ConfigureMopups()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Roboto-Regular-400.ttf", "RobotoRegular");
                    fonts.AddFont("Roboto-Medium-500.ttf", "RobotoSemibold");
                    fonts.AddFont("Roboto-Bold-700.ttf", "RobotoBold");

                    fonts.AddMaterialIconFonts();
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseMapServiceToken("Aoium-u019RvP1Fz1afdilrRD9ebCDGuLfXB5bJ47VknU4N9Jz3qC03TYmPZpRHR");
                });

            builder.Services.AddMopupsDialogs();
            return builder.Build();
        }
    }
}
