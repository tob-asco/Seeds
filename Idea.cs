using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Pitch1_0;

public partial class Idea : ObservableObject
{
    public string Inventor { get; set; }
    public string CategoryKey { get; set; }
    public string Title { get; set; }
    public string Slogan { get; set; }
    public DateTime TimeCreation { get; set; } = DateTime.Now;
    public ObservableCollection<Eyecatcher> Eyecatchers { get; set; }
    public ObservableCollection<Thread> Forum { get; set; } = new();

    [ObservableProperty]
    int index;

    [ObservableProperty]
    int expUpvotes;

    [ObservableProperty]
    int upvotes;


    internal void AddThread(Thread thread)
    {
        Forum.Add(thread); //will this produce an OnPropertyChanged call for 
                           //the [ObservableProperty] Idea idea in FeedEntry.cs?
    }
}
