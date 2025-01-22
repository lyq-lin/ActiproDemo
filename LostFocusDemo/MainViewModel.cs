using ActiproSoftware.Windows.Input;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LostFocusDemo
{
	internal class MainViewModel
	{
		public MainViewModel()
		{
			this.RootNode = new TreeNode() { Name = "Root" };

			var node1 = new TreeNode() { Name = "Node1", IsExpanded = true };

			node1.AddChildren([new() { Name = "Node2" }, new() { Name = "Node3" }]);

			this.RootNode.AddChildren([node1]);

			this.DelCommand = new DelegateCommand<TreeNode>((parameter) =>
			{
				parameter.Parent?.Children.Remove(parameter);
			});
		}

		public TreeNode RootNode { get; set; }

		public ICommand DelCommand { get; set; }
	}
}
