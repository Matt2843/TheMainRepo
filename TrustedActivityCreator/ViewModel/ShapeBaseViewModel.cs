﻿using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.View;
using System.Windows.Media;
using System;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace TrustedActivityCreator.ViewModel {
	public class ShapeBaseViewModel : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;
		private SelectedShapeController selectedShapeController = SelectedShapeController.Instance;

		private Point initialMousePosition, initialShapePosition;

		private Model.Shape shape;

		private GetTrustedCanvas Instance = GetTrustedCanvas.Instance;

		private Ellipse leftAnchor, rightAnchor, topAnchor, bottomAnchor;

		public Model.Shape Shape { get { return shape; } set { shape = value; RaisePropertyChanged(); } }

		public int Id		{ get { return Shape.Id; }		set { Shape.Id = value; RaisePropertyChanged(); } }
		public int Width	{ get { return Shape.Width; }	set { Shape.Width = value; RaisePropertyChanged(); } }
		public int Height	{ get { return Shape.Height; }	set { Shape.Height = value; RaisePropertyChanged(); } }
		public int X		{ get { return Shape.X; }		set { Shape.X = value; RaisePropertyChanged(); } }
		public int Y		{ get { return Shape.Y; }		set { Shape.Y = value; RaisePropertyChanged(); } }

		public string Description { get { return Shape.Description; } set { Shape.Description = value; RaisePropertyChanged(); } }

		public int XMiddle { get { return Shape.XMiddle; } }
		public int YMiddle { get { return Shape.YMiddle; } }

		public override string ToString() {
			return Id + "," + Width + "," + Height + "," + X + "," + Y + "," + Description;
		}

		public void raise() {
			RaisePropertyChanged();
		}

		public void raise(string s) {
			RaisePropertyChanged(s);
		}

		public ShapeBaseViewModel() {
			leftAnchor = new Ellipse();
			rightAnchor = new Ellipse();
			topAnchor = new Ellipse();
			bottomAnchor = new Ellipse();
		}

		public ShapeBaseViewModel(int Id, int Width, int Height, int X, int Y, string Description) {
			this.Id = Id; this.Width = Width; this.Height = Height; this.X = X; this.Y = Y; this.Description = Description;
		}

		public Point LeftAnchor		{ get { return leftAnchor.TranslatePoint(	new Point(leftAnchor.Width / 2,		leftAnchor.Height / 2),		Instance.Canvas); } }
		public Point RightAnchor	{ get { return rightAnchor.TranslatePoint(	new Point(rightAnchor.Width / 2,	rightAnchor.Height / 2),	Instance.Canvas); } }
		public Point TopAnchor		{ get { return topAnchor.TranslatePoint(	new Point(topAnchor.Width / 2,		topAnchor.Height / 2),		Instance.Canvas); } }
		public Point BottomAnchor	{ get { return bottomAnchor.TranslatePoint(	new Point(bottomAnchor.Width / 2,	bottomAnchor.Height / 2),	Instance.Canvas); } }

		//public ICommand SelectShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(SelectShape); } }
		public ICommand DownShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseDownShape); } }
		public ICommand MoveShapeCommand { get { return new RelayCommand<MouseEventArgs>(MouseMoveShape); } }
		public ICommand UpShapeCommand	 { get { return new RelayCommand<MouseButtonEventArgs>(MouseUpShape); } }

		public void SetAnchors(Ellipse LeftAnchor, Ellipse RightAnchor, Ellipse TopAnchor, Ellipse BottomAnchor) {
			this.leftAnchor = LeftAnchor; this.rightAnchor = RightAnchor; this.topAnchor = TopAnchor; this.bottomAnchor = BottomAnchor;
		}

		private void MouseDownShape(MouseButtonEventArgs e) {
			var shape = Shape;
			var mousePosition = RelativeMousePosition();
			initialMousePosition = mousePosition;
			initialShapePosition = new Point(shape.X, shape.Y);
			e.MouseDevice.Target.CaptureMouse();
			selectedShapeController.SelectedShape = this;
		}

		private void MouseMoveShape(MouseEventArgs e) {
			if (Mouse.Captured != null) {
				var mousePosition = RelativeMousePosition();
				if((bool)((CheckBox)Instance.Canvas.FindName("SnapToGrid")).IsChecked) {
					X = (int)(Math.Round(GetPointInCanvas(initialShapePosition.X + (mousePosition.X - initialMousePosition.X), 0, Instance.Canvas.ActualWidth - Width) / 10.0) * 10);
					Y = (int)(Math.Round(GetPointInCanvas(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y), 0, Instance.Canvas.ActualHeight - Height) / 10.0) * 10);
				} else {
					X = (int)(GetPointInCanvas(initialShapePosition.X + (mousePosition.X - initialMousePosition.X), 0, Instance.Canvas.ActualWidth - Width));
					Y = (int)(GetPointInCanvas(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y), 0, Instance.Canvas.ActualHeight - Height));
				}
			}
			selectedShapeController.SelectedShape = this;
		}

		private void MouseUpShape(MouseButtonEventArgs e) {
			var mousePosition = RelativeMousePosition();

			X = (int)initialShapePosition.X;
			Y = (int)initialShapePosition.Y;

			undoRedoController.AddAndExecute(new MoveShapeCommand(this, GetPointInCanvas(initialShapePosition.X + (mousePosition.X - initialMousePosition.X), 0, Instance.Canvas.ActualWidth - Width) - initialShapePosition.X, GetPointInCanvas(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y), 0, Instance.Canvas.ActualHeight - Height) - initialShapePosition.Y));

			e.MouseDevice.Target.ReleaseMouseCapture();
		}

		private double GetPointInCanvas(double val, double min, double max) {
			if(val < min) {
				return min;
			}
			if(val > max) {
				return max;
			}
			return val;
		}

		private Model.Shape TargetShape(MouseEventArgs e) {
			var shapeVisualElement = (System.Windows.FrameworkElement)e.MouseDevice.Target;
			return (Model.Shape)shapeVisualElement.DataContext;
		}

		private Point RelativeMousePosition() {
			return Mouse.GetPosition(Instance.Canvas);
		}
	}
}
