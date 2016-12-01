using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TrustedActivityCreator.ViewModel;

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

			Condition.MouseDown += Condition_MouseDown;
			Condition.MouseUp += Condition_MouseUp;
			Condition.MouseMove += Condition_MoveMouse;

			// TextBlock Handler
			ConditionDescription.MouseEnter += Condition_MouseEnter;
			ConditionDescription.MouseLeave += Condition_MouseLeave;

			ConditionDescription.MouseDown += Condition_MouseDown;
			ConditionDescription.MouseUp += Condition_MouseUp;
			ConditionDescription.MouseMove += Condition_MoveMouse;


		}

		private void Condition_MouseDown(object sender, MouseEventArgs e) {
			((ShapeBaseViewModel)DataContext).DownShapeCommand.Execute(e);
		}

		private void Condition_MouseUp(object sender, MouseEventArgs e) {
			((ShapeBaseViewModel)DataContext).UpShapeCommand.Execute(e);
		}

		private void Condition_MoveMouse(object sender, MouseEventArgs e) {
			((ShapeBaseViewModel)DataContext).MoveShapeCommand.Execute(e);
		}


		private void Ellipse_MouseEnter(object sender, MouseEventArgs e) {
			Ellipse enteredEllipse = (Ellipse)sender;
			enteredEllipse.Width = 12;
			enteredEllipse.Height = 12;
		}

		private void Ellipse_MouseLeave(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			Ellipse enteredEllipse = (Ellipse)sender;
			enteredEllipse.Width = 8;
			enteredEllipse.Height = 8;
		}

		private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			Ellipse senderEllipse = (Ellipse)sender;

			bool isRed = senderEllipse.Stroke == Brushes.Red;

			foreach (Ellipse ellipsus in ellipses) {
				ellipsus.Stroke = Brushes.Black;
				if (senderEllipse != ellipsus)
					ellipsus.Visibility = Visibility.Hidden; 
			}

			if(!isRed) {
				senderEllipse.Stroke = Brushes.Red;
			}
			
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
	}
}
