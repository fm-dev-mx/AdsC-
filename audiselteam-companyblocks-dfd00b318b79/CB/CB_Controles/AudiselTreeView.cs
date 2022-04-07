using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.CB_Controles
{
    class AudiselTreeView : TreeView
    {
        public AudiselTreeView()
        {
            this.AfterCollapse += AudiselTreeView_AfterCollapse;
        }

        void AudiselTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
        }
    }
}
