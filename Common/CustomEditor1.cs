using ActiproSoftware.Windows.Controls.SyntaxEditor;
using System.Windows;

namespace Common
{
	public class CustomEditor1 : SyntaxEditor
	{
		static CustomEditor1()
		{
			DefaultStyleKeyProperty
				.OverrideMetadata(typeof(CustomEditor1), new FrameworkPropertyMetadata(typeof(CustomEditor1)));
		}
	}
}
