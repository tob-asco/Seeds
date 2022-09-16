using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pitch1_0.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pitch1_0;

public partial class FeedEntry : ObservableObject
{
    public ICommand ChangeCategoryPriority { get; set; }

    [ObservableProperty]
    int viewerVote = 0;
    //public int ViewerVote { get; set; } = 0; //Upvoted = +1, Nothing = 0, Downvoted = -1
    public User Viewer { get; set; }
    //public Thread TopThread => Idea.Forum[0]; //because this is a property of an entry as it's displayed in the feed

    // making the idea an observable property makes all its Properties observable, I hope
    [ObservableProperty]
    Idea idea;

    // the idea stores the ideas catKey and the feedEntry stores the whole category
    [ObservableProperty]
    Category category;

    [ObservableProperty]
    int categoryPriority;//this is somewhat redundant but simplifies XAML code (at which I suck)

    [ObservableProperty]
    int index; //idea's index for ordering in feed

    
    #region Up and Downvote
    [RelayCommand]//(CanExecute = nameof(CanUpvote))] //source generator
    async Task Upvote()
    {
        if(CanUpvote())
        {
            Idea.Upvotes++;
            ViewerVote++;
        }
        else if(ViewerVote == 1)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "FeedEntry", this },
                    { "CurrentUser", Viewer },
                    { "ThreadType", "+1" }, //somehow he sends " 1" instead .... ;(
                    { "PostThreadText", "I like that ..." }
                };
            await Shell.Current.GoToAsync($"IdeaForumPage", true, navigationParameter);
        }
        //RefreshVoteCanExecutes(); //re-evaluate whether a vote is allowed
    }
    private bool CanUpvote()
    {
        if (ViewerVote == 0 |ViewerVote == -1)
            return true;
        else return false;
    }
    
    [RelayCommand]
    async Task Downvote()
    {
        if (CanDownvote())
        {
            Idea.Upvotes--;
            ViewerVote--;
        }
        else if (ViewerVote == -1)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "FeedEntry", this },
                    { "CurrentUser", Viewer },
                    { "ThreadType", "-1" },
                    { "PostThreadText", @"I don't like that ..." }
                };
            await Shell.Current.GoToAsync($"IdeaForumPage", true, navigationParameter);
        }
        //RefreshVoteCanExecutes(); //re-evaluate whether a vote is allowed
    }
    private bool CanDownvote()
    {
        if (ViewerVote == 0 | ViewerVote == 1)
            return true;
        else return false;
    }
    
    // this method, when used with [RelayCommand] threw NullReferenceExceptions
    // it did work w/o using the community toolkit ([..]) though
    //void RefreshVoteCanExecutes()
    //{
    //    (UpvoteCommand as Command).ChangeCanExecute();
    //    (DownvoteCommand as Command).ChangeCanExecute();
    //}
    #endregion

/***********************************************************/
    public FeedEntry()
    {
        // initialize the idea to have an empty string
    }
/***********************************************************/
    public async void UpdateCategoryPriority()
    {
        string catKey = Idea.CategoryKey;
        if (Viewer.CategoryPrioritiesDict.ContainsKey(catKey))
        {
            CategoryPriority = Viewer.CategoryPrioritiesDict[catKey];
            OnPropertyChanged(nameof(CategoryPriority));
            OnPropertyChanged(nameof(Viewer));
        }
        else
        {
            await Shell.Current.DisplayAlert("Inside Method", "this category wasn't found.., I initialize to 0", "cancel");
            CategoryPriority = 0;
            return;
        }
    }
}
