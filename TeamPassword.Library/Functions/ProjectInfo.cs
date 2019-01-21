using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class ProjectInfo
    {
        public Instance inst { get; private set; }

        public ProjectInfo(Instance _inst)
        {
            inst = _inst;
        }

        public Objects.ProjectInfo.RootObject GetProjectInfo(int projectId)
        {
            return inst.FetchSingleEntry<Objects.ProjectInfo.RootObject>(
                RestSharp.Method.GET,
                "projects/{project_id}.json",
                urlParameters: new Dictionary<string, string>() { { "project_id", projectId.ToString() } });
        }
    }
}
