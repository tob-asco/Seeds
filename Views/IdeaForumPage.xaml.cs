using Pitch1_0.ViewModel;

namespace Pitch1_0.Views;


public partial class IdeaForumPage : ContentPage
{
	public IdeaForumPage(IdeaForumViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
	
	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}

}