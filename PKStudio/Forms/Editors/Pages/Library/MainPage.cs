using System.IO;
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class MainPage : LibraryPageBase
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(LibraryWrapper Lib)
            : base(Lib)
        {
            InitializeComponent();

            GroupsCb.Items.Clear();
            GroupsCb.Items.Add("");

            foreach (LibraryWrapper lib in PK.Wrapper.GetLibraries())
            {
                if (!GroupsCb.Items.Contains(lib.Groups))
                {
                    GroupsCb.Items.Add(lib.Groups);
                }
            }

            LevelCb.Items.Clear();
            LevelCb.Items.Add(LibraryLevelWrapper.CLR);
            LevelCb.Items.Add(LibraryLevelWrapper.HAL);
            LevelCb.Items.Add(LibraryLevelWrapper.PAL);
            LevelCb.Items.Add(LibraryLevelWrapper.Support);
            LevelCb.SelectedItem = LibraryLevelWrapper.CLR;

            HeaderLbl.Text = this.NodeName;
        }

        #region Override

        public override string NodeName
        {
            get
            {
                return Strings.Main;
            }
        }
        public override bool OnApplyChanges()
        {
            this.Lib.Name = NameTb.Text + nameSuffixLbl.Text;
            this.Lib.LibraryFile = Lib.Name + ".$(LIB_EXT)";
            this.Lib.ManifestFile = Lib.Name + ".$(LIB_EXT).manifest";
            this.Lib.Groups = GroupsCb.Text;
            this.Lib.Level = (LibraryLevelWrapper)LevelCb.SelectedItem;
            //this.Lib.ProjectPath = DirectoryTb.Text + "\\" + ProjNameTb.Text + projSuffixLbl.Text + ".proj";
            //this.Lib.IsStub = IsStubCb.Checked;

            return true;
        }

        protected override void RefreshControl()
        {
            if (GroupsCb.Items.Contains(Lib.Groups)) GroupsCb.SelectedItem = Lib.Groups;
            else
            {
                if (GroupsCb.Items.Count > 0) GroupsCb.SelectedIndex = 0;
            }

            string name = Lib.Name;
            string projname = Path.GetFileNameWithoutExtension(Lib.ProjectPath);

            if (Lib.Name.Contains("test") && projname.Contains("_test"))
            {
                TestCb.Checked = true;
            }
            else TestCb.Checked = false;

            IsStubCb.Checked = Lib.IsStub;

            if (Lib.Name.Contains("test"))
            {
                name = Lib.Name.Replace("test", "");
            }
            else if (Lib.Name.Contains("_stub"))
            {
                name = Lib.Name.Replace("_stub", "");
            }
            else if (Lib.Name.Contains("_stubs"))
            {
                name = Lib.Name.Replace("_stubs", "");
            }
            else
            {
                name = Lib.Name;
            }

            NameTb.Text = name;

            LevelCb.SelectedItem = Lib.Level;

            DirectoryTb.Text = Path.GetDirectoryName(Lib.ProjectPath);

            if (projname.Contains("_test"))
            {
                projname = projname.Replace("_test", "");                
            }

            ProjNameTb.Text = projname;

            SetSuffixs();
        }

        #endregion


        #region helpers

        private void SetSuffixs()
        {
            if (TestCb.Checked)
            {
                nameSuffixLbl.Text = "test";
                projSuffixLbl.Text = "_test";
            }
            else
            {
                projSuffixLbl.Text = "";
                if (IsStubCb.Checked)
                {
                    nameSuffixLbl.Text = "_stubs";
                    if (!DirectoryTb.Text.Contains("\\stubs"))
                    {
                        DirectoryTb.Text = DirectoryTb.Text + "\\stubs";
                    }
                }
                else
                {
                    nameSuffixLbl.Text = "";
                    if (DirectoryTb.Text.Contains("\\stubs"))
                    {
                        DirectoryTb.Text = DirectoryTb.Text.Replace("\\stubs", "");
                    }
                }
            }
        }

        #endregion

        private void IsStubCb_CheckedChanged(object sender, System.EventArgs e)
        {
            bool chk = IsStubCb.Checked;
            if (TestCb.Checked) TestCb.Checked = false;
            IsStubCb.Checked = chk;
            SetSuffixs();
            ModifiedChange();
        }

        private void TestCb_CheckedChanged(object sender, System.EventArgs e)
        {
            bool chk = TestCb.Checked;
            if (IsStubCb.Checked) IsStubCb.Checked = false;
            TestCb.Checked = chk;
            SetSuffixs();
            ModifiedChange();
        }

        private void BrowseBtn_Click(object sender, System.EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = PK.Wrapper.ExpandEnvVars(DirectoryTb.Text, "");
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryTb.Text = PK.Wrapper.ConvertPathToEnv(folderBrowserDialog1.SelectedPath);
                ModifiedChange();
            }
        }

        private void NameTb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void GroupsCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void GroupsCb_TextUpdate(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void LevelCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void DirectoryTb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void ProjNameTb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
