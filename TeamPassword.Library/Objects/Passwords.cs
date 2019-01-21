using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects.Passwords
{
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public Project project { get; set; }
        public string notes_snippet { get; set; }
        public string tags { get; set; }
        public string access_info { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string expiry_date { get; set; }
        public int expiry_status { get; set; }
        public bool archived { get; set; }
        public bool favorite { get; set; }
        public int num_files { get; set; }
        public bool locked { get; set; }
        public bool external_sharing { get; set; }
        public string updated_on { get; set; }
    }

    public class Project
    {
        public int? id { get; set; }
        public string name { get; set; }
    }
}
