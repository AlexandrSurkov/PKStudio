using OptionsHelper.Options;
using PKStudio.Forms.Options.Options;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Diagnostics;

namespace PKStudio.Forms.Options.Pages
{
    public partial class EnvironmentOptionsPage : OptionsControlBase
    {
        public EnvironmentOptionsPage(OptionsBase option)
        {
            InitializeComponent();
            this.controlledOption = option;

            ToolCB.Items.Clear();

            ToolCB.Items.Add("GCC");
            ToolCB.Items.Add("GCCOP");
            ToolCB.Items.Add("MDK");
            ToolCB.Items.Add("RVDS");
            ToolCB.Items.Add("SHC");
            ToolCB.Items.Add("VS");

            ToolCB.SelectedIndex = 3;
            UpdatePath();
            this.Modified = false;
        }

        #region Override

        public override string NodeName
        {
            get
            {
                return Strings.ENVIRONMENT;
            }
        }
        public override bool OnApplyChanges()
        {
            return this.controlledOption.OnApplyChanges();
        }

        protected override void OnInitialized()
        {
            this.controlledOption.OnInitialized();
            this.RefreshControl();
        }

        public override void SetOption(OptionsBase option)
        {
            base.SetOption(option);
            ((EnvironmentOption)option).OnApplyChanges();
            this.RefreshControl();

            ModifiedChange();
        }

        private void RefreshControl()
        {
            EnvironmentOption eo = (EnvironmentOption)this.controlledOption;

            PathTB.Text = eo.Path;
            ToolCB.SelectedIndex = (int)eo.Tool;
            VersionTB.Text = eo.Version;
            this.Modified = false;
        }
        #endregion

        private void BrowseBtn_Click(object sender, System.EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                PathTB.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ToolCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            EnvironmentOption eo = (EnvironmentOption)this.controlledOption;
            eo.Tool = (EnvironmentOption.TOOL)ToolCB.SelectedIndex;

            UpdatePath();

            ModifiedChange();
        }

        private void UpdatePath()
        {
            if (string.IsNullOrEmpty(PathTB.Text) || (string.IsNullOrEmpty(VersionTB.Text)))
            {
                switch ((EnvironmentOption.TOOL)ToolCB.SelectedIndex)
                {
                    case EnvironmentOption.TOOL.GCC:
                        break;
                    case EnvironmentOption.TOOL.GCC_OP:
                        break;
                    case EnvironmentOption.TOOL.SHC:
                        break;
                    case EnvironmentOption.TOOL.MDK:
                        RegistryKey key = null;
                        key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Keil\Products\MDK");
                        if (key != null)
                        {
                            PathTB.Text = (string)key.GetValue("Path", "");
                            VersionTB.Text = ((string)key.GetValue("Version", "")).TrimStart(new[]{'V'});
                            break;
                        }
                        key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Keil\Products\RLARM");
                        if (key != null)
                        {
                            PathTB.Text = (string)key.GetValue("Path", "");
                            VersionTB.Text = ((string)key.GetValue("Version", "")).TrimStart(new[] { 'V' });
                            break;
                        }
                        break;
                    case EnvironmentOption.TOOL.RVDS:
                        break;
                }

                //ModifiedChange();
            }
        }

        private void PathTB_TextChanged(object sender, System.EventArgs e)
        {
            EnvironmentOption eo = (EnvironmentOption)this.controlledOption;
            eo.Path = PathTB.Text;
            ModifiedChange();
        }

        private void VersionTB_TextChanged(object sender, System.EventArgs e)
        {
            EnvironmentOption eo = (EnvironmentOption)this.controlledOption;
            eo.Version = VersionTB.Text;
            ModifiedChange();

        }
    }
}
