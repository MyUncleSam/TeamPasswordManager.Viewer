using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TeamPassword.Library.Functions
{
    public class Passwords
    {
        public Instance inst { get; private set; }

        public Passwords(Instance _inst)
        {
            inst = _inst;
        }

        public List<Objects.Passwords.RootObject> GetProjectPasswords(int projectId, int? page = null)
        {
            return inst.FetchPaged<Objects.Passwords.RootObject>(
                RestSharp.Method.GET,
                "projects/{project_id}/passwords.json",
                page,
                urlParameters: new Dictionary<string, string>() { { "project_id", projectId.ToString() } });
        }

        public List<Objects.Passwords.RootObject> GetPasswords(int? page = null)
        {
            return inst.FetchPaged<Objects.Passwords.RootObject>(
                RestSharp.Method.GET,
                "passwords.json",
                page);
        }

        public List<Objects.Passwords.RootObject> GetPasswords(string filter, int? page = null)
        {
            string filterEncoded = HttpUtility.UrlEncode(filter);

            return inst.FetchPaged<Objects.Passwords.RootObject>(
                RestSharp.Method.GET,
                "passwords/search/{filter}.json",
                page,
                urlParameters: new Dictionary<string, string>() { { "filter", filterEncoded } });
        }

        public List<Objects.Passwords.RootObject> GetArchivedPasswords(int? page = null)
        {
            return inst.FetchPaged<Objects.Passwords.RootObject>(
                RestSharp.Method.GET,
                "passwords/archived.json",
                page);
        }

        public List<Objects.Passwords.RootObject> GetFavoritePasswords(int? page = null)
        {
            return inst.FetchPaged<Objects.Passwords.RootObject>(
                RestSharp.Method.GET,
                "passwords/favorite.json",
                page);
        }
    }
}
