using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PKStudio.ItemWrappers;
using System.Collections.ObjectModel;
using XsdInventoryFormatObject;

namespace PKStudio.TreeNodes
{
    class MFProjectTreeNode : MFTreeNodeBase
    {
        public MFProjectTreeNode()
        {
        }

        public ProjectWrapper Project { get; private set; }
        
        public MFProjectTreeNode(ProjectWrapper project)
            : base(project.Name, ImageKeysEnum.Project)
        {
            this.Project = project;
            this.Tag = project;

            #region Features

            MFTreeNodeBase FeaturesNode = new MFComponentsTreeNode("Features");//this.NewNode("Features", MFTreeNodeBase.TreeNodeType.Components, null, MFTreeNodeBase.ImageKeysEnum.Components);
            this.Nodes.Add(FeaturesNode);

            foreach (ComponentWrapper feat in this.Project.Features)
            {
                //FeatureWrapper f = PK.Wrapper.FindFeature(feat.Guid);
                MFTreeNodeBase FeatNode = new MFFeatureTreeNode(PK.Wrapper.FindFeature(feat.Guid));//this.NewNode(f.Name, MFTreeNodeBase.TreeNodeType.Feature, f, MFTreeNodeBase.ImageKeysEnum.Feature);
                FeaturesNode.Nodes.Add(FeatNode);
            }

            #endregion

            #region Library Categories

            MFTreeNodeBase LibraryCategoriesNode = new MFComponentsTreeNode("Library Categories");//this.NewNode("Library Categories", MFTreeNodeBase.TreeNodeType.Components, null, MFTreeNodeBase.ImageKeysEnum.Components);
            this.Nodes.Add(LibraryCategoriesNode);

            foreach (ComponentWrapper LibCat in this.Project.LibraryCategories)
            {
                MFTreeNodeBase LibCatNode = new MFLibCatTreeNode(PK.Wrapper.FindLibraryCategory(LibCat.Guid));//this.NewNode(lc.Name, MFTreeNodeBase.TreeNodeType.LibCat, lc, MFTreeNodeBase.ImageKeysEnum.LibraryCategory);
                LibraryCategoriesNode.Nodes.Add(LibCatNode);
            }

            #endregion

            #region Libraries
            MFTreeNodeBase LibraryesNode = new MFComponentsTreeNode("Libraries");//this.NewNode("Libraries", MFTreeNodeBase.TreeNodeType.Components, null, MFTreeNodeBase.ImageKeysEnum.Components);
            this.Nodes.Add(LibraryesNode);

            //Groups Libraries Dictionary
            SortedDictionary<string, TreeNode> LibGroupsDict = new SortedDictionary<string, TreeNode>();
            SortedList<string, TreeNode> LibVoidGroupsList = new SortedList<string, TreeNode>();

            foreach (ComponentWrapper l in this.Project.Libraries)
            {
                LibraryWrapper lib = PK.Wrapper.FindLibrary(l);

                if (lib != null)
                {
                    //MFTreeNodeBase LibNode = new MFLibraryTreeNode(lib, ref LibGroupsDict, ref LibVoidGroupsList);//this.NewNode(lib.Name, MFTreeNodeBase.TreeNodeType.Lib, lib, MFTreeNodeBase.ImageKeysEnum.Library);

                }
            }

            foreach (TreeNode tn in LibVoidGroupsList.Values)
            {
                LibraryesNode.Nodes.Add(tn);
            }

            foreach (TreeNode tn in LibGroupsDict.Values)
            {
                LibraryesNode.Nodes.Add(tn);
            }


            List<BuildFileWrapper> source_files = new List<BuildFileWrapper>(Project.SourceFiles);
            source_files.AddRange(Project.HeaderFiles);
            source_files.AddRange(Project.OtherFiles);
            source_files.Add(Project.ScatterFile);

            AddFileList(new CollectionWrapper<BuildFileWrapper, MFBuildFile>(source_files), this.Project.ProjectPath);
            
            #endregion
        }
    }
}
