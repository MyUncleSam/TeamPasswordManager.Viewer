using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects.ProjectInfo
{
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        public string tags { get; set; }
        public string notes { get; set; }
        public Managed_By managed_by { get; set; }
        public Grant_All_Permission grant_all_permission { get; set; }
        public Users_Permissions[] users_permissions { get; set; }
        public Groups_Permissions[] groups_permissions { get; set; }
        public int num_passwords { get; set; }
        public int num_files { get; set; }
        public User_Permission user_permission { get; set; }
        public bool user_can_create_passwords { get; set; }
        public bool is_leaf { get; set; }
        public int[] parents { get; set; }
        public bool archived { get; set; }
        public bool favorite { get; set; }
        public string created_on { get; set; }
        public Created_By created_by { get; set; }
        public string updated_on { get; set; }
        public Updated_By updated_by { get; set; }
    }

    public class Managed_By
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email_address { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Grant_All_Permission
    {
        public int id { get; set; }
        public string label { get; set; }
    }

    public class User_Permission
    {
        public int id { get; set; }
        public string label { get; set; }
    }

    public class Created_By
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email_address { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Updated_By
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email_address { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Users_Permissions
    {
        public User user { get; set; }
        public UserPermission permission { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email_address { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class UserPermission
    {
        public int id { get; set; }
        public string label { get; set; }
    }

    public class Groups_Permissions
    {
        public Group group { get; set; }
        public GroupPermission permission { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class GroupPermission
    {
        public int id { get; set; }
        public string label { get; set; }
    }
}
