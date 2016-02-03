using System.Windows.Forms;
using System;
using PKStudio.ItemWrappers;

namespace PKStudio.Forms.Editors
{
    public partial class LibraryCategoryEditor : BaseForms.ComponentEditor.ComponentEditorBaseForm
    {
        public LibraryCategoryEditor()
            : base()
        {
            InitializeComponent();

            PK.Wrapper.LoadLibraryCategoriesAsyncCompleteEvent += new EventHandler(PKWrapper_LoadLibraryCategoriesAsyncCompleteEvent);
        }

        private LibraryCategoryWrapper LibCat;

        /// <summary>
        /// Sets LibrarayCategory for edition
        /// </summary>
        /// <param name="LibCat"></param>
        public void SetLibCat(LibraryCategoryWrapper LibCat)
        {
            UpdateForm(LibCat);
        }

        public override EditedComponentDescription EditedItemDesc
        {
            get
            {
                return new EditedComponentDescription() { Type = EditedComponentDescription.ComponentType.LibraryCategory, Name = LibCat.Name };
            }
        }

        public LibraryCategoryWrapper LibraryCategory { get { return this.LibCat; } }


        private void UpdateForm(LibraryCategoryWrapper LibCat)
        {
            FormText = Strings.LibraryCategory+" : " + LibCat.Name;
            ModifiedFormText = FormText + "*";

            this.LibCat = LibCat;

            this.Pages.Clear();

            this.Pages.Add(new Editors.Pages.LibraryCategory.MainPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.DescriptionPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.DocumentationPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.FlagsPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.StubLibraryPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.FeatureAssociationsPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.TemplatesPage(LibCat));
            this.Pages.Add(new Editors.Pages.LibraryCategory.LibraryProjCachePage(LibCat));

            this.Initialize();

            SetModified(false);
        }

        public override void Save()
        {
            //try
            //{
            //    ApplyChanges();
            //    if (PK.Wrapper.SaveLibraryCategoryProj(this.LibCat))
            //        SetModified(false);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        void PKWrapper_LoadLibraryCategoriesAsyncCompleteEvent(object sender, EventArgs e)
        {
            if (this.LibCat != null)
                this.SetLibCat(PK.Wrapper.FindLibraryCategory(this.LibCat.Guid));
        }
    }
}
