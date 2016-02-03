
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class DescriptionPage : LibraryPageBase
    {
        public DescriptionPage(LibraryWrapper Lib)
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
                return Strings.Description;
            }
        }
        public override bool OnApplyChanges()
        {
            this.Lib.Description = DescriptionRtb.Text;

            return true;
        }

        protected override void RefreshControl()
        {
            DescriptionRtb.Text = this.Lib.Description;
        }

        #endregion

        private void DescriptionRtb_TextChanged(object sender, System.EventArgs e)
        {
            ModifiedChange();
        }
    }
}
