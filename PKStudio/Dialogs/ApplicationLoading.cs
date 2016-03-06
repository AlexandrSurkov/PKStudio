using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using PKStudio.ItemWrappers;

namespace PKStudio.Dialogs
{
    public partial class ApplicationLoading : Form
    {
        public ApplicationLoading()
        {
            InitializeComponent();
            PK.Wrapper.AsyncProgressChanged += new ProgressChangedEventHandler(m_worker_ProgressChanged);
            PK.Wrapper.LoadInventoryAsyncCompleteEvent += new EventHandler(PKWrapper_LoadInventoryAsyncCompleteEvent);
        }

        void PKWrapper_LoadInventoryAsyncCompleteEvent(object sender, EventArgs e)
        {
            string buildToolName = Environment.GetEnvironmentVariable("COMPILER_TOOL");
            if (!string.IsNullOrEmpty(buildToolName))
            {
                BuildToolWrapper_ buildTool = PK.Wrapper.FindBuildToolByName(buildToolName.ToLowerInvariant());
                if (buildTool != null)
                {
                    foreach (PropertyWrapper property in buildTool.Properties)
                    {
                        if (property.Name == "SCATTER_EXT")
                        {
                            Environment.SetEnvironmentVariable("SCATTER_EXT", property.Value);
                        }
                        if (property.Name == "OBJ_EXT")
                        {
                            Environment.SetEnvironmentVariable("OBJ_EXT", property.Value);
                        }
                        if (property.Name == "EXE_EXT")
                        {
                            Environment.SetEnvironmentVariable("EXE_EXT", property.Value);
                        }
                        if (property.Name == "LIB_EXT")
                        {
                            Environment.SetEnvironmentVariable("LIB_EXT", property.Value);
                        }
                        //if (property.Name == "AssemblyName")
                        //{
                        //    Environment.SetEnvironmentVariable("AssemblyName", property.Value);
                        //}
                        //if (property.Name == "MSBuildProjectName")
                        //{
                        //    Environment.SetEnvironmentVariable("MSBuildProjectName", property.Value);
                        //}
                    }
                    //Environment.SetEnvironmentVariable("SCATTER_EXT", buildTool.Properties.);
                    //Environment.SetEnvironmentVariable("OBJ_EXT", buildTool.ObjExt);
                    //Environment.SetEnvironmentVariable("EXE_EXT", buildTool.BinExt);
                    //Environment.SetEnvironmentVariable("LIB_EXT", buildTool.LibExt);
                }
                //else
                //{
                //    //Set default values
                //    Environment.SetEnvironmentVariable("SCATTER_EXT", "xml");
                //    Environment.SetEnvironmentVariable("OBJ_EXT", "obj");
                //    Environment.SetEnvironmentVariable("EXE_EXT", "exe");
                //    Environment.SetEnvironmentVariable("LIB_EXT", "lib");
                //}
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        void m_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            ProgressLabel.Text = e.UserState.ToString();
        }

        private void DataBaseLoading_Shown(object sender, EventArgs e)
        {
            PK.Wrapper.LoadInventoryAsync();
        }



        private void ApplicationLoading_Load(object sender, EventArgs e)
        {
            Helper.AssemblyInfoHelper asmhelper = new Helper.AssemblyInfoHelper(Assembly.GetExecutingAssembly());

            TitleLbl.Text = asmhelper.Title;
            VersionLbl.Text = Strings.Version + " " + asmhelper.AssemblyVersion;
            CopyrightLbl.Text = asmhelper.Copyright;
            CopyrightLbl.SetBounds(this.Bounds.Width / 2 - CopyrightLbl.Bounds.Width / 2, CopyrightLbl.Bounds.Y, CopyrightLbl.Bounds.Width, CopyrightLbl.Bounds.Height);


            string path = Environment.GetEnvironmentVariable("SPOCLIENT");
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path) || !Directory.Exists(path + @"\DeviceCode\Targets\"))
            {
                MessageBox.Show(this, "Please set environment variables manually or run PKStudioLauncher.exe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }

            PK.Wrapper.SpoClientPath = path;

            string srcDirEnvVar = Environment.GetEnvironmentVariable("SRC_DIR");

            if (srcDirEnvVar == null)
            {
                Environment.SetEnvironmentVariable("SRC_DIR", "");
            }

            //if (string.IsNullOrEmpty(portingKitRegistryValue) || !Directory.Exists(portingKitRegistryValue))
            //{
            //    portingKitRegistryValue = Helper.GetPortingKitRegistryValue("", "InstallRoot");    
            //}
            //if (!string.IsNullOrEmpty(portingKitRegistryValue) && Directory.Exists(portingKitRegistryValue))
            //{
            //    path = portingKitRegistryValue;
            //}

            //if (!Directory.Exists(path) || !Directory.Exists(path + @"\DeviceCode\Targets\"))
            //{
            //    using (SetSPOForm of = new SetSPOForm())
            //    {
            //        if (of.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            //        {
            //            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            //            this.Close();
            //        }
            //        else
            //        {
            //            if (Directory.Exists(path + @"\DeviceCode\Targets\"))
            //                PK.Wrapper.SpoClientPath = of.Path;
            //            else
            //            {
            //                MessageBox.Show(this,".NET Micro Framework Porting Kit directory was not found.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            //                this.Close();
            //            }

            //        }
            //    }
            //}
            //else
            //{
            //    Environment.SetEnvironmentVariable("SPOCLIENT", path);
            //    PK.Wrapper.SpoClientPath = path;
            //}

            //string srcDirEnvVar = Environment.GetEnvironmentVariable("SRC_DIR");

            //if (srcDirEnvVar == null)
            //{
            //    Environment.SetEnvironmentVariable("SRC_DIR", "");
            //}
        }
    }
}
