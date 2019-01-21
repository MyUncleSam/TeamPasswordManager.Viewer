using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class SubProjects
    {
        Instance inst = null;

        public SubProjects(Instance _inst)
        {
            inst = _inst;
        }

        public List<Objects.SubProject.RootObject> GetRootProjects()
        {
            return GetSubProjects(0);
        }

        public List<Objects.SubProject.RootObject> GetSubProjects(int projectId)
        {
            return inst.FetchNonPaged<Objects.SubProject.RootObject>(
                RestSharp.Method.GET,
                "projects/{project_id}/subprojects.json",
                urlParameters: new Dictionary<string, string>() { { "project_id", projectId.ToString() } });
        }
    }
}
