namespace WeatherApp.Maui.UI.Views;

public partial class MainPage 
{
	public MainPage()
	{
		InitializeComponent();

        if(DeviceInfo.Current.Idiom != DeviceIdiom.Phone)
		{
            OtherPlaceCollectionView.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical) { HorizontalItemSpacing = 8, VerticalItemSpacing = 8 };
        }
        else
        {
            OtherPlaceCollectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical) { ItemSpacing = 8 };
        }

    }
}