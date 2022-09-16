using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pitch1_0.Services;

public class GetIdeasService
{
    List<Idea> ideaList = new();

    public async Task<List<Idea>> GetIdeas()
    {
        if (ideaList?.Count > 0)
            return ideaList;

        // this is code from JM's video
        using var stream = await FileSystem.OpenAppPackageFileAsync("ideas.json");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        ideaList = JsonSerializer.Deserialize<List<Idea>>(contents);


        return ideaList;
    }
}
