using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Deployment.WindowsInstaller;
using WixSharp;

namespace WixInstaller
{
    class Program
    {
        public readonly Id AppId = new Id("TeamPasswordManager.Viewer");
        public readonly Feature Feature = new Feature(new Id("TeamPasswordManager.Viewer_Feature"));

        static void Main(string[] args)
        {
            try
            {
                Project prj = new Project("TeamPasswordManager.Viewer"
                                    , new Dir(@"%ProgramFiles%\TeamPasswordManager.Viewer"
                                        , new DirFiles(@"Deploy\*.*")
                                        , new ExeFileShortcut()
                                        {
                                            Name = "TeamPasswordManager.Viewer",
                                            Target = "[INSTALLDIR]TeamPassword.Viewer.exe"
                                        }
                                        , new InternetShortcut()
                                        {
                                            Name = "TeamPasswordManager.Viewer Github",
                                            Target = "https://github.com/MyUncleSam/TeamPasswordManager.Viewer"
                                        }
                                    )
                                    , new Dir(@"%ProgramMenu%\TeamPasswordManager.Viewer"
                                        , new ExeFileShortcut()
                                        {
                                            Name = "TeamPasswordManager.Viewer",
                                            Target = "[INSTALLDIR]TeamPassword.Viewer.exe"
                                        }
                                        , new InternetShortcut()
                                        {
                                            Name = "TeamPasswordManager.Viewer Github",
                                            Target = "https://github.com/MyUncleSam/TeamPasswordManager.Viewer"
                                        }
                                    )
                                    , new Property("ALLUSERS", "1")
                                    , new CloseApplication(new Id("TeamPassword.Viewer.exe"), "TeamPassword.Viewer.exe", false, false)
                                    {
                                        PromptToContinue = false,
                                        Timeout = 15
                                    }
                                    //, new InstalledFileAction(new Id("TeamPassword.Viewer.exe"), "")
                                    //{
                                    //    Id = "Start_App",
                                    //    Step = Step.InstallFinalize,
                                    //    When = When.After,
                                    //    Return = Return.asyncNoWait,
                                    //    Execute = Execute.immediate,
                                    //    Impersonate = true,
                                    //    Condition = Condition.Installed
                                    //}
                                    //, new ManagedAction(CustomActions.CusAction,
                                    //                    Return.asyncNoWait,
                                    //                    When.After,
                                    //                    Step.InstallFinalize,
                                    //                    Condition.Installed)
                    );

                prj.GUID = new Guid("27aebaa4-d803-47c2-b078-e0eb87f297aa");
                prj.Name = "TeamPasswordManager.Viewer";
                prj.Version = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(@"Deploy\TeamPassword.Viewer.exe").ProductVersion);
                prj.Description = prj.Name;
                prj.OutFileName = string.Format("TeamPasswordManager.Viewer v{0}", prj.Version.ToString());
                prj.InstallPrivileges = InstallPrivileges.elevated;
                //prj.UI = WUI.WixUI_ProgressOnly;
                prj.UI = WUI.WixUI_Minimal;
                prj.Platform = Platform.x86;
                prj.ControlPanelInfo.UrlInfoAbout = "https://github.com/MyUncleSam/TeamPasswordManager.Viewer";
                prj.ControlPanelInfo.NoModify = true;
                prj.ControlPanelInfo.Manufacturer = "Stefan Ruepp";

                // this part is automatically performing an upgrade if the version is newer
                prj.MajorUpgradeStrategy = MajorUpgradeStrategy.Default;
                prj.MajorUpgradeStrategy.RemoveExistingProductAfter = Step.InstallInitialize;
                prj.PreserveTempFiles = false;

                prj.BuildMsi();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

        public class CustomActions
        {
            [CustomAction]
            public static ActionResult CusAction(Session session)
            {
                try
                {
                    System.Diagnostics.Process.Start(@"%ProgramFiles(x86)%\TeamPassword.Viewer.exe");
                }
                catch(Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(string.Format("Unable to start program: {0}{1}", Environment.NewLine, ex.ToString());
                }

                return ActionResult.Success;
            }
        }
    }
}
