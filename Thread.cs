using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pitch1_0;

public partial class Thread : UserText
{
    [ObservableProperty]
    int index;

    [ObservableProperty]
    ObservableCollection<Comment> comments = new();

    [ObservableProperty]
    string type = "";

    [ObservableProperty]
    string postCommentText = "";

    internal void AddComment(Comment comment)
    {
        if(comment != null)
            Comments.Add(comment);
    }

    //internal void InitializePostCommentCommand(User currentUser, Thread parentThread)
    //{
    //     PostCommentCommand = new Command<string>((string text) =>
    //     {
            
    //     });
    //}
}
