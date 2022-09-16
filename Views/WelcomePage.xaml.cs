using Pitch1_0.ViewModel;

namespace Pitch1_0.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}