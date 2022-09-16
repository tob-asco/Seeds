using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pitch1_0;

public class Comment : UserText
{
    public Thread ParentThread { get; set; }
    public string IsAnswer { get; set; } // threads of type "question, doubt, .." can be answered by one comment
}
