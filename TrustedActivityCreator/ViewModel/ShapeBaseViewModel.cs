using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.View;
using System.Windows.Media;
using System;
using System.Windows.Shapes;

namespace TrustedActivityCreator.ViewModel {
	class ShapeBaseViewModel : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;
		private SelectedShapeController selectedShapeController = SelectedShapeController.Instance;

		private Point initialMousePosition;
		private Point initialShapePosition;

		// --- 
		private Model.Shape shape;

		private Ellipse leftAnchor, rightAnchor, topAnchor, bottomAnchor;
		private FrameworkElement Canvas;

		public int Id { get { return Shape.Id; } }
		public int Width { get { return Shape.Width; } set { Shape.Width = value; RaisePropertyChanged(); RaisePropertyChanged("XMiddle"); } }
		public int Height { get { return Shape.Height; } set { Shape.Height = value; RaisePropertyChanged(); RaisePropertyChanged("YMiddle"); } }
		public int X { get { return Shape.X; } set { Shape.X = value; RaisePropertyChanged(); RaisePropertyChanged("XMiddle"); } }
		public int Y { get { return Shape.Y; } set { Shape.Y = value; RaisePropertyChanged(); RaisePropertyChanged("YMiddle"); } }
		public string Description { get { return Shape.Description; } set { Shape.Description = value; RaisePropertyChanged(); } }

		public int XMiddle { get { return Shape.XMiddle; } }
		public int YMiddle { get { return Shape.YMiddle; } }


		/*public Point LeftAnchor { get { return leftAnchor.TranslatePoint(new Point(leftAnchor.Width / 2, leftAnchor.Height / 2), Canvas); } }
		public Point RightAnchor { get { return rightAnchor.TranslatePoint(new Point(rightAnchor.Width / 2, rightAnchor.Height / 2), Canvas); } }
		public Point TopAnchor { get { return topAnchor.TranslatePoint(new Point(topAnchor.Width / 2, topAnchor.Height / 2), Canvas); } }
		public Point BottomAnchor { get { return bottomAnchor.TranslatePoint(new Point(bottomAnchor.Width / 2, bottomAnchor.Height / 2), Canvas); } }*/

		public Point LeftAnchor { get { return leftAnchor.TranslatePoint(new Point(leftAnchor.Width / 2, leftAnchor.Height / 2), Canvas); } }
		public Point RightAnchor { get { return rightAnchor.TranslatePoint(new Point(rightAnchor.Width / 2, rightAnchor.Height / 2), Canvas); } }
		public Point TopAnchor { get { return topAnchor.TranslatePoint(new Point(topAnchor.Width / 2, topAnchor.Height / 2), Canvas); } }
		public Point BottomAnchor { get { return bottomAnchor.TranslatePoint(new Point(bottomAnchor.Width / 2, bottomAnchor.Height / 2), Canvas); } }



		//public ICommand SelectShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(SelectShape); } }
		public ICommand DownShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseDownShape); } }
		public ICommand MoveShapeCommand { get { return new RelayCommand<MouseEventArgs>(MouseMoveShape); } }
		public ICommand UpShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseUpShape); } }

		public Model.Shape Shape {
			get { return shape; }
			set {
				if (value != shape) {
					shape = value;
					RaisePropertyChanged();
				}
			}
		}

		public void SetAnchors(Ellipse LeftAnchor, Ellipse RightAnchor, Ellipse TopAnchor, Ellipse BottomAnchor, FrameworkElement Canvas) {
			this.leftAnchor = LeftAnchor; this.rightAnchor = RightAnchor; this.topAnchor = TopAnchor; this.bottomAnchor = BottomAnchor; this.Canvas = Canvas;
			Console.WriteLine(this.Canvas.Name);
		}

		private void MouseDownShape(MouseButtonEventArgs e) {
			var shape = Shape;
			var mousePosition = RelativeMousePosition(e);
			initialMousePosition = mousePosition;
			initialShapePosition = new Point(shape.X, shape.Y);
			e.MouseDevice.Target.CaptureMouse();
			selectedShapeController.SelectedShape = this;
		}

		private void MouseMoveShape(MouseEventArgs e) {
			if (Mouse.Captured != null) {
				var mousePosition = RelativeMousePosition(e);
				X = (int)(initialShapePosition.X + (mousePosition.X - initialMousePosition.X));
				Y = (int)(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y));
			}
			selectedShapeController.SelectedShape = this;
		}

		private void MouseUpShape(MouseButtonEventArgs e) {
			var mousePosition = RelativeMousePosition(e);

			X = (int)initialShapePosition.X;
			Y = (int)initialShapePosition.Y;

			undoRedoController.AddAndExecute(new MoveShapeCommand(this, mousePosition.X - initialMousePosition.X, mousePosition.Y - initialMousePosition.Y));

			e.MouseDevice.Target.ReleaseMouseCapture();
		}


		private Model.Shape TargetShape(MouseEventArgs e) {
			var shapeVisualElement = (System.Windows.FrameworkElement)e.MouseDevice.Target;
			return (Model.Shape)shapeVisualElement.DataContext;
		}

		private Point RelativeMousePosition(MouseEventArgs e) {
			var shapeVisualElement = (System.Windows.FrameworkElement)e.MouseDevice.Target;
			//var canvas = FindParentOfType<System.Windows.Controls.Canvas>(shapeVisualElement);
			var canvas = FindParentOfType<CanvasUC>(shapeVisualElement);
			return Mouse.GetPosition(canvas);
		}

		private static T FindParentOfType<T>(DependencyObject o) {
			dynamic parent = VisualTreeHelper.GetParent(o);
			return parent.GetType().IsAssignableFrom(typeof(T)) ? parent : FindParentOfType<T>(parent);
		}
	}
}
