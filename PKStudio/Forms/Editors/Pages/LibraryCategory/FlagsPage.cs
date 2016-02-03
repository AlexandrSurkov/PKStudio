
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class FlagsPage : LibraryCategoryPageBase
    {
        public FlagsPage(LibraryCategoryWrapper LibCat)
            : base(LibCat)
        {
            InitializeComponent();

            HeaderLbl.Text = this.NodeName;
        }

        #region Override

        public override string NodeName
        {
            get
            {
                return Strings.Flags;
            }
        }
        public override bool OnApplyChanges()
        {
            this.LibCat.IgnoreDefaultLibPath = IgnoreDefaultLibPathCheckBox.Checked;
            this.LibCat.IsTransport = IsTransportCheckBox.Checked;
            this.LibCat.Required = RequiredCheckBox.Checked;

            return true;
        }

        protected override void RefreshControl()
        {
            IgnoreDefaultLibPathCheckBox.Checked = this.LibCat.IgnoreDefaultLibPath;
            IsTransportCheckBox.Checked = this.LibCat.IsTransport;
            RequiredCheckBox.Checked = this.LibCat.Required;
        }

        #endregion

        private void IgnoreDefaultLibPathCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void IsTransportCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }

        private void RequiredCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
