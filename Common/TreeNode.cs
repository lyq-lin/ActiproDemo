using ActiproSoftware.Windows.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class TreeNode : NotifyPropertyChanged
	{
		private string _id = DateTime.UtcNow.Ticks.ToString("x");
		private string _name = String.Empty;

		private bool _isSelectable;
		private bool _isExpanded;
		private bool _isSelected;
		private bool _hasChildren;

		public bool HasChildren
		{
			get { return _hasChildren; }
			set { this.OnPropertyChanged(ref _hasChildren, value); }
		}

		public bool IsSelected
		{
			get { return _isSelected; }
			set { this.OnPropertyChanged(ref _isSelected, value); }
		}

		public bool IsExpanded
		{
			get { return _isExpanded; }
			set { this.OnPropertyChanged(ref _isExpanded, value); }
		}

		public bool IsSelectable
		{
			get { return _isSelectable; }
			set { this.OnPropertyChanged(ref _isSelectable, value); }
		}

		public string Name
		{
			get { return _name; }
			set { this.OnPropertyChanged(ref _name, value); }
		}

		public string Id
		{
			get { return _id; }
			set { this.OnPropertyChanged(ref _id, value); }
		}

		public ObservableCollection<TreeNode> Children { get; set; } = [];

		public void AddChildren(TreeNode[] nodes)
		{
			this.Children.AddRange(nodes);
		}
	}
}
