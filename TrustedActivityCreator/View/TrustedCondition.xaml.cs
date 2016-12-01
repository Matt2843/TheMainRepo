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
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			// Ellipse Handlers
			for (int i = 0; i < ellipses.Length; i++) {
				ellipses[i].MouseDown += Ellipse_MouseDown;
				ellipses[i].MouseEnter += Ellipse_MouseEnter;
				ellipses[i].MouseLeave += Ellipse_MouseLeave;
			}

			// Condition Handlers
			Condition.MouseEnter += Condition_MouseEnter;
			Condition.MouseLeave += Condition_MouseLeave;
		}

		private void Ellipse_MouseEnter(object sender, MouseEventArgs e) {
			Ellipse enteredEllipse = (Ellipse)sender;
			enteredEllipse.Width = 12;
			enteredEllipse.Height = 12;
		}

		private void Ellipse_MouseLeave(object sender, MouseEventArgs e) {
			Ellipse enteredEllipse = (Ellipse)sender;
			enteredEllipse.Width = 8;
			enteredEllipse.Height = 8;
		}

		private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			for(int i = 0; i < ellipses.Length; i++) {
				if(ellipses[i].Stroke == Brushes.Red) {
					ellipses[i].Stroke = Brushes.Black;
				}
			}
			((Ellipse)sender).Stroke = Brushes.Red;
		}

		private void Condition_MouseEnter(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			Condition.Stroke = Brushes.Blue;
			for (int i = 0; i < ellipses.Length; i++) {
				ellipses[i].Visibility = Visibility.Visible;
			}
		}

		private void Condition_MouseLeave(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			for (int i = 0; i < ellipses.Length; i++) {
				if(ellipses[i].Stroke != Brushes.Red && !ellipses[i].IsMouseOver) {
					ellipses[i].Visibility = Visibility.Hidden;
					Condition.Stroke = Brushes.Black;
				}
						
			}
		}

		private void Condition_OnKeyDown(object sender, KeyEventArgs e) {
			if(e.Key == Key.Return) {
				ActivityDescription_LostFocus(sender, e);
			}
		}

		private void Condition_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e) {
			ActivityDescription.Cursor = ActivityDescription.Focusable ? Cursors.IBeam : Cursors.Arrow;
		}

		private void Condition_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
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
	}
}
