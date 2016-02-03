
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class DescriptionPage : LibraryCategoryPageBase
    {
        public DescriptionPage(LibraryCategoryWrapper LibCat)
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
                return Strings.Description;
            }
        }
        public override bool OnApplyChanges()
        {
            this.LibCat.Description = DescriptionRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            DescriptionRtb.Text = this.LibCat.Description;
        }

        #endregion

        private void DescriptionRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
