using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Objects.Error
{
	public class RootObject
	{
		public bool error { get; set; }
		public string type { get; set; }
		public string message { get; set; }
	}
}
