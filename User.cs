using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0
{
    public partial class User : ObservableObject
    {
        public string Name { get; set; }
        public string Password { get; set; } = "";
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public List<KeyPriorityPair> CategoryPrioritiesList { get; set; }

        // observable for cat. prio. changes
        [ObservableProperty]
        IDictionary<string,int> categoryPrioritiesDict = new Dictionary<string,int>();
    }

    public class KeyPriorityPair
    {
        public string Key { get; set; }
        public int Priority { get; set; }
    }
}
