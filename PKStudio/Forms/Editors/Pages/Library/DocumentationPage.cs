
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class DocumentationPage : LibraryPageBase
    {
        public DocumentationPage(LibraryWrapper Lib)
            : base(Lib)
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
            this.Lib.Documentation = DocumentationRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            DocumentationRtb.Text = this.Lib.Documentation;
        }

        #endregion

        private void DocumentationRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
