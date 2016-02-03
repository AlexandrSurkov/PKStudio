
using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class ProcessorSpecificPage : LibraryPageBase
    {
        public ProcessorSpecificPage(LibraryWrapper Lib)
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
                return Strings.ProcessorSpecific;
            }
        }
        public override bool OnApplyChanges()
        {
            if (ListView.Items.Count > 0)
                Lib.ProcessorSpecific = (ComponentWrapper)ListView.Items[0].Tag;
            else
                Lib.ProcessorSpecific = ComponentWrapper.GetComponentWrapper(ComponentTypeWrapper.Processor);

            return true;
        }

        protected override void RefreshControl()
        {
            ListView.Items.Clear();
            if (Lib.ProcessorSpecific != null)
            {
                if (!string.IsNullOrEmpty(Lib.ProcessorSpecific.Guid))
                {
                    ListViewItem it = ListView.Items.Add(Lib.ProcessorSpecific.Name);
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Processor;
                    it.Tag = Lib.ProcessorSpecific;
                }
            }
        }

        #endregion

        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
            if (ListView.Items.Count > 0)
            {
                if (MessageBox.Show(this, Strings.Clear + " " + Strings.Processor + " \"" + ListView.Items[0].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    ListView.Items.Clear();
                    ModifiedChange();
                }
            }
        }

        private void SelectStubLibBtn_Click(object sender, System.EventArgs e)
        {
            using (Dialogs.SelectComponentDialog scf = new Dialogs.SelectComponentDialog(false, false, false, false, true, false, false, false, false, false))
            {
                scf.UpdateDialog();
                if (scf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ListView.Items.Clear();
                    ComponentWrapper c = scf.SelectedComponent;
                    ListViewItem it = ListView.Items.Add(c.Name);
                    it.Tag = c;
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Processor;

                    ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    ModifiedChange();
                }
            }
        }
    }
}
