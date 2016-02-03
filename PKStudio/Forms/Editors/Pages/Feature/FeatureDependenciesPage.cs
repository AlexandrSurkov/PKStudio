using System.Windows.Forms;
using PKStudio.TreeNodes;
using PKStudio.ItemWrappers;
using PKStudio.Tree;
using PKStudio.Forms.BaseForms;

namespace PKStudio.Forms.Editors.Pages.Feature
{
    public partial class FeatureDependenciesPage : FeaturePageBase , IEventComponent
    {
        public FeatureDependenciesPage(FeatureWrapper Feat)
            : base(Feat)
        {
            InitializeComponent();
            _treeView.AddIconControl("Icon");
            _treeView.AddTextBoxControl("Name");
            HeaderLbl.Text = this.NodeName;
        }

        #region Override

        public override string NodeName
        {
            get
            {
                return Strings.FeatureDependencies;
            }
        }
        public override bool OnApplyChanges()
        {

            //DepsInfoRTB.Clear();
            //Lib.Dependencies.Clear();
            //foreach (ListViewItem item in DepsListView.Items)
            //{
            //    if (item.Text == MFComponentType.Library.ToString())
            //    {
            //        LibraryWrapper l = PK.Wrapper.FindLibraryByName(item.SubItems[1].Text);
            //        if (l != null)
            //        {
            //            Lib.Dependencies.Add(new MFComponent(MFComponentType.Library, l.Name, l.Guid, l.ProjectPath));                        
            //        }
            //    }

            //    if (item.Text == MFComponentType.LibraryCategory.ToString())
            //    {
            //        LibraryCategoryWrapper lc = PK.Wrapper.FindLibraryCategoryByName(item.SubItems[1].Text);
            //        if (lc != null)
            //        {
            //            Lib.Dependencies.Add(new MFComponent(MFComponentType.LibraryCategory, lc.Name, lc.Guid, lc.ProjectPath));
            //        }
            //    }   
            //}

            return true;
        }


        protected override void RefreshControl()
        {
            _treeView.SetModel(InventoryBrowserModel.GetModel(this.Feat.FeatureDependencies), false);
            //_treeView.Items.Clear();
            //foreach (ComponentWrapper dep in this.Feat.FeatureDependencies)
            //{
            //    ListViewItem it = DepsListView.Items.Add(dep.ComponentType.ToString());
            //    it.SubItems.Add(dep.Name);
            //    switch (dep.ComponentType)
            //    {
            //        case ComponentTypeWrapper.Feature:
            //            it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Feature;
            //            break;
            //        case ComponentTypeWrapper.LibraryCategory:
            //        case ComponentTypeWrapper.Library:
            //        case ComponentTypeWrapper.MFAssembly:
            //        case ComponentTypeWrapper.MFSolution:
            //        case ComponentTypeWrapper.Processor:
            //        case ComponentTypeWrapper.OperatingSystem:
            //        case ComponentTypeWrapper.BuildTool:
            //        case ComponentTypeWrapper.ISA:
            //        case ComponentTypeWrapper.BuildParameter:
            //        case ComponentTypeWrapper.Unknown:
            //        default:
            //            break;
            //    }

            //}
            //if (DepsListView.Items.Count > 0)
            //    DepsListView.Items[0].Selected = true;
        }

        #endregion


        #region Dependencies

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
                    FeatureWrapper feat = PK.Wrapper.FindFeature(dep.Guid);
                    DepsInfoRTB.AppendText("Feature \r\n");
                    DepsInfoRTB.AppendText("Name              : " + feat.Name.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Description       : " + feat.Description.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Documentation     : " + feat.Documentation.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Groups            : " + feat.Groups.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("Guid              : " + feat.Guid.ToString() + "\r\n");
                    DepsInfoRTB.AppendText("ProjectPath       : " + feat.ProjectPath.ToString() + "\r\n");
                    break;
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
            //if (DepsListView.SelectedItems.Count != 0)
            //{
            //    if (DepsListView.SelectedItems[0] != null)
            //    {
            //        if (MessageBox.Show(this, Strings.DeleteDependency + " \"" + DepsListView.SelectedItems[0].SubItems[1].Text + "\" ?", Strings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            //        {
            //            DepsListView.Items.Remove(DepsListView.SelectedItems[0]);
            //            ModifiedChange();
            //        }

            //        if (DepsListView.Items.Count > 0)
            //            DepsListView.Items[0].Selected = true;
            //    }
            //}
        }

        private void DepAddBtn_Click(object sender, System.EventArgs e)
        {
            //using (Dialogs.SelectComponentDialog sf = new Dialogs.SelectComponentDialog(false, true, false, false, false, false, false, false, false, false))
            //{
            //    if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        ComponentWrapper c = sf.SelectedComponent;

            //        ListViewItem it = DepsListView.Items.Add(sf.SelectedComponent.ComponentType.ToString());
            //        it.SubItems.Add(sf.SelectedComponent.Name);
            //        switch (sf.SelectedComponent.ComponentType)
            //        {
            //            case ComponentTypeWrapper.Library:
            //                it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Library;
            //                break;
            //            case ComponentTypeWrapper.LibraryCategory:
            //                it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.LibraryCategory;
            //                break;
            //            case ComponentTypeWrapper.Feature:
            //                it.ImageIndex = (int)MFTreeNodeBase.ImageKeysEnum.Feature;
            //                break;
            //            case ComponentTypeWrapper.MFAssembly:
            //            case ComponentTypeWrapper.MFSolution:
            //            case ComponentTypeWrapper.Processor:
            //            case ComponentTypeWrapper.OperatingSystem:
            //            case ComponentTypeWrapper.BuildTool:
            //            case ComponentTypeWrapper.ISA:
            //            case ComponentTypeWrapper.BuildParameter:
            //            case ComponentTypeWrapper.Unknown:
            //            default:
            //                break;
            //        }
            //        it.Selected = true;

            //        ModifiedChange();
            //    }
            //}
        }

        #endregion

        private void _treeView_SelectionChangedEvent(object sender, BaseForms.ObjectEventArgs e)
        {
            ComponentWrapper wrapper = e.Object as ComponentWrapper;
            if (wrapper != null)
            {
                this.ShowDependencyDescription(wrapper);
            }
        }

        #region IEventComponent Members

        public event System.EventHandler<ObjectEventArgs> SelectionChangedEvent
        {
            add
            {
                this._treeView.SelectionChangedEvent += value;
            }
            remove
            {
                this._treeView.SelectionChangedEvent -= value;
            }
        }

        public void OnSelectionChangeEvent(object obj)
        {
        }

        public event System.EventHandler<ObjectEventArgs> ShowPropertiesEvent;

        public void OnShowPropertiesEvent(object obj)
        {
            if (this.ShowPropertiesEvent != null)
            {
                this.ShowPropertiesEvent(this, new ObjectEventArgs(obj));
            }
        }

        public event System.EventHandler<ObjectEventArgs> ShowReferencesDiagramEvent;

        public void OnShowReferencesDiagramEvent(object obj)
        {
            if (this.ShowReferencesDiagramEvent != null)
            {
                this.ShowReferencesDiagramEvent(this, new ObjectEventArgs(obj));
            }
        }

        public event System.EventHandler<ObjectEventArgs> EditEvent;

        public void OnEditEvent(object obj)
        {
            if (this.EditEvent != null)
            {
                this.EditEvent(this, new ObjectEventArgs(obj));
            }
        }

        #endregion
    }
}
