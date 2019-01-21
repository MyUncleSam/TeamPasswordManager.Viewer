using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects
{
    public class NodeItem
    {
        public NodeItem(SubProject.RootObject sp)
        {
            ID = sp.id;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string IconName { get; private set; }
        public bool Disabled { get; private set; }
        public bool Archived { get; private set; }
        public bool HasChildren { get; private set; }
        public List<NodeItem> GetChildren { get; }
    }
}
