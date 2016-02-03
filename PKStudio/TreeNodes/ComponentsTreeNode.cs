using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKStudio.TreeNodes
{
    class MFComponentsTreeNode : MFTreeNodeBase
    {
        public MFComponentsTreeNode()
        {
        }
        public MFComponentsTreeNode(string Name)
            : base(Name, ImageKeysEnum.Components)
        {
        }
    }
}
