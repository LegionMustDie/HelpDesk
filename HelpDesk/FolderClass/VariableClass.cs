using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.FolderData;

namespace HelpDesk.FolderClass
{
    internal class VariableClass
    {
        public static int IdCategory { get; set; }
        public static int IdUser { get; set; }
        public static Staff staff { get; set; }
        public static RequestStaff reqst { get; set; }
        public static int protectthis { get; set; }
        public static bool IsAccepted { get; set; }
    }
}
