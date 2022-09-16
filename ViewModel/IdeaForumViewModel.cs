using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Pitch1_0.ViewModel;

[QueryProperty(nameof(ParentFeedEntry),"FeedEntry")] // this query transmits information from the last page
[QueryProperty(nameof(CurrentUser),nameof(CurrentUser))]
[QueryProperty(nameof(ThreadType),"ThreadType")]
[QueryProperty(nameof(PostThreadText),"PostThreadText")]
public partial class IdeaForumViewModel : BasisViewModel
{
    // main binding property for the view
    // when a thread or a comment is added, e.g., it should fire an OnPropertyChanged
    [ObservableProperty]
    FeedEntry parentFeedEntry;

    // the Editor in the View binds to this, to delete text after posting was done
    [ObservableProperty]
    string postThreadText;

    //backed by a converter s.th. the value is already the string inside the view's frame
    //[ObservableProperty]
    //string threadTypeOld;

    string threadType;
    public string ThreadType
    {
        get => threadType;
        set
        {
            if(value != threadType)
            {
                if (value == " 1") threadType = "+1"; //veeeery weird bug while transmitting +1
                else threadType = value;
                OnPropertyChanged(nameof(ThreadType));
            }
        }
    }

    [RelayCommand]
    async Task Back()
    {
        await Shell.Current.DisplayAlert("d", "hit", "go");
        await Shell.Current.GoToAsync(nameof(MainPage), true, new Dictionary<string, object>
        {
            { nameof(ParentFeedEntry), ParentFeedEntry }
        });
    }

    [RelayCommand]
    void PostThread() //the thread already comes with Text, Type set
    {
        if (ThreadType != null && PostThreadText != null && PostThreadText != "")
        {
            // set each post as upvoted by the CurrentUser
            // because why would you post something that you don't like yourself?
            Thread thread = new()
            {
                Type = ThreadType,
                Text = PostThreadText,
                Index = ParentFeedEntry.Idea.Forum.Count,
                AuthorName = CurrentUser.Name,
                Upvotes = 1,
                ViewerVote = 1
            };

            // now the lines that trigger the respective OnPropertyChanged
            // clear the editor for the text of a new thread
            ParentFeedEntry.Idea.AddThread(thread);
            PostThreadText = "";
        }
    }


    [RelayCommand]
    void PostComment(Thread _parentThread)
    {
        if (_parentThread.PostCommentText != null && _parentThread.PostCommentText != "") 
        {
            // set each post as upvoted by the CurrentUser
            // because why would you post something that you don't like yourself?
            Comment comment = new()
            {
                Text = _parentThread.PostCommentText,
                ParentThread = _parentThread,
                AuthorName = CurrentUser.Name,
                Upvotes = 1,
                ViewerVote = 1,
                IsAnswer = "0"
            };

            // now the lines that trigger the respective OnPropertyChanged
            // clear the editor for the text of a new thread
            int position = GetPositionByIndex(_parentThread.Index);
            if (position != -1)
            {
                ParentFeedEntry.Idea.Forum[position].AddComment(comment);
                ParentFeedEntry.Idea.Forum[position].PostCommentText = "";
            }
        }
    }

    private int GetPositionByIndex(int index)
    {
        for (int i = 0; i < ParentFeedEntry.Idea.Forum.Count; i++)
        {
            if (ParentFeedEntry.Idea.Forum[i].Index == index) return i;
        }
        return -1;
    }
}
