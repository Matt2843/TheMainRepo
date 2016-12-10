using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TrustedActivityCreator.Command;
using System.Windows;
using TrustedActivityCreator.Model;
using System;
using System.ComponentModel;

namespace TrustedActivityCreator.ViewModel {
	public class QuickPanelVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;
		private SelectedShapeController selectedShapeController = SelectedShapeController.Instance;

		private GetTrustedCanvas Instance = GetTrustedCanvas.Instance;

		public ICommand AddActivityCommand { get; }
		public ICommand AddConditionCommand { get; }
		public ICommand AddEndPointCommand { get; }
		public ICommand AddForkCommand { get; }
		public ICommand AddJoinCommand { get; }
		public ICommand AddStartPointCommand { get; }

		public QuickPanelVM() {
			AddActivityCommand = new RelayCommand(AddActivity);
			AddConditionCommand = new RelayCommand(AddCondition);
			AddEndPointCommand = new RelayCommand(AddEndPoint);
			AddForkCommand = new RelayCommand(AddFork);
			AddJoinCommand = new RelayCommand(AddJoin);
			AddStartPointCommand = new RelayCommand(AddStart);

			selectedShapeController.PropertyChanged += SelectedShapePropertyChanged;
		}

		private void SelectedShapePropertyChanged(object sender, PropertyChangedEventArgs e) {
			RaisePropertyChanged("Description");
			RaisePropertyChanged("X");
			RaisePropertyChanged("Y");
		}

		public string X {
			get {
				if (selectedShapeController.SelectedShape != null) {
					return selectedShapeController.SelectedShape.X.ToString();
				}					
				return "0";
			}
			set {
				if(selectedShapeController.SelectedShape != null) {
					int output;
					if(Int32.TryParse(value, out output))
						selectedShapeController.SelectedShape.X = output;
					else selectedShapeController.SelectedShape.X = 0;
				}
			}
		}

		public string Y {
			get {
				if (selectedShapeController.SelectedShape != null) {
					return selectedShapeController.SelectedShape.Y.ToString();
				}
				return "0";
			}
			set {
				if(selectedShapeController.SelectedShape != null) {
					int output;
					if(Int32.TryParse(value, out output))
						selectedShapeController.SelectedShape.Y = output;
					else selectedShapeController.SelectedShape.Y = 0;
				}
			}
		}

		public string Description {
			get {
				if(selectedShapeController.SelectedShape != null) {
					return selectedShapeController.SelectedShape.Description;
				}
				return "-";	
			}
			set {
				if(selectedShapeController.SelectedShape != null) {
					selectedShapeController.SelectedShape.Description = value;
				}
			}
		}

		private FrameworkElement canvas;

		private void AddActivity() {
			ActivityVM activity = new ActivityVM();
			AddShape(activity);
		}

		private void AddCondition() {
			TrustedConditionVM condition = new TrustedConditionVM();
			AddShape(condition);
		}

		private void AddEndPoint() {
			EndingPointVM ending = new EndingPointVM();
			AddShape(ending);
		}

		private void AddFork() {
			ForkVM fork = new ForkVM();
			AddShape(fork);
		}

		private void AddJoin() {
			JoinVM join = new JoinVM();
			AddShape(join);
		}

		private void AddStart() {
			StartPointVM start = new StartPointVM();
			AddShape(start);
		}

		private void AddShape(ShapeBaseViewModel vm) {
			canvas = (FrameworkElement)Application.Current.MainWindow.FindName("TrustedCanvas");
			Point point = Mouse.GetPosition(canvas);

			vm.X = (int)Instance.Canvas.ActualWidth/2; //(int)point.X;
			vm.Y = (int)Instance.Canvas.ActualHeight / 2; //(int)point.Y;
			
			undoRedoController.AddAndExecute(new AddShapeCommand(vm));
		}
	}
}
