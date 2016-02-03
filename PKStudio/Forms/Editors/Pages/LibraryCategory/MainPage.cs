using PKStudio.ItemWrappers;

namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class MainPage : LibraryCategoryPageBase
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(LibraryCategoryWrapper LibCat)
            :base(LibCat)
        {
            InitializeComponent();

            GroupsCb.Items.Clear();
            GroupsCb.Items.Add("");

            foreach (LibraryCategoryWrapper libCat in PK.Wrapper.GetLibraryCategories())
            {
                if (!GroupsCb.Items.Contains(libCat.Groups))
                {
                    GroupsCb.Items.Add(libCat.Groups);
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
            this.LibCat.Name = NameTb.Text + LevelLbl.Text;

            this.LibCat.Groups = GroupsCb.Text;

            this.LibCat.Level = (LibraryLevelWrapper)LevelCb.SelectedItem;

            return true;
        }

        protected override void RefreshControl()
        {
            string name = "";
            if (LibCat.Name.Contains("_HAL"))
            {
                name = LibCat.Name.Replace("_HAL", "");
            }
            else if (LibCat.Name.Contains("_PAL"))
            {
                name = LibCat.Name.Replace("_PAL", "");
            }
            else if (LibCat.Name.Contains("_CLR"))
            {
                name = LibCat.Name.Replace("_CLR", "");
            }
            else if (LibCat.Name.Contains("_Support"))
            {
                name = LibCat.Name.Replace("_Support", "");
            }
            else
            {
                name = LibCat.Name;
            }

            NameTb.Text = name;

            if (GroupsCb.Items.Contains(LibCat.Groups)) GroupsCb.SelectedItem = LibCat.Groups;
            else
            {
                if (GroupsCb.Items.Count > 0) GroupsCb.SelectedIndex = 0;
            }

            LevelCb.SelectedItem = LibCat.Level;
        }

        #endregion

        

        private void LevelCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LevelLbl.Text = "_" + LevelCb.Text;
            ModifiedChange();
        }

        private void NameTb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void GroupsCb_TextUpdate(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void GroupsCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
