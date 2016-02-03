using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using PKStudio.TreeNodes;

namespace PKStudio.Dialogs
{
    public partial class SaveChangesDialog : Form
    {
        public SaveChangesDialog()
        { 
            InitializeComponent();

            Helper.AssemblyInfoHelper asmhelper = new Helper.AssemblyInfoHelper(Assembly.GetExecutingAssembly());
            this.Text = asmhelper.Title;
            listView1.Items.Clear();
        }

        public DialogResult ShowDialog(IWin32Window owner, List<PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription> descs)
        {
            foreach (PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription s in descs)
            {
                this.AddItem(s);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            return this.ShowDialog(owner);
        }

        public DialogResult ShowDialog(IWin32Window owner, PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription desc)
        {
            this.AddItem(desc);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            return this.ShowDialog(owner);
        }

        private void AddItem(PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription item)
        {
            ListViewItem it = listView1.Items.Add(item.Name);            
            it.SubItems.Add(item.Note);
            switch (item.Type)
            {
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.Library:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Library;
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.Feature:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Feature;
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.MFSolution:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Solution;
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.Processor:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Processor;
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.ISA:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.ISA;
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.LibraryCategory:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.LibraryCategory;
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.MFBuildFile:
                    it.ImageIndex = (int)MFSourceFileTreeNode.FileName2ImageKey(item.Name);
                    break;
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.OperatingSystem:
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.BuildTool:
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.BuildParameter:
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.Unknown:
                case PKStudio.Forms.BaseForms.EditorBaseForm.EditedComponentDescription.ComponentType.MFAssembly:
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Unknown;
                    break;
                default:
                    break;
            }
        }

        private void Cancelbtn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void NoBtn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void Yesbtn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
                listView1.SelectedItems[0].Selected = false;
        }
    }
}
