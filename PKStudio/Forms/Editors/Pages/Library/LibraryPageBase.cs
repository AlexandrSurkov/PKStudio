
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class LibraryPageBase : BaseForms.ComponentEditor.EditorPageBase
    {
        protected LibraryWrapper Lib;

        public LibraryPageBase()
        {
            InitializeComponent();

        }

        public LibraryPageBase(LibraryWrapper Lib)
        {
            InitializeComponent();

            this.Lib = Lib;
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
