using ActiproSoftware.Windows.Controls.Grids;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostFocusDemo
{
	internal class TreeNodeItemAdapter : TreeListBoxItemAdapter
	{
		public override IEnumerable GetChildren(TreeListBox ownerControl, object item)
		{
			return item is TreeNode node ? node.Children : base.GetChildren(ownerControl, item);
		}
	}
}
