
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Feature
{
    public partial class FilterPage : FeaturePageBase
    {
        public FilterPage(FeatureWrapper Feat)
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
                return Strings.Filter;
            }
        }
        public override bool OnApplyChanges()
        {
            this.Feat.Filter = FilterRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            FilterRtb.Text = this.Feat.Filter;
        }

        #endregion

        private void FilterRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
