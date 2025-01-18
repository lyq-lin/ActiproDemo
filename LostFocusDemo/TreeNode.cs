using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostFocusDemo
{
	internal class TreeNode
	{
		public string Id { get; set; } = String.Empty;
		public string Name { get; set; } = String.Empty;
		public bool IsSelected { get; set; }

		public ObservableCollection<TreeNode> Children { get; set; } = [];
	}
}
