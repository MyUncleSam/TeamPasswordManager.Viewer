using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects.Projects
{
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tags { get; set; }
        public Managed_By managed_by { get; set; }
        public bool archived { get; set; }
        public bool favorite { get; set; }
        public int num_files { get; set; }
        public string updated_on { get; set; }
    }

    public class Managed_By
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email_address { get; set; }
        public string role { get; set; }
    }
}
