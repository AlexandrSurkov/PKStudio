using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKStudio.TreeNodes
{
    class MFRootTreeNode : MFTreeNodeBase
    {
        public MFRootTreeNode()
        {
        }
        public MFRootTreeNode(string Name, ImageKeysEnum key)
            : base (Name, key)
        {
        }
    }
}
