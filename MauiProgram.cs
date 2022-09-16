using Pitch1_0.Services;
using Pitch1_0.ViewModel;
using Pitch1_0.Views;

namespace Pitch1_0;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// the following registers the pages to the app via "dependency services"
		// Singleton = only one page in an instance of the app
		// Transient = multiple pages per instance
		// the VMs are also registered, bc. they're also part of a page
		builder.Services.AddSingleton<GetIdeasService>();
		builder.Services.AddSingleton<GetCategoriesService>();
		builder.Services.AddSingleton<GetUserService>();

		builder.Services.AddSingleton<WelcomeViewModel>();
		builder.Services.AddSingleton<FeedViewModel>();
		builder.Services.AddTransient<IdeaForumViewModel>();

		builder.Services.AddSingleton<WelcomePage>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<IdeaForumPage>();


		return builder.Build();
	}
}
