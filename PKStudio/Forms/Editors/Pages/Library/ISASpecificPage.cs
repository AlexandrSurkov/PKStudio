using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class ISASpecificPage : LibraryPageBase
    {
        public ISASpecificPage(LibraryWrapper Lib)
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
                return Strings.ISASpecific;
            }
        }
        public override bool OnApplyChanges()
        {
            if (ListView.Items.Count > 0)
                Lib.ISASpecific = (ComponentWrapper)ListView.Items[0].Tag;
            else
                Lib.ISASpecific = ComponentWrapper.GetComponentWrapper(ComponentTypeWrapper.ISA);

            return true;
        }

        protected override void RefreshControl()
        {
            ListView.Items.Clear();
            if (Lib.ISASpecific != null)
            {
                if (!string.IsNullOrEmpty(Lib.ISASpecific.Guid))
                {
                    ListViewItem it = ListView.Items.Add(Lib.ISASpecific.Name);
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.ISA;
                    it.Tag = Lib.ISASpecific;
                }
            }
        }

        #endregion

        private void SelectStubLibBtn_Click(object sender, System.EventArgs e)
        {
            using (Dialogs.SelectComponentDialog scf = new Dialogs.SelectComponentDialog(false, false, false, false, false, false, false, true, false, false))
            {
                scf.UpdateDialog();
                if (scf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ListView.Items.Clear();
                    ComponentWrapper c = scf.SelectedComponent;
                    ListViewItem it = ListView.Items.Add(c.Name);
                    it.Tag = c;
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.ISA;
                    ModifiedChange();
                    ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
            if (ListView.Items.Count > 0)
            {
                if (MessageBox.Show(this, Strings.Clear + " " + Strings.ISA + " \"" + ListView.Items[0].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    ListView.Items.Clear();
                    ModifiedChange();
                }
            }
        }
    }
}
