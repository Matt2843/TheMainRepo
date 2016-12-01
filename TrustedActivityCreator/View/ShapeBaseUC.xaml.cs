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
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.View {
	/// <summary>
	/// Interaction logic for ShapeBaseUC.xaml
	/// </summary>
	public partial class ShapeBaseUC : UserControl {

		public Ellipse LeftAnchor, RightAnchor, TopAnchor, BottomAnchor;
		public Rectangle Shape;
		public TextBlock Description;

		public ShapeBaseUC() {
			InitializeComponent();
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			for (int i = 0; i < ellipses.Length; i++) {
				ellipses[i] = new Ellipse();
				ellipses[i].MouseDown += Ellipse_MouseDown;
				ellipses[i].MouseEnter += Ellipse_MouseEnter;
				ellipses[i].MouseLeave += Ellipse_MouseLeave;
				ellipses[i].Width = 8;
				ellipses[i].Height = 8;
				ellipses[i].Visibility = Visibility.Hidden;
				ellipses[i].Fill = Brushes.NavajoWhite;
				ellipses[i].Stroke = Brushes.Black;
				ellipses[i].StrokeThickness = 1;
				Panel.SetZIndex(ellipses[i], 3000);
			}

			// Condition Handlers
			Shape.MouseEnter += Shape_MouseEnter;
			Shape.MouseLeave += Shape_MouseLeave;

			Shape.MouseDown += Shape_MouseDown;
			Shape.MouseUp += Shape_MouseUp;
			Shape.MouseMove += Shape_MouseMove;

			// TextBlock Handler
			Description.MouseEnter += Shape_MouseEnter;
			Description.MouseLeave += Shape_MouseLeave;

			Description.MouseDown += Shape_MouseDown; ;
			Description.MouseUp += Shape_MouseUp;
			Description.MouseMove += Shape_MouseMove;
		}

		private void Shape_MouseEnter(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			Shape.Stroke = Brushes.Blue;
			for (int i = 0; i < ellipses.Length; i++) {
				ellipses[i].Visibility = Visibility.Visible;
			}
		}

		private void Shape_MouseLeave(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			for (int i = 0; i < ellipses.Length; i++) {
				if (ellipses[i].Stroke != Brushes.Red && !ellipses[i].IsMouseOver) {
					ellipses[i].Visibility = Visibility.Hidden;
					Shape.Stroke = Brushes.Black;
				}

			}
		}

		private void Shape_MouseDown(object sender, MouseEventArgs e) {
			((ShapeBaseViewModel)DataContext).DownShapeCommand.Execute(e);
		}

		private void Shape_MouseUp(object sender, MouseEventArgs e) {
			((ShapeBaseViewModel)DataContext).UpShapeCommand.Execute(e);
		}

		private void Shape_MouseMove(object sender, MouseEventArgs e) {
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

			if (!isRed) {
				senderEllipse.Stroke = Brushes.Red;
			}

		}
	}
}
