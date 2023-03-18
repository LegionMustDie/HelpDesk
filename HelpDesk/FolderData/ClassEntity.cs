using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.FolderData
{
    public partial class DBEntities : DbContext
    {
        private static DBEntities con;
        public static DBEntities GC()
        {
            return con ?? (con = new DBEntities());
        }
    }
}
