using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;

namespace PKStudio.Forms.Editors.Pages.Library
{
    public partial class DependenciesPage : LibraryPageBase
    {
        public DependenciesPage(LibraryWrapper Lib)
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
                return Strings.Dependencies;
            }
        }
        public override bool OnApplyChanges()
        {

            DepsInfoRTB.Clear();
            Lib.Dependencies.Clear();
            foreach (ListViewItem item in DepsListView.Items)
            {
                if (item.Text == ComponentTypeWrapper.Library.ToString())
                {
                    LibraryWrapper l = PK.Wrapper.FindLibraryByName(item.SubItems[1].Text);
                    if (l != null)
                    {
                        Lib.Dependencies.Add(ComponentWrapper.GetComponentWrapper(l));
                    }
                }

                if (item.Text == ComponentTypeWrapper.LibraryCategory.ToString())
                {
                    LibraryCategoryWrapper lc = PK.Wrapper.FindLibraryCategoryByName(item.SubItems[1].Text);
                    if (lc != null)
                    {
                        Lib.Dependencies.Add(ComponentWrapper.GetComponentWrapper(lc));
                    }
                }
            }

            return true;
        }

        protected override void RefreshControl()
        {
            DepsListView.Items.Clear();
            foreach (ComponentWrapper dep in this.Lib.Dependencies)
            {
                ListViewItem it = DepsListView.Items.Add(dep.ComponentType.ToString());
                it.SubItems.Add(dep.Name);
                switch (dep.ComponentType)
                {
                    case ComponentTypeWrapper.Library:
                        it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Library;
                        break;
                    case ComponentTypeWrapper.LibraryCategory:
                        it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.LibraryCategory;
                        break;
                    case ComponentTypeWrapper.Feature:
                    case ComponentTypeWrapper.MFAssembly:
                    case ComponentTypeWrapper.MFSolution:
                    case ComponentTypeWrapper.Processor:
                    case ComponentTypeWrapper.OperatingSystem:
                    case ComponentTypeWrapper.BuildTool:
                    case ComponentTypeWrapper.ISA:
                    case ComponentTypeWrapper.BuildParameter:
                    case ComponentTypeWrapper.Unknown:
                    default:
                        break;
                }

            }
            if (DepsListView.Items.Count > 0)
                DepsListView.Items[0].Selected = true;
        }

        #endregion


        #region Dependencies

        private void DepsListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (DepsListView.SelectedItems.Count != 0)
            {
                if (DepsListView.SelectedItems[0] != null)
                {
                    if (DepsListView.Items[DepsListView.SelectedIndices[0]].SubItems[0].Text == ComponentTypeWrapper.Library.ToString())
                    {
                        LibraryWrapper l = PK.Wrapper.FindLibraryByName(DepsListView.Items[DepsListView.SelectedIndices[0]].SubItems[1].Text);
                        if (l != null)
                        {
                            this.ShowDependencyDescription(ComponentWrapper.GetComponentWrapper(l));
                        }
                    }

                    if (DepsListView.Items[DepsListView.SelectedIndices[0]].SubItems[0].Text == ComponentTypeWrapper.LibraryCategory.ToString())
                    {
                        LibraryCategoryWrapper lc = PK.Wrapper.FindLibraryCategoryByName(DepsListView.Items[DepsListView.SelectedIndices[0]].SubItems[1].Text);
                        if (lc != null)
                        {
                            this.ShowDependencyDescription(ComponentWrapper.GetComponentWrapper(lc));
                        }
                    }
                }
                else DepsInfoRTB.Clear();
            }
            else DepsInfoRTB.Clear();
        }


        private void ShowDependencyDescription(ComponentWrapper dep)
        {
            DepsInfoRTB.Clear();

            switch (dep.ComponentType)
            {
                case ComponentTypeWrapper.Library:
                    LibraryWrapper lib = PK.Wrapper.FindLibrary(dep);
                    if (lib != null)
                    {
                        DepsInfoRTB.AppendText("Library\r\n");
                        DepsInfoRTB.AppendText("Name              : " + lib.Name.ToString() + "\r\n");
                        DepsInfoRTB.AppendText("Description       : " + lib.Description.ToString() + "\r\n");
                        DepsInfoRTB.AppendText("Documentation     : " + lib.Documentation.ToString() + "\r\n");
                        DepsInfoRTB.AppendText("Groups            : " + lib.Groups.ToString() + "\r\n");
                        DepsInfoRTB.AppendText("Guid              : " + lib.Guid.ToString() + "\r\n");
                        DepsInfoRTB.AppendText("ProjectPath       : " + lib.ProjectPath.ToString() + "\r\n");
                    }
                    break;
                case ComponentTypeWrapper.LibraryCategory:
                    LibraryCategoryWrapper LibCat = PK.Wrapper.FindLibraryCategory(dep.Guid);
                    DepsInfoRTB.AppendText("Library Category \r\n");
                    DepsInfoRTB.AppendText("Name              : " + LibCat.Name.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Description       : " + LibCat.Description.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Documentation     : " + LibCat.Documentation.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Groups            : " + LibCat.Groups.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Guid              : " + LibCat.Guid.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("ProjectPath       : " + LibCat.ProjectPath.ToString() + "\r\n");
                    break;
                case ComponentTypeWrapper.Feature:
                case ComponentTypeWrapper.MFAssembly:
                case ComponentTypeWrapper.MFSolution:
                case ComponentTypeWrapper.Processor:
                case ComponentTypeWrapper.OperatingSystem:
                case ComponentTypeWrapper.BuildTool:
                case ComponentTypeWrapper.ISA:
                case ComponentTypeWrapper.BuildParameter:
                case ComponentTypeWrapper.Unknown:
                default:
                    DepsInfoRTB.AppendText("ComponentType       : " + dep.ComponentType.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Name                : " + dep.Name + "\r\n");
                    DepsInfoRTB.AppendText("Conditional         : " + dep.Conditional + "\r\n");
                    DepsInfoRTB.AppendText("ProjectPath         : " + dep.ProjectPath + "\r\n");
                    DepsInfoRTB.AppendText("Guid                : " + dep.Guid.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("RefCount            : " + dep.RefCount.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("RefCountSpecified   : " + dep.RefCountSpecified.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("VersionDependency   : " + dep.VersionDependency.ToString() + "\r\n");
                    break;
            }


        }

        private void DepDeleteBtn_Click(object sender, System.EventArgs e)
        {
            if (DepsListView.SelectedItems.Count != 0)
            {
                if (DepsListView.SelectedItems[0] != null)
                {
                    if (MessageBox.Show(this, Strings.DeleteDependency + " \"" + DepsListView.SelectedItems[0].SubItems[1].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DepsListView.Items.Remove(DepsListView.SelectedItems[0]);
                        ModifiedChange();
                    }

                    if (DepsListView.Items.Count > 0)
                        DepsListView.Items[0].Selected = true;
                }
            }
        }

        private void DepAddBtn_Click(object sender, System.EventArgs e)
        {
            using (Dialogs.SelectComponentDialog sf = new Dialogs.SelectComponentDialog(true, false, false, false, false, false, false, false, false, true))
            {
                if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //ComponentWrapper c = sf.SelectedComponent;

                    ListViewItem it = DepsListView.Items.Add(sf.SelectedComponent.ComponentType.ToString());
                    it.SubItems.Add(sf.SelectedComponent.Name);
                    switch (sf.SelectedComponent.ComponentType)
                    {
                        case ComponentTypeWrapper.Library:
                            it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Library;
                            break;
                        case ComponentTypeWrapper.LibraryCategory:
                            it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.LibraryCategory;
                            break;
                        case ComponentTypeWrapper.Feature:
                        case ComponentTypeWrapper.MFAssembly:
                        case ComponentTypeWrapper.MFSolution:
                        case ComponentTypeWrapper.Processor:
                        case ComponentTypeWrapper.OperatingSystem:
                        case ComponentTypeWrapper.BuildTool:
                        case ComponentTypeWrapper.ISA:
                        case ComponentTypeWrapper.BuildParameter:
                        case ComponentTypeWrapper.Unknown:
                        default:
                            break;
                    }
                    it.Selected = true;

                    ModifiedChange();
                }
            }
        }

        #endregion
    }
}
