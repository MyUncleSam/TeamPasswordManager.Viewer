using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects.PasswordInfo
{
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public Project project { get; set; }
        public string tags { get; set; }
        public string access_info { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string expiry_date { get; set; }
        public int expiry_status { get; set; }
        public string notes { get; set; }
        public Custom_Field custom_field1 { get; set; }
        public Custom_Field custom_field2 { get; set; }
        public Custom_Field custom_field3 { get; set; }
        public Custom_Field custom_field4 { get; set; }
        public Custom_Field custom_field5 { get; set; }
        public Custom_Field custom_field6 { get; set; }
        public Custom_Field custom_field7 { get; set; }
        public Custom_Field custom_field8 { get; set; }
        public Custom_Field custom_field9 { get; set; }
        public Custom_Field custom_field10 { get; set; }
        public Users_Permissions[] users_permissions { get; set; }
        public Groups_Permissions[] groups_permissions { get; set; }
        public int[] parents { get; set; }
        public User_Permission user_permission { get; set; }
        public bool archived { get; set; }
        public bool favorite { get; set; }
        public string num_files { get; set; }
        public bool locked { get; set; }
        public bool external_sharing { get; set; }
        public string external_url { get; set; }
        public Managed_By managed_by { get; set; }
        public string created_on { get; set; }
        public Created_By created_by { get; set; }
        public string updated_on { get; set; }
        public Updated_By updated_by { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Custom_Field
    {
        public string type { get; set; }
        public string label { get; set; }
        public string data { get; set; }
    }

    public class User_Permission
    {
        public int id { get; set; }
        public string label { get; set; }
    }

    public class Managed_By
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email_address { get; set; }
        public string name { get; set; }
        public string role { get; set; }
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
