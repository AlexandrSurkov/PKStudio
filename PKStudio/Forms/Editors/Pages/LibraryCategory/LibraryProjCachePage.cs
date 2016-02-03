
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class LibraryProjCachePage : LibraryCategoryPageBase
    {
        public LibraryProjCachePage(LibraryCategoryWrapper LibCat)
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
                return Strings.Templates;
            }
        }
        public override bool OnApplyChanges()
        {


            return true;
        }

        protected override void RefreshControl()
        {
            ProjCacheListBox.Items.Clear();
            foreach (string s in LibCat.LibraryProjCache)
            {
                ProjCacheListBox.Items.Add(s);
            }
        }

        #endregion
    }
}
