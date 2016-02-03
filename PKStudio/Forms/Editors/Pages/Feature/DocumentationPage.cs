
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Feature
{
    public partial class DocumentationPage : FeaturePageBase
    {
        public DocumentationPage(FeatureWrapper Feat)
            : base(Feat)
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
            this.Feat.Documentation = DocumentationRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            DocumentationRtb.Text = this.Feat.Documentation;
        }

        #endregion

        private void DocumentationRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
