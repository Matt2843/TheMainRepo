using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using TrustedActivityCreator.Model;
using System.Windows.Controls;

namespace TrustedActivityCreator.ViewModel {
	class ActivityVM : ObservableObject {

		/// <summary>
		/// The current activity information.
		/// </summary>
		private int activityId;
		private ActivityM currentActivity;

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
		public ICommand CurrentActivityCommand {
			get {
				if(currentActivityCommand == null) {
					currentActivityCommand = new RelayCommand(getCurrentActivity);
				}
				return currentActivityCommand;
			}
		}

		public ActivityM CurrentActivity {
			get { return currentActivity; }
			set {
				if(value != currentActivity) {
					currentActivity = value;
					RaisePropertyChanged();
				}
			}
		}

		private void getCurrentActivity() {
			// TODO - GET ACTIVITY WITH CURRENT ID FROM ACTIVITY MAP
			ActivityM stupidActivity = new ActivityM();
			stupidActivity.ActivityDescription = "Hello i'm a random activity";
			CurrentActivity = stupidActivity;
		}

		public ICommand DownCurrentActivityCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseDownShape); } }

		public ICommand MoveCurrentActivityCommand { get { return new RelayCommand<MouseEventArgs>(MouseMoveShape); } }

		public ICommand UpCurrentActivityCommand { get { return new RelayCommand<MouseButtonEventArgs>(MouseUpShape); } }

		private void MouseDownShape(MouseButtonEventArgs e) {
			var shape = TargetShape(e);
			var mousePosition = RelativeMousePosition(e);
			initialMousePosition = mousePosition;
			initialShapePosition = new Point(shape.X, shape.Y);
			e.MouseDevice.Target.CaptureMouse();
		}

		private void MouseMoveShape(MouseEventArgs e) {
			if(Mouse.Captured != null) {
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

			//undoRedoController.AddAndExecute(new MoveShapeCommand(shape, mousePosition.X - initialMousePosition.X, mousePosition.Y - initialMousePosition.Y));

			e.MouseDevice.Target.ReleaseMouseCapture();
		}


		private ActivityM TargetShape(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			return (ActivityM)shapeVisualElement.DataContext;
		}

		private Point RelativeMousePosition(MouseEventArgs e) {
			var shapeVisualElement = (FrameworkElement)e.MouseDevice.Target;
			var canvas = FindParentOfType<Canvas>(shapeVisualElement);
			return Mouse.GetPosition(canvas);
		}

		private static T FindParentOfType<T>(DependencyObject o) {
			dynamic parent = VisualTreeHelper.GetParent(o);
			return parent.GetType().IsAssignableFrom(typeof(T)) ? parent : FindParentOfType<T>(parent);
		}
	}
}
