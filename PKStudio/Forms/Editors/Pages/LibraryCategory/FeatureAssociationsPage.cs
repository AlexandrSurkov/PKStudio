using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;
namespace PKStudio.Forms.Editors.Pages.LibraryCategory
{
    public partial class FeatureAssociationsPage : LibraryCategoryPageBase
    {
        public FeatureAssociationsPage(LibraryCategoryWrapper LibCat)
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
                return Strings.FeatureAssociations;
            }
        }
        public override bool OnApplyChanges()
        {
            InfoRtb.Clear();
            LibCat.FeatureAssociations.Clear();
            foreach (ListViewItem item in FAListBox.Items)
            {
                FeatureWrapper f = PK.Wrapper.FindFeatureByName(item.Text);

                if (f != null)
                {
                    LibCat.FeatureAssociations.Add(ComponentWrapper.GetComponentWrapper(f));
                }
            }

            return true;
        }

        protected override void RefreshControl()
        {
            FAListBox.Items.Clear();
            foreach (ComponentWrapper fa in LibCat.FeatureAssociations)
            {
                ListViewItem it = FAListBox.Items.Add(fa.Name);
                it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Feature;
            }
            if (FAListBox.Items.Count > 0)
                FAListBox.Items[0].Selected = true;
        }

        #endregion

        private void FAListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (FAListBox.SelectedItems.Count != 0)
            {
                if (FAListBox.SelectedItems[0] != null)
                {
                    FeatureWrapper f = PK.Wrapper.FindFeatureByName(FAListBox.Items[FAListBox.SelectedIndices[0]].Text);
                    if (f != null) this.ShowFeatureDescription(f);
                }
            }
        }

        private void ShowFeatureDescription(FeatureWrapper f)
        {
            if (f != null)
            {
                InfoRtb.Clear();

                InfoRtb.AppendText("Name            : " + f.Name + "\r\n");
                InfoRtb.AppendText("Groups          : " + f.Groups + "\r\n");
                InfoRtb.AppendText("Description     : " + f.Description + "\r\n");
                InfoRtb.AppendText("Documentation   : " + f.Documentation + "\r\n");
                InfoRtb.AppendText("ProjectPath     : " + f.ProjectPath + "\r\n");
                InfoRtb.AppendText("Guid            : " + f.Guid.ToString() + "\r\n");
            }
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            using (Dialogs.SelectComponentDialog sf= new Dialogs.SelectComponentDialog(false, true, false, false, false, false, false, false, false, false))
            {
                if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ComponentWrapper c = sf.SelectedComponent;
                    ListViewItem it = FAListBox.Items.Add(c.Name);
                    it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Feature;
                    it.Selected = true;

                    ModifiedChange();
                }
            }
        }

        private void DeleteBtn_Click(object sender, System.EventArgs e)
        {
            if (FAListBox.SelectedItems.Count != 0)
            {
                if (FAListBox.SelectedItems[0] != null)
                {
                    if (MessageBox.Show(this, Strings.DeleteFeatureAssociation + " \"" + FAListBox.SelectedItems[0].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        FAListBox.Items.Remove(FAListBox.SelectedItems[0]);
                        ModifiedChange();
                    }

                    if (FAListBox.Items.Count > 0)
                        FAListBox.Items[0].Selected = true;
                }
            }
        }
    }
}
