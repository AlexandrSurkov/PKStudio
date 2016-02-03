
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class DocumentationPage : LibraryCategoryPageBase
    {
        public DocumentationPage(LibraryCategoryWrapper LibCat)
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
                return Strings.Documentation;
            }
        }
        public override bool OnApplyChanges()
        {
            this.LibCat.Documentation = DocumentationRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            DocumentationRtb.Text = this.LibCat.Documentation;
        }

        #endregion

        private void DocumentationRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
