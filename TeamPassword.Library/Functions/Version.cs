using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class Version
    {
        public Instance inst { get; private set; }

        public Version(Instance _inst)
        {
            inst = _inst;
        }

        public Objects.Version.RootObject GetVersion()
        {
            return inst.FetchSingleEntry<Objects.Version.RootObject>(
                RestSharp.Method.GET,
                "version.json");
        }
    }
}
