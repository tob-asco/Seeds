using CommunityToolkit.Mvvm.Input;
using Pitch1_0.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0.ViewModel;

public partial class WelcomeViewModel : BasisViewModel
{
    public ObservableCollection<FeedEntry> FeedEntries { get; set; }
    public Dictionary<string,Category> CategoryDict { get; set; }

    GetIdeasService ideasService;
    GetCategoriesService categoriesService;
    GetUserService userService;
    public WelcomeViewModel(GetIdeasService ideasService, GetCategoriesService categoriesService, GetUserService userService)
    {
        // that's, I think, dependency injection
        this.ideasService = ideasService;
        this.categoriesService = categoriesService;
        this.userService = userService;

        FeedEntries = new ObservableCollection<FeedEntry>();
    }

    [RelayCommand]
    async Task GetIdeasAndCategoriesAndBuildFeedAndNavigateAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;

            var ideas = await ideasService.GetIdeas();
            CategoryDict = await categoriesService.GetCategories();
            CurrentUser = await userService.GetUser();

            if (FeedEntries.Count != 0) FeedEntries.Clear();

            foreach (var idea in ideas)
            {
                FeedEntry entry = new()
                {
                    Idea = idea,
                    Viewer = CurrentUser,
                    Index = idea.Index // the Index is copied
                                       // could also be omitted for the FeedEntry
                };
                if (CategoryDict.ContainsKey(idea.CategoryKey))
                {
                    // initialize the FeedEntry's category here
                    entry.Category = CategoryDict[idea.CategoryKey];
                }
                //entry.UpdateCategoryPriority();

                // order the threads already here by their upvotes
                entry.Idea.Forum = new ObservableCollection<Thread>(entry.Idea.Forum.OrderByDescending(Thread => Thread.Upvotes));

                // this will raise OnPropertyChanged for each item
                // in JM's video (around 1:47:00) he talks about that
                FeedEntries.Add(entry);
            }
            await Shell.Current.GoToAsync(nameof(MainPage), true, new Dictionary<string, object>
            {
                { nameof(FeedEntries), FeedEntries },
                { nameof(CategoryDict), CategoryDict },
                { nameof(CurrentUser), CurrentUser }
            });
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Unable to get ideas or build feed: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
        //order entries via their Index property
        //return new ObservableCollection<FeedEntry>(feedEntries.OrderBy(FeedEntry => FeedEntry.Index)); 
}
