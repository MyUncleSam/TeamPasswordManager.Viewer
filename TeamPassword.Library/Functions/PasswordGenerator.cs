using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class PasswordGenerator
    {
        public Instance inst { get; private set; }

        public PasswordGenerator(Instance _inst)
        {
            inst = _inst;
        }

        public Objects.PasswordGenerator.RootObject GetNewPassword()
        {
            return inst.FetchSingleEntry<Objects.PasswordGenerator.RootObject>(
                RestSharp.Method.GET,
                "generate_password.json");
        }

        public string GetNewPasswordString()
        {
            return GetNewPassword().password;
        }
    }
}
