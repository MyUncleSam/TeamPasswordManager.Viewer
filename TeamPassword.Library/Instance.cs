using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library
{
	public class Instance
	{
        public LoginInformation LoginInfo { get; set; }
        public Rest.RestClass GetRest { get; private set; }

        public Functions.Version Version { get; set; }
        public Functions.Projects Projects { get; private set; }
        public Functions.SubProjects SubProjects { get; private set; }
        public Functions.ProjectInfo ProjectInfo { get; set; }
        public Functions.Passwords Passwords { get; set; }
        public Functions.PasswordInfo PasswordInfo { get; set; }
        public Functions.PasswordGenerator PasswordGenerator { get; set; }
        public Functions.Favorites Favorites { get; set; }


        public Instance(Uri baseUrl, string username, string password)
		{
            LoginInfo = new LoginInformation()
            {
                URL = baseUrl,
                Username = username,
                Password = password
            };

            GetRest = new Rest.RestClass(this);

            Version = new Functions.Version(this);
            Projects = new Functions.Projects(this);
            SubProjects = new Functions.SubProjects(this);
            ProjectInfo = new Functions.ProjectInfo(this);
            Passwords = new Functions.Passwords(this);
            PasswordInfo = new Functions.PasswordInfo(this);
            PasswordGenerator = new Functions.PasswordGenerator(this);
            Favorites = new Functions.Favorites(this);
		}

        private Instance()
        {
            GetRest = new Rest.RestClass(this);
        }

        /// <summary>
        /// fetches all pages for a given rest request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inst"></param>
        /// <param name="requestMethod"></param>
        /// <param name="jsonUrl">has to be a request including pagination support</param>
        /// <param name="page">the page which should be fetched: null:all paginated, 0:non paged, >=1:this page only</param>
        /// <param name="urlParameters"></param>
        /// <param name="parameters"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public List<T> FetchPaged<T>(
            Method requestMethod,
            string jsonUrl,
            int? page,
            Dictionary<string, string> urlParameters = null,
            Dictionary<string, object> parameters = null,
            Dictionary<string, string> headers = null)
        {
            string jsonBaseUrl = jsonUrl.EndsWith(".json") ? jsonUrl.Substring(0, jsonUrl.Length - ".json".Length) : jsonUrl.TrimEnd('/');
            string countUrl = string.Format("{0}/count.json", jsonBaseUrl); // url for counting the pages
            string paginationUrl = string.Format("{0}/page/{{page}}.json", jsonBaseUrl); // url with paging elements

            List<int> fetchPages = null;

            // set pages to fetch
            if (page == null)
                fetchPages = FetchSingleEntry<Objects.Count.RootObject>(requestMethod, countUrl, urlParameters, parameters, headers).num_pages.OneToNumber();
            else if (page < 0)
                throw new ArgumentException("Negative page numbers cannot be fetched!");
            else if (page == 0)
                return GetRest.GetResponse<List<T>>(GetRest.CreateNewRequest(requestMethod, jsonUrl, urlParameters, parameters, headers)); // use default logic
            else if (page > 0)
                fetchPages = new List<int>() { (int)page };

            List<T> retList = new List<T>();

			//fetchPages.AsParallel().ForAll(f =>
			//{
			//    //create a new url segment dictionary by applying all information and adding the page entry
			//        Dictionary<string, string> curUrlParameters = new Dictionary<string, string>();

			//    if (urlParameters != null)
			//        foreach (KeyValuePair<string, string> upe in urlParameters)
			//            curUrlParameters.AddOrUpdate(upe.Key, upe.Value);

			//    // add page parameter to url, fetch the page and add it to the dictionary
			//    curUrlParameters.AddOrUpdate("page", f.ToString());
			//    retList.AddRange(GetRest.GetResponse<List<T>>(GetRest.CreateNewRequest(requestMethod, paginationUrl, curUrlParameters, parameters, headers)));
			//});

			// for each page needed to fetch ...
			//fetchPages.ForEach(f =>
			//{
			//    // create a new url segment dictionary by applying all information and adding the page entry
			//    Dictionary<string, string> curUrlParameters = new Dictionary<string, string>();

			//    if (urlParameters != null)
			//        foreach (KeyValuePair<string, string> upe in urlParameters)
			//            curUrlParameters.AddOrUpdate(upe.Key, upe.Value);

			//    // add page parameter to url, fetch the page and add it to the dictionary
			//    curUrlParameters.AddOrUpdate("page", f.ToString());
			//    retList.AddRange(GetRest.GetResponse<List<T>>(GetRest.CreateNewRequest(requestMethod, paginationUrl, curUrlParameters, parameters, headers)));
			//});

			//object lockObject = new object();

			Parallel.ForEach(
				fetchPages,
				new ParallelOptions() { MaxDegreeOfParallelism = 8 },
				f => 
				{
					// create a new url segment dictionary by applying all information and adding the page entry
					Dictionary<string, string> curUrlParameters = new Dictionary<string, string>();

					if (urlParameters != null)
						foreach (KeyValuePair<string, string> upe in urlParameters)
							curUrlParameters.AddOrUpdate(upe.Key, upe.Value);

					// add page parameter to url, fetch the page and add it to the dictionary
					curUrlParameters.AddOrUpdate("page", f.ToString());
					retList.AddRange(GetRest.GetResponse<List<T>>(GetRest.CreateNewRequest(requestMethod, paginationUrl, curUrlParameters, parameters, headers)));
				});

			//List<Task> tasks = new List<Task>();
			//foreach (int f in fetchPages)
			//{
			//    tasks.Add(Task.Run(() =>
			//    {
			//        // create a new url segment dictionary by applying all information and adding the page entry
			//        Dictionary<string, string> curUrlParameters = new Dictionary<string, string>();

			//        if (urlParameters != null)
			//            foreach (KeyValuePair<string, string> upe in urlParameters)
			//                curUrlParameters.AddOrUpdate(upe.Key, upe.Value);

			//        // add page parameter to url, fetch the page and add it to the dictionary
			//        curUrlParameters.AddOrUpdate("page", f.ToString());

			//        //lock (lockObject)
			//        retList.AddRange(GetRest.GetResponse<List<T>>(GetRest.CreateNewRequest(requestMethod, paginationUrl, curUrlParameters, parameters, headers)));
			//    }));
			//}
			//Task.WaitAll(tasks.ToArray());

			return retList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestMethod"></param>
        /// <param name="jsonUrl"></param>
        /// <param name="urlParameters"></param>
        /// <param name="parameters"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public List<T> FetchNonPaged<T>(
            Method requestMethod,
            string jsonUrl,
            Dictionary<string, string> urlParameters = null,
            Dictionary<string, object> parameters = null,
            Dictionary<string, string> headers = null)
        {
            return FetchPaged<T>(requestMethod, jsonUrl, 0, urlParameters, parameters, headers);
        }

        /// <summary>
        /// fetch one single entry (no list)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestMethod"></param>
        /// <param name="jsonUrl"></param>
        /// <param name="urlParameters"></param>
        /// <param name="parameters"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public T FetchSingleEntry<T>(
        Method requestMethod,
        string jsonUrl,
        Dictionary<string, string> urlParameters = null,
        Dictionary<string, object> parameters = null,
        Dictionary<string, string> headers = null)
        {
            return GetRest.GetResponse<T>(GetRest.CreateNewRequest(requestMethod, jsonUrl, urlParameters, parameters, headers));
        }
    }
}
