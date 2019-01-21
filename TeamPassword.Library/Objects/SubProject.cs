using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects.SubProject
{
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool has_children { get; set; }
        public bool archived { get; set; }
        public bool favorite { get; set; }
        public bool disabled { get; set; }
        public int num_pwds { get; set; }
        public int num_pwds_branch { get; set; }
    }
}
