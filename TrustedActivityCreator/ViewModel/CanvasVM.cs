using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.GUI;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Media;
using System.Linq;

namespace TrustedActivityCreator.ViewModel {
	class CanvasVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		private bool isAddingLine = false;

		private Shape addingLineFrom;

		private Point initialMousePosition;
		private Point initialShapePosition;

		private ICommand ShapeMouseDownCommand;
		private ICommand ShapeMouseMoveCommand;
		private ICommand ShapeMouseUpCommand;

		public double ModeOpacity => isAddingLine ? 0.4 : 1.0;

		// Collection of shapes / lines
		public ObservableCollection<Shape> Shapes { get; set; }
		public ObservableCollection<Connections> Connections { get; set; }

		// UI Bindable commands
		public ICommand UndoCommand { get; }
		public ICommand RedoCommand { get; }

		public ICommand AddShapeCommand { get; }
		public ICommand RemoveShapeCommand { get; }
		public ICommand AddConnectionCommand { get; }
		public ICommand RemoveConnectionsCommand { get; }

		public CanvasVM() {

			Shapes = new ObservableCollection<Shape>() { new Activity(), new Activity(), new Activity() };

			Connections = new ObservableCollection<Connections>();

			UndoCommand = new RelayCommand(undoRedoController.Undo, undoRedoController.CanUndo);
			RedoCommand = new RelayCommand(undoRedoController.Redo, undoRedoController.CanRedo);

			AddShapeCommand = new RelayCommand(AddShape);
			RemoveShapeCommand = new RelayCommand<IList>(RemoveShape, CanRemoveShape);
			AddConnectionCommand = new RelayCommand(AddConnection);
			RemoveConnectionsCommand = new RelayCommand<IList>(RemoveConnections, CanRemoveConnections);

			ShapeMouseDownCommand = new RelayCommand<MouseButtonEventArgs>(MouseDownShape);
			ShapeMouseMoveCommand = new RelayCommand<MouseButtonEventArgs>(MouseMoveShape);
			ShapeMouseUpCommand = new RelayCommand<MouseButtonEventArgs>(MouseUpShape);
		}

		private Shape TargetShape(MouseEventArgs e) {
			// Here the visual element that the mouse is captured by is retrieved.
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			// From the shapes visual element, the Shape object which is the DataContext is retrieved.
			return (Shape)shapeVisualElement.DataContext;
		}

		private Point RelativeMousePosition(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			var canvas = FindParentOfType<TrustedCanvas>(shapeVisualElement);
			return Mouse.GetPosition(canvas);
		}

		private static T FindParentOfType<T>(DependencyObject o) {
			dynamic parent = VisualTreeHelper.GetParent(o);
			return parent.GetType().IsAssignableFrom(typeof(T)) ? parent : FindParentOfType<T>(parent);
		}

		private void MouseDownShape(MouseButtonEventArgs e) {
			var shape = TargetShape(e);
			var mousePosition = RelativeMousePosition(e);
			initialMousePosition = mousePosition;
			initialShapePosition = new Point(shape.X, shape.Y);
			e.MouseDevice.Target.CaptureMouse();
		}

		private void MouseMoveShape(MouseEventArgs e) {
			if (Mouse.Captured != null) {
				var shape = TargetShape(e);
				var mousePosition = RelativeMousePosition(e);
				shape.X = (int)(initialShapePosition.X + (mousePosition.X - initialMousePosition.X));
				shape.Y = (int)(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y));
			}
		}

		private void MouseUpShape(MouseButtonEventArgs e) {
			var shape = TargetShape(e);

			var mousePosition = RelativeMousePosition(e);

			shape.X = (int)initialShapePosition.X;
			shape.Y = (int)initialShapePosition.Y;

			undoRedoController.AddAndExecute(new MoveShapeCommand(shape, mousePosition.X - initialMousePosition.X, mousePosition.Y - initialMousePosition.Y));

			e.MouseDevice.Target.ReleaseMouseCapture();
		}



		private void AddShape() {
			undoRedoController.AddAndExecute(new AddShapeCommand(Shapes, new Activity()));
		}

		private void RemoveShape(IList shapes) {
			undoRedoController.AddAndExecute(new RemoveShapesCommand(Shapes, Connections, shapes.Cast<Shape>().ToList()));
		}

		private bool CanRemoveShape(IList shapes) => shapes.Count == 1;

		private void AddConnection() {

		}

		private void RemoveConnections(IList connections) {

		}

		private bool CanRemoveConnections(IList connections) => connections.Count == 1;


	}
}
