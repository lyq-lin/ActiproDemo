using ActiproSoftware.Windows.Controls.Grids;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class TreeNodeItemAdapter : TreeListBoxItemAdapter
	{
		public TreeNodeItemAdapter()
		{
			this.IsExpandedPath = "IsExpanded";
			this.IsSelectablePath = "IsSelectable";
			this.IsSelectedPath = "IsSelected";
		}

		public override IEnumerable GetChildren(TreeListBox ownerControl, object item)
		{
			return item is TreeNode node ? node.Children : base.GetChildren(ownerControl, item);
		}

		public override bool GetIsSelected(TreeListBox ownerControl, object item)
		{
			return item is TreeNode { IsSelected: true };
		}

		public override bool GetIsSelectable(TreeListBox ownerControl, object item)
		{
			return item is TreeNode { IsSelectable: true };
		}

		public override bool GetIsExpanded(TreeListBox ownerControl, object item)
		{
			return item is TreeNode { IsExpanded: true };
		}

		public override void SetIsSelected(TreeListBox ownerControl, object item, bool value)
		{
			if (item is TreeNode node)
			{
				node.IsSelected = value;
			}
		}

		public override void SetIsExpanded(TreeListBox ownerControl, object item, bool value)
		{
			if (item is TreeNode node)
			{
				node.IsExpanded = value;
			}
		}

		public override bool CanHaveChildren(TreeListBox ownerControl, object item)
		{
			if (item is TreeNode node)
			{
				return node.HasChildren || node.Children.Count > 0;
			}

			return base.CanHaveChildren(ownerControl, item);
		}

		public override TreeItemChildrenQueryMode GetChildrenQueryMode(TreeListBox ownerControl, object item)
		{
			return TreeItemChildrenQueryMode.OnExpansion;
		}

		public override TreeItemExpandability GetExpandability(TreeListBox ownerControl, object item, int depth)
		{
			return TreeItemExpandability.Auto;
		}
	}
}
