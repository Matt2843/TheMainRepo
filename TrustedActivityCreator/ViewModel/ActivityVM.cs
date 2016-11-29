using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using System.Windows.Controls;
using TrustedActivityCreator.Command;

namespace TrustedActivityCreator.ViewModel {
	class ActivityVM : ObservableObject {

		/// <summary>
		/// The current activity information.
		/// </summary>
		/// 

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		private Activity activity;

		private Point initialMousePosition;
		private Point initialShapePosition;

		/// <summary>
		/// The commands for databinding
		/// </summary>
		private ICommand currentActivityCommand;

		private ICommand activityMouseDownCommand;
		private ICommand activityMouseMoveCommand;
		private ICommand activityMouseUpCommand;

		/// <summary>
		/// The command properties
		/// </summary>

		public ActivityVM() {
			Activity = new Activity();
		}

		public int Id { get { return Activity.Id; } }
		public string ActivityDescription { get { return Activity.ActivityDescription; } set { Activity.ActivityDescription = value; RaisePropertyChanged(); } }
		public int Width { get { return Activity.Width; } set { Activity.Width = value; RaisePropertyChanged(); } }
		public int Height { get { return Activity.Height; } set { Activity.Height = value; RaisePropertyChanged(); } }
		public int X { get { return Activity.X; } set { Activity.X = value; RaisePropertyChanged(); } }
		public int Y { get { return Activity.Y; } set { Activity.Y = value; RaisePropertyChanged(); } }

		public Activity Activity {
			get { return activity; }
			set {
				if(value != activity) {
					activity = value;
					RaisePropertyChanged();
				}
			}
		}

		public ICommand DownShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseDownShape); } }

		public ICommand MoveShapeCommand { get { return new RelayCommand<MouseEventArgs>(MouseMoveShape); } }

		public ICommand UpShapeCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseUpShape); } }

		private void MouseDownShape(MouseButtonEventArgs e) {
			var shape = Activity;
			var mousePosition = RelativeMousePosition(e);
			initialMousePosition = mousePosition;
			initialShapePosition = new Point(shape.X, shape.Y);
			e.MouseDevice.Target.CaptureMouse();
		}

		private void MouseMoveShape(MouseEventArgs e) {
			if(Mouse.Captured != null) {
				var shape = Activity;
				var mousePosition = RelativeMousePosition(e);
				shape.X = (int)(initialShapePosition.X + (mousePosition.X - initialMousePosition.X));
				shape.Y = (int)(initialShapePosition.Y + (mousePosition.Y - initialMousePosition.Y));
				RaisePropertyChanged("X");
			}
		}

		private void MouseUpShape(MouseButtonEventArgs e) {
			var shape = Activity;

			var mousePosition = RelativeMousePosition(e);

			shape.X = (int)initialShapePosition.X;
			shape.Y = (int)initialShapePosition.Y;

			undoRedoController.AddAndExecute(new MoveShapeCommand(shape, mousePosition.X - initialMousePosition.X, mousePosition.Y - initialMousePosition.Y));

			e.MouseDevice.Target.ReleaseMouseCapture();
		}


		private Shape TargetShape(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			return (Shape)shapeVisualElement.DataContext;
		}

		private Point RelativeMousePosition(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			var canvas = FindParentOfType<System.Windows.Controls.Canvas>(shapeVisualElement);
			return Mouse.GetPosition(canvas);
		}

		private static T FindParentOfType<T>(DependencyObject o) {
			dynamic parent = VisualTreeHelper.GetParent(o);
			return parent.GetType().IsAssignableFrom(typeof(T)) ? parent : FindParentOfType<T>(parent);
		}
	}
}
