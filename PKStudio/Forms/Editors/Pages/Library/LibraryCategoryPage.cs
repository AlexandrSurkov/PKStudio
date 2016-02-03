
using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class LibraryCategoryPage : LibraryPageBase
    {
        public LibraryCategoryPage(LibraryWrapper Lib)
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
                return Strings.LibraryCategory;
            }
        }
        public override bool OnApplyChanges()
        {
            if (LibCatLV.Items.Count > 0)
                Lib.LibraryCategory = (ComponentWrapper)LibCatLV.Items[0].Tag;
            else
                Lib.LibraryCategory = ComponentWrapper.GetComponentWrapper(ComponentTypeWrapper.LibraryCategory);

            return true;
        }

        protected override void RefreshControl()
        {
            LibCatLV.Items.Clear();
            if (Lib.LibraryCategory != null)
            {
                if (!string.IsNullOrEmpty(Lib.LibraryCategory.Guid))
                {
                    ListViewItem it = LibCatLV.Items.Add(Lib.LibraryCategory.Name);
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.LibraryCategory;
                    it.Tag = Lib.LibraryCategory;
                }
            }
        }

        #endregion

        private void SelectLibCatBtn_Click(object sender, System.EventArgs e)
        {
            using (Dialogs.SelectComponentDialog scf = new Dialogs.SelectComponentDialog(false, false, false, false, false, false, false, false, false, true))
            {
                scf.UpdateDialog();
                if (scf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    LibCatLV.Items.Clear();
                    ComponentWrapper c = scf.SelectedComponent;
                    ListViewItem it = LibCatLV.Items.Add(c.Name);
                    it.Tag = c;
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.LibraryCategory;
                    ModifiedChange();
                    LibCatLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
            if (LibCatLV.Items.Count > 0)
            {
                if (MessageBox.Show(this, Strings.Clear + " " + Strings.LibraryCategory + " \"" + LibCatLV.Items[0].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    LibCatLV.Items.Clear();
                    ModifiedChange();
                }
            }
        }

    }
}
