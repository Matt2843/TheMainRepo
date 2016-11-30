using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrustedActivityCreator.View {
	/// <summary>
	/// Interaction logic for TrustedCondition.xaml
	/// </summary>
	public partial class TrustedCondition : UserControl {
		public TrustedCondition() {
			InitializeComponent();
		}
		private void ActivityDescription_OnKeyDown(object sender, KeyEventArgs e) {
			if(e.Key == Key.Return) {
				ActivityDescription_LostFocus(sender, e);
			}
		}

		private void ActivityDescription_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e) {
			ActivityDescription.Cursor = ActivityDescription.Focusable ? Cursors.IBeam : Cursors.Arrow;
		}

		private void ActivityDescription_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
			ActivityDescription.BorderThickness = new Thickness(1, 1, 1, 1);
			ActivityDescription.IsReadOnly = false;
			ActivityDescription.Focusable = true;
			ActivityDescription.Focus();
			ActivityDescription.CaretIndex = ActivityDescription.Text.Length;
		}

		private void ActivityDescription_LostFocus(object sender, RoutedEventArgs e) {
			Console.WriteLine("Focus Lost");
			Condition.Fill = Brushes.White;
			ActivityDescription.BorderThickness = new Thickness(0, 0, 0, 0);
			ActivityDescription.Focusable = false;
			ActivityDescription.IsReadOnly = true;
		}

		private void Activity_FocusGained(object sender, RoutedEventArgs e) {
			Condition.Fill = Brushes.BlueViolet;

		}
	}
}
