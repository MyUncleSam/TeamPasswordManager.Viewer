using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public static class SettingsUpdater
    {
        private static bool alreadyChecked = false;

        /// <summary>
        /// updates the user properties if needed
        /// </summary>
        public static void UpdateSettings()
        {
            if (alreadyChecked)
                return;

            alreadyChecked = true;

            if(Properties.Settings.Default.NeedsUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NeedsUpgrade = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
