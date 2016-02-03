using PKStudio.ItemWrappers;

namespace PKStudio.TreeNodes
{
    class MFISATreeNode : MFTreeNodeBase
    {
        public MFISATreeNode()
        {
        }
        public ISAWrapper Isa { get; private set; }
        public MFISATreeNode(ISAWrapper isa)
            : base(isa.Name, ImageKeysEnum.ISA)
        {
            this.Isa = isa;
            this.Tag = isa;
        }
    }
}
