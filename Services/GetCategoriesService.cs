using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pitch1_0.Services;

public class GetCategoriesService
{
    Dictionary<string,Category> categoryDict = new();

    public async Task<Dictionary<string,Category>> GetCategories()
    {
        // first a list where the key is just a property
        List<Category> categoryList;

        if (categoryDict?.Count > 0)
            return categoryDict;

        // this is code from JM's video
        using var stream = await FileSystem.OpenAppPackageFileAsync("categories.json");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        categoryList = JsonSerializer.Deserialize<List<Category>>(contents);

        foreach (Category category in categoryList)
        {
            categoryDict.Add(category.Key, category);
        }

        return categoryDict;
    }

}
