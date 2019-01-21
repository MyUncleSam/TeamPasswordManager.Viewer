using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class PasswordInfo
    {
        public Instance inst { get; private set; }

        public PasswordInfo(Instance _inst)
        {
            inst = _inst;
        }

        public Objects.PasswordInfo.RootObject GetPassword(int passwordId)
        {
            return inst.FetchSingleEntry<Objects.PasswordInfo.RootObject>(
                RestSharp.Method.GET,
                "passwords/{id}.json",
                urlParameters: new Dictionary<string, string>() { { "id", passwordId.ToString() } });
        }
    }
}
