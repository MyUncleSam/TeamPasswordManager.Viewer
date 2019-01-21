using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace TeamPassword.Viewer
{
    /// <summary>
    /// this class manages the autostart of the current software using the scheduler logon option
    /// It creates an entry for the current user which executes the program on logon. This entry
    /// is always enabled because it seems to be a hard 
    /// </summary>
    public sealed class ManageAutostart
    {
        private static ManageAutostart _Instance = null;

        /// <summary>
        /// get the singleton instance
        /// </summary>
        /// <returns></returns>
        public static ManageAutostart Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ManageAutostart();
                }
                return _Instance;
            }
        }

        private const string ActionIdentifier = "TeamPasswordManager.Viewer.Autostart";
        private const string Description = "TeamPasswordManager Viewer AutoStart";
        private Task AutostartTask = null;

        /// <summary>
        /// initialize the autostart entries (creates them if needed)
        /// </summary>
        private ManageAutostart()
        {
            AutostartTask = GetTask;
            if (GetTask == null)
            {
                CreateTask();
            }

            CheckTask();
        }

        /// <summary>
        /// checks if there is already a known task which should start the evechatnotifier
        /// </summary>
        /// <returns></returns>
        public bool HasTask()
        {
            return GetTask != null;
        }

        /// <summary>
        /// checks the task if the execution path is up2date (because the application should be portable)
        /// </summary>
        public void CheckTask()
        {
            if (GetTask.Definition.Actions.Count != 1 || GetTask.Definition.Triggers.Count != 1)
            {
                // no idea what happened - recreate the task
                TaskService.Instance.RootFolder.DeleteTask(GetTask.Name);
                CreateTask();
            }

            // check action
            ExecAction ea = (ExecAction)GetTask.Definition.Actions.First();
            if (!ea.Path.Equals(Application.ExecutablePath))
            {
                // need to update the current task path
                ea.Path = Application.ExecutablePath;
                ea.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                GetTask.RegisterChanges();
            }
        }

        /// <summary>
        /// registers the startup task (load on logon) for the current user
        /// </summary>
        private void CreateTask()
        {
            TaskDefinition td = TaskService.Instance.NewTask();
            td.RegistrationInfo.Description = Description;
            td.Settings.Enabled = false; // not enabled by default

            LogonTrigger lt = new LogonTrigger();
            //lt.Delay = new TimeSpan(0, 1, 0);
            lt.Enabled = true; // action is always enabled, active or not is managed using the task definition
            lt.Id = ActionIdentifier;
            lt.UserId = Environment.UserName;
            td.Triggers.Add(lt);

            td.Actions.Add(Application.ExecutablePath, null, System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            AutostartTask = TaskService.Instance.RootFolder.RegisterTaskDefinition(Description, td);
        }

        /// <summary>
        /// gets the task or null if not found
        /// </summary>
        public Task GetTask
        {
            get
            {
                if (AutostartTask != null)
                {
                    return AutostartTask;
                }
                return TaskService.Instance.RootFolder.Tasks.Where(w => w.Name.Equals(Description, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
        }

        /// <summary>
        /// is the logon task enabled or not?
        /// (if it is not there it is going to be created)
        /// </summary>
        /// <returns></returns>
        public bool Enabled
        {
            get
            {
                //return GetTask.Definition.Triggers[0].Enabled;
                return GetTask.Definition.Settings.Enabled;
            }
            set
            {
                if (GetTask.Definition.Settings.Enabled != value)
                {
                    GetTask.Definition.Settings.Enabled = value;
                    GetTask.RegisterChanges();
                }
                return;
            }
        }
    }
}
