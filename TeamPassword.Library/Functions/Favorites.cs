using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class Favorites
    {
        public Instance inst { get; private set; }

        public Favorites(Instance _inst)
        {
            inst = _inst;
        }

        public List<Objects.Projects.RootObject> GetFavoriteProjects(int? page = null)
        {
            return inst.Projects.GetFavoriteProjects(page);
        }

        public List<Objects.Passwords.RootObject> GetFavoritePasswords(int? page = null)
        {
            return inst.Passwords.GetFavoritePasswords(page);
        }
    }
}
