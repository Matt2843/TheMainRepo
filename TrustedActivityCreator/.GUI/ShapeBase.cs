using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Data;
using TrustedActivityCreator.ViewModel;
using TrustedActivityCreator.Command;
using System.ComponentModel;
using System;

namespace TrustedActivityCreator.GUI {
	/// <summary>
	/// Interaction logic for ShapeBaseUC.xaml
	/// </summary>
	public partial class ShapeBase : UserControl {

		private ConnectionController Connecter = ConnectionController.Connecter;

		public Ellipse LeftAnchor = new Ellipse(), RightAnchor = new Ellipse(), TopAnchor = new Ellipse(), BottomAnchor = new Ellipse();
		public Rectangle ShapeGeometry;
		public TextBlock Description;
		public Grid rootGrid;

		public ShapeBase() {

			Connecter.PropertyChanged += Ellipse_Reset;

			Binding XBind = new Binding("X");
			Binding YBind = new Binding("Y");
			Binding WidthBind = new Binding("Width");
			Binding HeightBind = new Binding("Height");

			XBind.Mode = BindingMode.TwoWay;
			YBind.Mode = BindingMode.TwoWay;
			WidthBind.Mode = BindingMode.TwoWay;
			HeightBind.Mode = BindingMode.TwoWay;

			SetBinding(Canvas.LeftProperty, XBind);
			SetBinding(Canvas.TopProperty, YBind);
			SetBinding(WidthProperty, WidthBind);
			SetBinding(HeightProperty, HeightBind);

			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			string[] names = { "LeftAnchor", "RightAnchor", "TopAnchor", "BottomAnchor" };

			for (int i = 0; i < ellipses.Length; i++) {
				ellipses[i].MouseDown += Ellipse_MouseDown;
				ellipses[i].MouseEnter += Ellipse_MouseEnter;
				ellipses[i].MouseLeave += Ellipse_MouseLeave;
				ellipses[i].Width = 8;
				ellipses[i].Height = 8;
				ellipses[i].Visibility = Visibility.Hidden;
				ellipses[i].Fill = Brushes.White;
				ellipses[i].Stroke = Brushes.Black;
				ellipses[i].StrokeThickness = 1;
				ellipses[i].Name = names[i];
				Panel.SetZIndex(ellipses[i], 3000);
			}
			rootGrid = new Grid();
			ShapeGeometry = new Rectangle();
			Description = new TextBlock();

			Content = rootGrid;

			Description.VerticalAlignment = VerticalAlignment.Center;
			Description.HorizontalAlignment = HorizontalAlignment.Center;
			Description.TextWrapping = TextWrapping.Wrap;			

			Binding descriptionBinding = new Binding("Description");
			descriptionBinding.Mode = BindingMode.TwoWay;
			BindingOperations.SetBinding(Description, TextBlock.TextProperty, descriptionBinding);

			ShapeGeometry.Stroke = Brushes.Black;
			ShapeGeometry.StrokeThickness = 1;
			ShapeGeometry.Fill = Brushes.White;
			Panel.SetZIndex(ShapeGeometry, 1000);

			// Condition Handlers
			ShapeGeometry.MouseEnter += Shape_MouseEnter;
			ShapeGeometry.MouseLeave += Shape_MouseLeave;

			ShapeGeometry.MouseDown += Shape_MouseDown;
			ShapeGeometry.MouseUp += Shape_MouseUp;
			ShapeGeometry.MouseMove += Shape_MouseMove;

			// TextBlock Handler
			Description.MouseEnter += Shape_MouseEnter;
			Description.MouseLeave += Shape_MouseLeave;

			Description.MouseDown += Shape_MouseDown; ;
			Description.MouseUp += Shape_MouseUp;
			Description.MouseMove += Shape_MouseMove;			
		}

		public void tryHandles(Ellipse s) {
			s.MouseEnter += Shape_MouseEnter;
			s.MouseLeave += Shape_MouseLeave;
			s.MouseDown += Shape_MouseDown;
			s.MouseUp += Shape_MouseUp;
			s.MouseMove += Shape_MouseMove;
		}

		protected override void OnRender(DrawingContext drawingContext) {
			base.OnRender(drawingContext);
			((ShapeBaseViewModel)DataContext).SetAnchors(LeftAnchor, RightAnchor, TopAnchor, BottomAnchor);
		}

		private Brush enteredBrush;

		private void Shape_MouseEnter(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			enteredBrush = ShapeGeometry.Stroke;
			ShapeGeometry.Stroke = ShapeGeometry.Stroke == Brushes.Purple ? Brushes.Purple : Brushes.Blue;
			for (int i = 0; i < ellipses.Length; i++) {
				ellipses[i].Visibility = Visibility.Visible;
			}
		}

		private void Shape_MouseLeave(object sender, MouseEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			for (int i = 0; i < ellipses.Length; i++) {
				if (ellipses[i].Stroke != Brushes.Red && !ellipses[i].IsMouseOver) {
					ellipses[i].Visibility = Visibility.Hidden;
					ShapeGeometry.Stroke = enteredBrush;
				}
			}
		}

		private void Shape_MouseDown(object sender, MouseEventArgs e) {
			ShapeGeometry.Stroke = ShapeGeometry.Stroke == Brushes.Blue ? Brushes.Purple : Brushes.Black;
			enteredBrush = ShapeGeometry.Stroke;
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
			if(enteredEllipse.Stroke != Brushes.Red) {
				enteredEllipse.Visibility = Visibility.Hidden;
			}
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
				if(Connecter.From != null) {
					Connecter.ToAnchor = senderEllipse.Name;
				} else {
					Connecter.FromAnchor = senderEllipse.Name;
				}
				Connecter.From = (ShapeBaseViewModel)DataContext;
			} else {
				Connecter.From = null;
			}

		}

		private void Ellipse_Reset(object sender, PropertyChangedEventArgs e) {
			Ellipse[] ellipses = { LeftAnchor, RightAnchor, TopAnchor, BottomAnchor };
			foreach(Ellipse ellipsus in ellipses) {
				ellipsus.Stroke = Brushes.Black;
				ellipsus.Width = 8;
				ellipsus.Height = 8;
				ellipsus.Visibility = Visibility.Hidden;
			}
		}
	}
}
