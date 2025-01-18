using ActiproSoftware.Windows.Input;
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

			this.RootNode.Children.Add(new TreeNode()
			{
				Name = "Node1"
			});

			this.RootNode.Children.Add(new TreeNode()
			{
				Name = "Node2"
			});

			this.DelCommand = new DelegateCommand<TreeNode>((parameter) =>
			{
				this.RootNode.Children.Remove(parameter);
			});
		}

		public TreeNode RootNode { get; set; }

		public ICommand DelCommand { get; set; }
	}
}
