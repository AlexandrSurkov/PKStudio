
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Feature
{
    public partial class FeaturePageBase : BaseForms.ComponentEditor.EditorPageBase
    {
        protected FeatureWrapper Feat;

        public FeaturePageBase()
        {
            InitializeComponent();

        }

        public FeaturePageBase(FeatureWrapper Feat)
        {
            InitializeComponent();

            this.Feat = Feat;
        }

        protected override void OnInitialized()
        {
            this.RefreshControl();
        }

        protected virtual void RefreshControl()
        {
        }
    }
}
