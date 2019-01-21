using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TeamPassword.Library.Functions
{
    public class Projects
    {
        public Instance inst { get; private set; }

        public Projects(Instance _inst)
        {
            inst = _inst;
        }

        public List<Objects.Projects.RootObject> GetProjects(int? page = null)
        {
            return inst.FetchPaged<Objects.Projects.RootObject>(
                RestSharp.Method.GET,
                "projects.json",
                page);
        }

        public List<Objects.Projects.RootObject> GetProjects(string filter, int? page = null)
        {
            string filterEncoded = HttpUtility.UrlEncode(filter);

            return inst.FetchPaged<Objects.Projects.RootObject>(
                RestSharp.Method.GET,
                "projects/search/{filter}.json",
                page,
                urlParameters: new Dictionary<string, string>() { { "filter", filterEncoded } });
        }

        public List<Objects.Projects.RootObject> GetArchivedProjects(int? page = null)
        {
            return inst.FetchPaged<Objects.Projects.RootObject>(
                RestSharp.Method.GET,
                "projects/archived.json",
                page);
        }

        public List<Objects.Projects.RootObject> GetFavoriteProjects(int? page = null)
        {
            return inst.FetchPaged<Objects.Projects.RootObject>(
                RestSharp.Method.GET,
                "projects/favorite.json",
                page);
        }
    }
}
