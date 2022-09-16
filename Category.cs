using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0
{
    public class Category
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public List<string> Tags { get; set; } = new();

        public Category(string name)
        {
            Name = name;
        }
    }
}
