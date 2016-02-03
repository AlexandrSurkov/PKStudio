using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PKStudio.ItemWrappers;

namespace PKStudio.TreeNodes
{
    class MFFeatureTreeNode : MFTreeNodeBase
    {
        public MFFeatureTreeNode()
        {
        }

        public FeatureWrapper Feat { get; private set; }
        public MFFeatureTreeNode(FeatureWrapper feature)
            : base (feature.Name, ImageKeysEnum.Feature)
        {
            this.Feat = feature;
            this.Tag = feature;

        }
        public MFFeatureTreeNode(FeatureWrapper feature, ref SortedDictionary<string, TreeNode> GroupsDict, ref SortedList<string, TreeNode> VoidGroupsList)
            : this(feature)
        {
            if (!string.IsNullOrEmpty(feature.Groups))
            {
                if (!GroupsDict.ContainsKey(this.Feat.Groups))
                {
                    MFTreeNodeBase GroupNode = new MFDirectoryTreeNode(this.Feat.Groups);//this.NewNode(this.Feat.Groups, MFTreeNodeBase.TreeNodeType.Directory, MFTreeNodeBase.ImageKeysEnum.CollapsedDirectory);
                    GroupNode.Nodes.Add(this);
                    GroupsDict.Add(this.Feat.Groups, GroupNode);
                }
                else
                {
                    GroupsDict[this.Feat.Groups].Nodes.Add(this);
                }
            }
            else
            {
                VoidGroupsList.Add(this.Text, this);
            }
        }
    
    }
}
