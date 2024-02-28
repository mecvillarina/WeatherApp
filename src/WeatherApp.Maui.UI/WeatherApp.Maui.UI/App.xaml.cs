using UraniumUI.Material.Resources;

namespace WeatherApp.Maui.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            VersionTracking.Track();
        }
    }
}
