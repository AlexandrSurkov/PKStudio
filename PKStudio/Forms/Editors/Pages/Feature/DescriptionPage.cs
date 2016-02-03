
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Feature
{
    public partial class DescriptionPage : FeaturePageBase
    {
        public DescriptionPage(FeatureWrapper Feat)
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
                return Strings.Description;
            }
        }
        public override bool OnApplyChanges()
        {
            this.Feat.Description = DescriptionRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            DescriptionRtb.Text = this.Feat.Description;
        }

        #endregion

        private void DescriptionRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
