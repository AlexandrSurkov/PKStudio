using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PKStudio.ItemWrappers;

namespace PKStudio.TreeNodes
{
    class MFLibCatTreeNode : MFTreeNodeBase
    {
        public MFLibCatTreeNode()
        {
        }
        public MFLibCatTreeNode(LibraryCategoryWrapper libcat)
            : base(libcat.Name, ImageKeysEnum.LibraryCategory)
        {
            this.LibCat = libcat;
            this.Tag = libcat;
        
        }

        public MFLibCatTreeNode(LibraryCategoryWrapper libcat, ref SortedDictionary<string, TreeNode> GroupsDict, ref SortedList<string, TreeNode> VoidGroupsList)
            : this (libcat)
        {

            if (!string.IsNullOrEmpty(LibCat.Groups))
            {
                if (!GroupsDict.ContainsKey(LibCat.Groups))
                {
                    MFTreeNodeBase GroupNode = new MFDirectoryTreeNode(LibCat.Groups);//this.NewNode(cat.Groups, MFTreeNodeBase.TreeNodeType.Directory, MFTreeNodeBase.ImageKeysEnum.CollapsedDirectory);
                    GroupNode.Nodes.Add(this);
                    GroupsDict.Add(LibCat.Groups, GroupNode);
                }
                else
                {
                    GroupsDict[LibCat.Groups].Nodes.Add(this);
                }
            }
            else
            {
                VoidGroupsList.Add(this.Text, this);
            }

        }

        public LibraryCategoryWrapper LibCat { get; private set; }
    }
}
