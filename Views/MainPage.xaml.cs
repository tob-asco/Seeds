using Pitch1_0.ViewModel;

namespace Pitch1_0;

public partial class MainPage : ContentPage
{
	public MainPage(FeedViewModel vm)
	{
		//this can only be called bc. theres an associated xaml class with same name
		InitializeComponent();

		BindingContext = vm;
	}

	/*protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}*/
}

