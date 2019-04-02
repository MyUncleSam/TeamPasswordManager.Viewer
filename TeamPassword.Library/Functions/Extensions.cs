using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamPassword.Library
{
    public static class Extensions
    {
        [DllImport("Kernel32.dll")]
        private static extern uint QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In, Out] ref uint lpdwSize);

        public static List<int> OneToNumber(this int endNUmber)
        {
            List<int> retList = new List<int>();
            int curNumber = 1;

            while (curNumber <= endNUmber)
                retList.Add(curNumber++);

            return retList;
        }

        public static List<int> PagesToFetch(this int? page, Func<Objects.Count.RootObject> countAction)
        {
            if (page != null)
                return new List<int>() { (int)page };
            else
                return countAction().num_pages.OneToNumber();
        }

        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict == null)
                return;

            if (dict.ContainsKey(key))
                dict[key] = value;
            else
                dict.Add(key, value);
        }

		public static List<Controls.Objects.TreeNodeEx> GetNodesEx(this List<Objects.SubProject.RootObject> rol)
		{
			List<Controls.Objects.TreeNodeEx> ret = new List<Controls.Objects.TreeNodeEx>();

			foreach (Objects.SubProject.RootObject ro in rol)
			{
				Controls.Objects.TreeNodeEx newNode = new Controls.Objects.TreeNodeEx(ro.id, Controls.Objects.TreeNodeExType.Project, ro);
				newNode.Text = ro.name;
				newNode.CanExpand = ro.has_children;
				newNode.Archived = ro.archived;
                newNode.Name = ro.name;
                ret.Add(newNode);
			}

			return ret;
		}

        public static List<Controls.Objects.TreeNodeEx> GetNodexEx(this List<Objects.Projects.RootObject> rol)
        {
            List<Controls.Objects.TreeNodeEx> ret = new List<Controls.Objects.TreeNodeEx>();

            foreach (Objects.Projects.RootObject ro in rol)
            {
                Controls.Objects.TreeNodeEx newNode = new Controls.Objects.TreeNodeEx(ro.id, Controls.Objects.TreeNodeExType.Project);
                newNode.Text = ro.name;
                newNode.CanExpand = false;
                newNode.Archived = ro.archived;
                newNode.Name = ro.name;
                ret.Add(newNode);
            }

            return ret;
        }

		public static List<Controls.Objects.ListEntryEx> GetListEntryEx(this List<Objects.Passwords.RootObject> rol)
		{
			return rol.Select(s => new Controls.Objects.ListEntryEx()
			{
				access_info = s.access_info,
				archived = s.archived,
				email = s.email,
				expiry_date = s.expiry_date,
				expiry_status = s.expiry_status,
				external_sharing = s.external_sharing,
				favorite = s.favorite,
				id = s.id,
				locked = s.locked,
				name = s.name,
				notes_snippet = s.notes_snippet,
				num_files = s.num_files,
				project = s.project,
				tags = s.tags,
				updated_on = s.updated_on,
				username = s.username
			}).ToList();
		}

		public static Controls.Objects.PasswordEntry GetPasswordEntryEx(this Objects.PasswordInfo.RootObject rol)
		{
			return new Controls.Objects.PasswordEntry()
			{
				access_info = rol.access_info,
				archived = rol.archived,
				created_by = rol.created_by,
				created_on = rol.created_on,
				custom_field1 = rol.custom_field1,
				custom_field2 = rol.custom_field2,
				custom_field3 = rol.custom_field3,
				custom_field4 = rol.custom_field4,
				custom_field5 = rol.custom_field5,
				custom_field6 = rol.custom_field6,
				custom_field7 = rol.custom_field7,
				custom_field8 = rol.custom_field8,
				custom_field9 = rol.custom_field9,
				custom_field10 = rol.custom_field10,
				email = rol.email,
				expiry_date = rol.expiry_date,
				expiry_status = rol.expiry_status,
				external_sharing = rol.external_sharing,
				external_url = rol.external_url,
				favorite = rol.favorite,
				groups_permissions = rol.groups_permissions,
				id = rol.id,
				locked = rol.locked,
				managed_by = rol.managed_by,
				name = rol.name,
				notes = rol.notes,
				num_files = rol.num_files,
				parents = rol.parents,
				password = rol.password,
				project = rol.project,
				tags = rol.tags,
				updated_by = rol.updated_by,
				updated_on = rol.updated_on,
				username = rol.username,
				users_permissions = rol.users_permissions,
				user_permission = rol.user_permission
			};
		}

        public static string GetMainModuleFileName(this Process process, int buffer = 1024)
        {
            var fileNameBuilder = new StringBuilder(buffer);
            uint bufferLength = (uint)fileNameBuilder.Capacity + 1;

            if (QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) != 0)
                return fileNameBuilder.ToString();
            else
                return null;
        }

        private static string EscapeForSendKeys(string text)
        {
            StringBuilder sb = new StringBuilder();
            char[] specialChars = new char[]
            {
                '{', '}', '(', ')', '+', '^', '~', '%'
            };

            foreach (char curChar in text)
            {
                if (specialChars.Contains(curChar))
                    sb.Append(string.Format("{{{0}}}", curChar));
                else
                    sb.Append(curChar);
            }

            return sb.ToString();
        }

        public static void SendKeysEx(this string toSend, bool sendWait = false)
        {
            SendKeys.Flush();

            if (sendWait)
                SendKeys.SendWait(EscapeForSendKeys(toSend));
            else
                SendKeys.Send(EscapeForSendKeys(toSend));
        }

        private static Timer SendDelayTimer = new Timer();
        private static string SendDelayToSend = null;
        private static bool SendDelaySendWait = false;

        public static void SendKeysExDelay(this string toSend, int keyDelayMs, bool sendWait = false)
        {
            try { SendDelayTimer.Stop(); } catch { }

            if(keyDelayMs <= 0)
            {
                toSend.SendKeysEx(sendWait);
                return;
            }

            SendDelayToSend = toSend;
            SendDelaySendWait = sendWait;

            SendDelayTimer = new Timer();
            SendDelayTimer.Interval = keyDelayMs;
            SendDelayTimer.Enabled = true;
            SendDelayTimer.Tick += SendDelayTimer_Tick;
            SendDelayTimer.Start();
        }

        private static void SendDelayTimer_Tick(object sender, EventArgs e)
        {
            SendDelayTimer.Stop();
            if (string.IsNullOrWhiteSpace(SendDelayToSend))
                return;

            string sendKey = SendDelayToSend[0].ToString();
            SendDelayToSend = SendDelayToSend.Substring(1);

            SendKeys.Flush();

            if (SendDelaySendWait)
                SendKeys.SendWait(EscapeForSendKeys(sendKey));
            else
                SendKeys.Send(EscapeForSendKeys(sendKey));

            SendDelayTimer.Start();
        }
    }
}
