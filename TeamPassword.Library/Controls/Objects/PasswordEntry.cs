using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Controls.Objects
{
	public class PasswordEntry : Library.Objects.PasswordInfo.RootObject
	{
		private AccessType? _GuessType = null;
		public AccessType GuessType
		{
			get
			{
				if (_GuessType == null)
				{
					if (string.IsNullOrWhiteSpace(access_info))
						_GuessType = AccessType.Default;

					// check teamviewer
					if (_GuessType == null)
					{
						string noSpaceString = new string(access_info.Where(w => !char.IsWhiteSpace(w)).ToArray()); // removes all whitespaces

						if (noSpaceString.Length >= 9 && noSpaceString.Length <= 10)
							if (int.TryParse(noSpaceString, out int tvId))
								_GuessType = AccessType.TeamViewer; // seems to be teamviewer
					}

					// check url and filesystem
					if (_GuessType == null)
					{
						try
						{
							Uri checkUri = new Uri(access_info);

							if (checkUri.Scheme.Equals("ftp", StringComparison.OrdinalIgnoreCase))
								return AccessType.Ftp;

							if (checkUri.Scheme.Equals("file", StringComparison.OrdinalIgnoreCase))
							{
								if (checkUri.LocalPath.StartsWith(@"\\"))
									return AccessType.SMB;
								else
									return AccessType.FileSystem;
							}


							if (checkUri.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase) 
								|| checkUri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
								return AccessType.Url;

							// anything else is a special url (not known but url format)
							return AccessType.SpecialUrl;
						}
						catch { }
					}

					if (_GuessType == null)
					{
						_GuessType = AccessType.Default;
					}
				}

				return (AccessType)_GuessType;
			}
		}
	}

	public enum AccessType
	{
		Default = 0,
		TeamViewer,
		Url,
		Ftp,
		FileSystem,
		SpecialUrl,
		SMB
	}
}
