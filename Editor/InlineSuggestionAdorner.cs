using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Editor
{
	public class InlineSuggestionAdorner : Adorner
	{
		private readonly TextBlock _suggestionTextBlock;

		public InlineSuggestionAdorner(UIElement adornedElement, string suggestionText)
			: base(adornedElement)
		{
			_suggestionTextBlock = new TextBlock
			{
				Text = suggestionText,
				Foreground = Brushes.Gray,
				FontStyle = FontStyles.Italic,
				Opacity = 0.6,
				IsHitTestVisible = false,
			};
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);

			drawingContext.DrawEllipse(Brushes.Red, new Pen(), new(), 3, 3);
		}

		protected override Size MeasureOverride(Size constraint)
		{
			_suggestionTextBlock.Measure(constraint);

			return _suggestionTextBlock.DesiredSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			// 确保控件已正确布局
			if (AdornedElement == null || AdornedElement.RenderSize.IsEmpty)
			{
				return finalSize;
			}

			var textBox = (TextBox)AdornedElement;

			var caretIndex = textBox.CaretIndex;

			var lineIndex = textBox.GetLineIndexFromCharacterIndex(caretIndex);

			var lineStart = textBox.GetCharacterIndexFromLineIndex(lineIndex);

			var lineText = textBox.Text.Substring(lineStart, caretIndex - lineStart);

			// 计算行内偏移
			var formattedText = new FormattedText(
				lineText,
				System.Globalization.CultureInfo.CurrentCulture,
				FlowDirection.LeftToRight,
				new Typeface(textBox.FontFamily, textBox.FontStyle, textBox.FontWeight, textBox.FontStretch),
				textBox.FontSize,
				Brushes.Black,
				VisualTreeHelper.GetDpi(this).PixelsPerDip
			);

			// 定位到光标右侧
			var location = new Point(formattedText.Width, lineIndex * textBox.FontSize);
			_suggestionTextBlock.Arrange(new Rect(location, finalSize));
			return finalSize;
		}

		// 添加强制刷新逻辑
		public void Refresh()
		{
			InvalidateMeasure();

			InvalidateArrange();

			InvalidateVisual();
		}

		protected override Visual GetVisualChild(int index) => _suggestionTextBlock;

		protected override int VisualChildrenCount => 1;
	}
}