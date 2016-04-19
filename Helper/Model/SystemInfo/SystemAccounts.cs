using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Model.SystemInfo
{
    public class SystemAccounts
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string LocalAccount { get; set; }
        public string SecurityIdentifier { get; set; }
        public string SecurityIdentifierType { get; set; }
        public string State { get; set; }
    }
}
