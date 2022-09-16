using Pitch1_0.Views;

namespace Pitch1_0;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// HT: here we register routes that aren't visible in the flyout
		Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(IdeaForumPage), typeof(IdeaForumPage));
	}
}
