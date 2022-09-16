using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Pitch1_0;

// this is intended for Comments and Threads
public partial class UserText : ObservableObject
{
    public User Author
    {
        get { return Author; }
        set
        {
            if (Author.Name != null && AuthorName != value.Name)
                AuthorName = Author.Name;
        }
    }
    public string AuthorName { get; set; } //overhead for the .json file 
    public DateTime TimeCreated { get; set; } = DateTime.Now;

    [ObservableProperty]
    string text = "";

    [ObservableProperty]
    int upvotes;

    [ObservableProperty]
    int viewerVote = 0;

    #region Up and Downvote
    [RelayCommand]//(CanExecute = nameof(CanUpvote))] //source generator
    void Upvote()
    {
        if (CanUpvote())
        {
            Upvotes++;
            ViewerVote++;
        }
        else if (ViewerVote == 1)
        {
            //open a new thread with "+1" as type already set
        }
        //RefreshVoteCanExecutes(); //re-evaluate whether a vote is allowed
    }
    private bool CanUpvote()
    {
        if (ViewerVote == 0 | ViewerVote == -1)
            return true;
        else return false;
    }

    [RelayCommand]
    void Downvote()
    {
        if (CanDownvote())
        {
            Upvotes--;
            ViewerVote--;
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
}
