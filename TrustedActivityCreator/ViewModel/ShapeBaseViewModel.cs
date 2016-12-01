﻿using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.View;
using System.Windows.Media;

namespace TrustedActivityCreator.ViewModel {
	class ShapeBaseViewModel : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		private Point initialMousePosition;
		private Point initialShapePosition;

		// --- 
		private Shape shape;

		public int Id { get { return Shape.Id; } }
		public int Width { get { return Shape.Width; } set { Shape.Width = value; RaisePropertyChanged(); } }
		public int Height { get { return Shape.Height; } set { Shape.Height = value; RaisePropertyChanged(); } }
		public int X { get { return Shape.X; } set { Shape.X = value; RaisePropertyChanged(); } }
		public int Y { get { return Shape.Y; } set { Shape.Y = value; RaisePropertyChanged(); } }
		public string Description { get { return Shape.Description; } set { Shape.Description = value; RaisePropertyChanged(); } }

		public ICommand DownShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseDownShape); } }
		public ICommand MoveShapeCommand { get { return new RelayCommand<MouseEventArgs>(MouseMoveShape); } }
		public ICommand UpShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseUpShape); } }

		public Shape Shape {
			get { return shape; }
			set {
				if (value != shape) {
					shape = value;
					RaisePropertyChanged();
				}
			}
		}

		public Point Get() {
			canvas = (FrameworkElement)Application.Current.MainWindow.FindName("TrustedCanvas");

		}

		private void MouseDownShape(MouseButtonEventArgs e) {
			var shape = Shape;
			var mousePosition = RelativeMousePosition(e);
			initialMousePosition = mousePosition;
			initialShapePosition = new Point(shape.X, shape.Y);
			e.MouseDevice.Target.CaptureMouse();
		}

		private void MouseMoveShape(MouseEventArgs e) {
			if (Mouse.Captured != null) {
				var mousePosition = RelativeMousePosition(e);
				X = (int)(initialShapePosition.X + (mousePosition.X - initialMousePosition.X));
				Y = (int)(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y));
			}
		}

		private void MouseUpShape(MouseButtonEventArgs e) {
			var mousePosition = RelativeMousePosition(e);

			X = (int)initialShapePosition.X;
			Y = (int)initialShapePosition.Y;

			undoRedoController.AddAndExecute(new MoveShapeCommand(this, mousePosition.X - initialMousePosition.X, mousePosition.Y - initialMousePosition.Y));

			e.MouseDevice.Target.ReleaseMouseCapture();
		}


		private Shape TargetShape(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			return (Shape)shapeVisualElement.DataContext;
		}

		private Point RelativeMousePosition(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
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
