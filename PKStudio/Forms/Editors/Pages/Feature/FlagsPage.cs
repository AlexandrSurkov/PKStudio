
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Feature
{
    public partial class FlagsPage : FeaturePageBase
    {
        public FlagsPage(FeatureWrapper Feat)
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
                return Strings.Flags;
            }
        }
        public override bool OnApplyChanges()
        {
            this.Feat.IsSolutionWizardVisible = IsSolutionWizardVisibleCB.Checked;
            this.Feat.Hidden = HiddenCheckBox.Checked;
            this.Feat.Required = RequiredCheckBox.Checked;

            return true;
        }

        protected override void RefreshControl()
        {
            IsSolutionWizardVisibleCB.Checked = this.Feat.IsSolutionWizardVisible;
            HiddenCheckBox.Checked = this.Feat.Hidden;
            RequiredCheckBox.Checked = this.Feat.Required;
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
