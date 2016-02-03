
using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class StubLibraryPage : LibraryCategoryPageBase
    {
        public StubLibraryPage(LibraryCategoryWrapper LibCat)
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
                return Strings.StubLibrary;
            }
        }
        public override bool OnApplyChanges()
        {
            if (StubLibLV.Items.Count > 0)
                LibCat.StubLibrary = (ComponentWrapper)StubLibLV.Items[0].Tag;
            else
                LibCat.StubLibrary = ComponentWrapper.GetComponentWrapper(ComponentTypeWrapper.Library);
            return true;
        }

        protected override void RefreshControl()
        {
            StubLibLV.Items.Clear();
            if (LibCat.StubLibrary != null)
            {
                if (!string.IsNullOrEmpty(LibCat.StubLibrary.Guid))
                {
                    ListViewItem it = StubLibLV.Items.Add(LibCat.StubLibrary.Name);
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Library;
                    it.Tag = LibCat.StubLibrary;
                }
            }
        }

        #endregion

        private void SelectStubLibBtn_Click(object sender, System.EventArgs e)
        {
            using (Dialogs.SelectComponentDialog scf = new Dialogs.SelectComponentDialog(true, false, false, false, false, false, false, false, false, false))
            {
                scf.LibraryFilter.IsStub = true;
                scf.UpdateDialog();
                if (scf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    StubLibLV.Items.Clear();
                    ComponentWrapper c = scf.SelectedComponent;
                    ListViewItem it = StubLibLV.Items.Add(c.Name);
                    it.Tag = c;
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Library;
                    StubLibLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    ModifiedChange();
                }
            }
        }

        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
            if (StubLibLV.Items.Count > 0)
            {
                if (MessageBox.Show(this, Strings.Clear + " " + Strings.StubLibrary + " \"" + StubLibLV.Items[0].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    StubLibLV.Items.Clear();
                    ModifiedChange();
                }
            }
        }
    }
}
