using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class NotifyPropertyChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		public virtual void OnPropertyChanged(string property)
		{
			var parameter = new PropertyChangedEventArgs(property);

			this.PropertyChanged?.Invoke(this, parameter);
		}

		public virtual bool OnPropertyChanged<TValue>(ref TValue field, TValue value, [CallerMemberName] string property = "")
		{
			if (!Equals(field, value))
			{
				field = value;

				this.OnPropertyChanged(property);

				return true;
			}

			return false;
		}
	}
}
