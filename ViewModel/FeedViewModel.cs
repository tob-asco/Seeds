using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Pitch1_0.ViewModel;

[QueryProperty(nameof(FeedEntries),nameof(FeedEntries))]
[QueryProperty(nameof(CategoryDict),nameof(CategoryDict))]
[QueryProperty(nameof(CurrentUser),nameof(CurrentUser))]
[QueryProperty(nameof(ForumBackFeedEntry),"ParentFeedEntry")] //from ForumViewModel
public partial class FeedViewModel : BasisViewModel
{
    // not observable, these are the hard-coded categories (and tags)
    public Dictionary<string,Category> CategoryDict { get; set; }
    // for when you navigate back from a forum
    FeedEntry forumBackFeedEntry;
    public FeedEntry ForumBackFeedEntry
    {
        get => forumBackFeedEntry;
        set
        {
            if (value == forumBackFeedEntry) return;
            forumBackFeedEntry = value;
            int index = GetPositionByIndex(forumBackFeedEntry.Index);
            if (index == -1 || index > FeedEntries.Count) return;
            FeedEntries.RemoveAt(index);
            FeedEntries.Insert(index, forumBackFeedEntry);
        }
    }

    // The new List is the ObservableCollection, which automatically redraws its elements (upon event invoking)
    [ObservableProperty]
    ObservableCollection<FeedEntry> feedEntries;

    [ObservableProperty]
    ObservableCollection<Eyecatcher> eyecatchers;

    [RelayCommand]
    void ChangeCategoryPriority(int index)
    {
        int position = GetPositionByIndex(index);
        string key = FeedEntries[position].Idea.CategoryKey; 
        if (position != -1 && CurrentUser.CategoryPrioritiesDict.ContainsKey(key))
        {
            if (CurrentUser.CategoryPrioritiesDict[key] >= 1)
            {
                CurrentUser.CategoryPrioritiesDict[key] = -1;
                OnPropertyChanged(nameof(CurrentUser.CategoryPrioritiesDict));
                //FeedEntries[position].CategoryPriority = -1;
            }
            else
            {
                CurrentUser.CategoryPrioritiesDict[key]++;
                OnPropertyChanged(nameof(CurrentUser));
                //FeedEntries[position].CategoryPriority++;
            }
            //FeedEntries[index].UpdateCategoryPriority();

            // now manually set the CateoryPriority of all feedEntries of same category to new CategoryPriority
            // this looks pretty weird and can probably be handled more elegantly
            // Goal: update color of all entries with same category as the one changed
            /*foreach (FeedEntry otherentry in FeedEntries)
            {
                if (otherentry.Idea.CategoryKey == FeedEntries[position].Idea.CategoryKey)
                {
                    otherentry.CategoryPriority = FeedEntries[position].CategoryPriority;
                }
            }*/
        }
    }
     private int GetPositionByIndex(int index)
    {
        for (int i = 0; i < FeedEntries.Count; i++)
        {
            if (FeedEntries[i].Index == index) return i;
        }
        return -1;
    }

    [RelayCommand]
    private async Task OpenForum(FeedEntry entry)
    {
         var navigationParameter = new Dictionary<string, object>
                {
                    { "FeedEntry", entry },
                    { nameof(CurrentUser), CurrentUser },
                    { "ThreadType", null }
                };

        //await Shell.Current.DisplayAlert("hmm", navigationParameter["Idea"].ToString(), "cancel");
        //the following route is routed in AppShell.xaml.cs in the constructor
        await Shell.Current.GoToAsync($"IdeaForumPage", true, navigationParameter);
    }
    /***************************************************************************/
    public FeedViewModel() 
    { 
        //Title = CurrentUser.Name + " - feed";

        /*// Format: "{Namespace}.{Folder}.{filename}.{Extension}"
        string json = ReadResource("Pitch1_0.Resources.ideaFeed2.json");
        ideas = JsonConvert.DeserializeObject<List<Idea>>(json);*/


        /*if (ideas != null && ideas.Count > 0)
            FeedEntries = BuildFeedEntries();
        else
            FeedEntries = new ObservableCollection<FeedEntry>();*/
    }
    /***************************************************************************/

}
