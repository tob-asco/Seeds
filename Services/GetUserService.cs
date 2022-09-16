using System.Text.Json;

namespace Pitch1_0.Services;

public class GetUserService
{
    User User { get; set; }
    public async Task<User> GetUser()
    {
        // this is code from JM's video
        using var stream = await FileSystem.OpenAppPackageFileAsync("user1.json");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        User = JsonSerializer.Deserialize<User>(contents);

        foreach (KeyPriorityPair pair in User.CategoryPrioritiesList)
        {
            User.CategoryPrioritiesDict.Add(pair.Key, pair.Priority);
        }

        return User;
    }
}
