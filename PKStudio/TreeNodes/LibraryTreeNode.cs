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
    class MFLibraryTreeNode : MFTreeNodeBase
    {
        public LibraryWrapper Lib { get; private set; }

        public MFLibraryTreeNode()
        {
        }

        public MFLibraryTreeNode(LibraryWrapper library)
        : base(library.Name, ImageKeysEnum.Library)
        {
            this.Lib = library;
            this.Tag = library;
     
        }

        public MFLibraryTreeNode(LibraryWrapper library, ref SortedDictionary<string, TreeNode> GroupsDict, ref SortedList<string, TreeNode> VoidGroupsList)
            : this(library)
        {
            List<BuildFileWrapper> source_list = new List<BuildFileWrapper>(this.Lib.FastCompileFiles);
            source_list.AddRange(this.Lib.HeaderFiles);
            source_list.AddRange(this.Lib.SourceFiles);

            //Dictionary<string, MFBuildFile> unic_source_list = new Dictionary<string, MFBuildFile>();
            //foreach (MFBuildFile source_file in source_list)
            //{
            //    unic_source_list.Add(source_file.File, source_file);
            //}
            AddFileList(new CollectionWrapper<BuildFileWrapper, MFBuildFile>(source_list), this.Lib.ProjectPath);

            if (! string.IsNullOrEmpty(this.Lib.Groups))
            {
                if (!GroupsDict.ContainsKey(this.Lib.Groups))
                {
                    MFTreeNodeBase GroupNode = new MFDirectoryTreeNode(Lib.Groups);//this.NewNode(lib.Groups, MFTreeNodeBase.TreeNodeType.Directory, MFTreeNodeBase.ImageKeysEnum.CollapsedDirectory);
                    GroupNode.Nodes.Add(this);
                    GroupsDict.Add(this.Lib.Groups, GroupNode);
                }
                else
                {
                    GroupsDict[this.Lib.Groups].Nodes.Add(this);
                }
            }
            else
            {
                VoidGroupsList.Add(this.Text, this);
            }
        }
    

    }
}
