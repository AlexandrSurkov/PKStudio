using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class TemplatesPage : LibraryCategoryPageBase
    {
        public TemplatesPage(LibraryCategoryWrapper LibCat)
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
                return Strings.LibraryProjCache;
            }
        }
        public override bool OnApplyChanges()
        {
           

            return true;
        }

        protected override void RefreshControl()
        {
            TemplatesRtb.Clear();
            foreach (ApiTemplateWrapper s in LibCat.Templates)
            {
                TemplatesRtb.AppendText("FilePath: " + s.FilePath + "\r\n");
                TemplatesRtb.AppendText("Description: " + s.Description + "\r\n\r\n");
            }
        }

        #endregion
    }
}
