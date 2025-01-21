using ActiproSoftware.Windows.Input;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InvalidSelected
{
	internal class MainViewModel : NotifyPropertyChanged
	{
		public MainViewModel()
		{
			this.RootNode = new TreeNode();

			this.LoadCommand = new DelegateCommand<object>(parameter =>
			{
				/*
				 * Dynamic Load */

				var dynamicNode = new TreeNode()
				{
					Name = "Dynamic Load",
					IsExpanded = true,
				};

				dynamicNode.AddChildren([new()
				{
					Name = "Node3",
					IsSelectable = true,
					IsSelected = true,
				},
				new()
				{
					Name = "Node4",
					IsSelectable = true,
				}
				]);

				this.RootNode.AddChildren([dynamicNode]);
			});

			/*
			 * Static Load */

			var staticNode = new TreeNode()
			{
				Name = "Static Load",
				IsExpanded = true,
			};

			staticNode.AddChildren([new()
			{
				Name = "Node1",
				IsSelectable = true,
				IsSelected = true,
			},
			new()
			{
				Name = "Node2",
				IsSelectable = true,
			}
			]);

			this.RootNode.AddChildren([staticNode]);
		}

		public TreeNode RootNode { get; set; }

		public ICommand LoadCommand { get; set; }
	}
}
