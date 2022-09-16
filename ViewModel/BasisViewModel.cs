using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Pitch1_0.ViewModel;

public partial class BasisViewModel : ObservableObject
{
    // observable e.g. for category priority dictionary
    [ObservableProperty] //Source generator
    User currentUser;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))] // was called "AlsoNotifyChangeFor"
    bool isBusy;

    [ObservableProperty]
    string title = "";

    public bool IsNotBusy => !IsBusy;


    /*protected static string ReadResource(string name)
    {
        // https://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file
        // it's to make sure that filenames work on all conventions of file structure
        // it gets the file through the classpath, not the absolute path
        // IMPORTANT: in solution explorer, select the file and choose "Embedded resource" under "Build Action"
        var assembly = Assembly.GetExecutingAssembly();
        string resourceName = name;
        // Format: "{Namespace}.{Folder}.{filename}.{Extension}"
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new(stream))
        {
            return reader.ReadToEnd();
        }
    }*/
}
