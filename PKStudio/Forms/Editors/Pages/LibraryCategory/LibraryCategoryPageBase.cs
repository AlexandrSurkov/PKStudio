
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class LibraryCategoryPageBase : BaseForms.ComponentEditor.EditorPageBase
    {
        protected LibraryCategoryWrapper LibCat;

        public LibraryCategoryPageBase()
        {
            InitializeComponent();

        }

        public LibraryCategoryPageBase(LibraryCategoryWrapper LibCat)
        {
            InitializeComponent();

            this.LibCat = LibCat;
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
