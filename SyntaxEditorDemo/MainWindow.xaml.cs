using System.Windows;

namespace SyntaxEditorDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			t1.Text = """
				using System.Windows;
				using System.Windows.Controls;
				using System.Windows.Documents;
				using System.Windows.Input;
				using System.Windows.Threading;

				namespace Editor
				{
					internal class InlineSuggestionTextBox : TextBox
					{
						// 定义依赖属性：行内建议文本
						public static readonly DependencyProperty InlineSuggestionTextProperty =
							DependencyProperty.Register(
								"InlineSuggestionText",
								typeof(string),
								typeof(InlineSuggestionTextBox),
								new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender, OnInlineSuggestionTextChanged));

						private AdornerLayer? _adornerLayer;
						private InlineSuggestionAdorner? _adorner;

						public string InlineSuggestionText
						{
							get => (string)GetValue(InlineSuggestionTextProperty);
							set => SetValue(InlineSuggestionTextProperty, value);
						}

						public InlineSuggestionTextBox()
						{
							Loaded += OnLoaded;
							TextChanged += OnTextChanged;
							PreviewKeyDown += OnPreviewKeyDown;
						}

						private void OnLoaded(object sender, RoutedEventArgs e)
						{
							_adornerLayer = AdornerLayer.GetAdornerLayer(this);
						}

						private void OnTextChanged(object sender, TextChangedEventArgs e)
						{
							UpdateAdorner();
						}

						private void OnPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
						{
							if (e.Key == Key.Tab && !string.IsNullOrEmpty(InlineSuggestionText))
							{
								// 补全建议文本
								Text += InlineSuggestionText;

								CaretIndex = Text.Length;

								//InlineSuggestionText = string.Empty;

								e.Handled = true;
							}

							if (e.Key is Key.Left or Key.Right or Key.Up or Key.Down)
							{
								this.UpdateAdorner();
							}
						}

						private void UpdateAdorner()
						{
							if (_adornerLayer == null) return;

							// 确保在 UI 线程操作
							this.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
							{
								// 移除旧 Adorner
								if (_adorner != null)
								{
									_adornerLayer.Remove(_adorner);

									_adorner = null;
								}

								// 仅在有建议文本时添加
								if (!string.IsNullOrEmpty(InlineSuggestionText))
								{
									_adorner = new InlineSuggestionAdorner(this, InlineSuggestionText);

									_adornerLayer.Add(_adorner);

									// 强制触发布局和渲染
									_adorner.Refresh();

									_adornerLayer.Update();
								}
							}));
						}

						private static void OnInlineSuggestionTextChanged(
							DependencyObject d, DependencyPropertyChangedEventArgs e)
						{
							var textBox = (InlineSuggestionTextBox)d;

							textBox.UpdateAdorner();
						}
					}
				}
				""";

			//t2.Text = """

			//	using System.Windows;
			//	using System.Windows.Controls;
			//	using System.Windows.Documents;
			//	using System.Windows.Input;
			//	using System.Windows.Threading;

			//	namespace Editor
			//	{
			//		internal class InlineSuggestionTextBox : TextBox
			//		{
			//			// 定义依赖属性：行内建议文本
			//			public static readonly DependencyProperty InlineSuggestionTextProperty =
			//				DependencyProperty.Register(
			//					"InlineSuggestionText",
			//					typeof(string),
			//					typeof(InlineSuggestionTextBox),
			//					new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender, OnInlineSuggestionTextChanged));

			//			private AdornerLayer? _adornerLayer;
			//			private InlineSuggestionAdorner? _adorner;

			//			public string InlineSuggestionText
			//			{
			//				get => (string)GetValue(InlineSuggestionTextProperty);
			//				set => SetValue(InlineSuggestionTextProperty, value);
			//			}

			//			public InlineSuggestionTextBox()
			//			{
			//				Loaded += OnLoaded;
			//				TextChanged += OnTextChanged;
			//				PreviewKeyDown += OnPreviewKeyDown;
			//			}

			//			private void OnLoaded(object sender, RoutedEventArgs e)
			//			{
			//				_adornerLayer = AdornerLayer.GetAdornerLayer(this);
			//			}

			//			private void OnTextChanged(object sender, TextChangedEventArgs e)
			//			{
			//				UpdateAdorner();
			//			}

			//			private void OnPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
			//			{
			//				if (e.Key == Key.Tab && !string.IsNullOrEmpty(InlineSuggestionText))
			//				{
			//					// 补全建议文本
			//					Text += InlineSuggestionText;

			//					CaretIndex = Text.Length;

			//					//InlineSuggestionText = string.Empty;

			//					e.Handled = true;
			//				}

			//				if (e.Key is Key.Left or Key.Right or Key.Up or Key.Down)
			//				{
			//					this.UpdateAdorner();
			//				}
			//			}

			//			private void UpdateAdorner()
			//			{
			//				if (_adornerLayer == null) return;

			//				// 确保在 UI 线程操作
			//				this.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
			//				{
			//					// 移除旧 Adorner
			//					if (_adorner != null)
			//					{
			//						_adornerLayer.Remove(_adorner);

			//						_adorner = null;
			//					}

			//					// 仅在有建议文本时添加
			//					if (!string.IsNullOrEmpty(InlineSuggestionText))
			//					{
			//						_adorner = new InlineSuggestionAdorner(this, InlineSuggestionText);

			//						_adornerLayer.Add(_adorner);

			//						// 强制触发布局和渲染
			//						_adorner.Refresh();

			//						_adornerLayer.Update();
			//					}
			//				}));
			//			}

			//			private static void OnInlineSuggestionTextChanged(
			//				DependencyObject d, DependencyPropertyChangedEventArgs e)
			//			{
			//				var textBox = (InlineSuggestionTextBox)d;

			//				textBox.UpdateAdorner();
			//			}
			//		}
			//	}
			//	""";
		}
	}
}