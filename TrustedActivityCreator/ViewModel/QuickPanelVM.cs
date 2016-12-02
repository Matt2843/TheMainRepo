using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TrustedActivityCreator.Command;
using System.Windows;
using TrustedActivityCreator.Model;
using System;
using System.ComponentModel;

namespace TrustedActivityCreator.ViewModel {
	class QuickPanelVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;
		private SelectedShapeController selectedShapeController = SelectedShapeController.Instance;

		public ICommand AddActivityCommand { get; }
		public ICommand AddConditionCommand { get; }

		public QuickPanelVM() {
			AddActivityCommand = new RelayCommand(AddActivity);
			AddConditionCommand = new RelayCommand(AddCondition);

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
					Console.WriteLine(selectedShapeController.SelectedShape.X.ToString());
					return selectedShapeController.SelectedShape.X.ToString();
				}					
				return "0";
			}
			set {
				int output;
				if(Int32.TryParse(value, out output))
					selectedShapeController.SelectedShape.X = output;
				else selectedShapeController.SelectedShape.X = 0;
			}
		}

		public string Y {
			get {
				if (selectedShapeController.SelectedShape != null) {
					Console.WriteLine(selectedShapeController.SelectedShape.Y.ToString());
					return selectedShapeController.SelectedShape.Y.ToString();
				}
				return "0";
			}
			set {
				int output;
				if (Int32.TryParse(value, out output))
					selectedShapeController.SelectedShape.Y = output;
				else selectedShapeController.SelectedShape.Y = 0;
			}
		}

		public string Description {
			get {
				if(selectedShapeController.SelectedShape != null) {
					
					return selectedShapeController.SelectedShape.Description;
				} else {
					return "-";
				}		
			}
			set {
				selectedShapeController.SelectedShape.Description = value;
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

		private void AddShape(ShapeBaseViewModel vm) {
			canvas = (FrameworkElement)Application.Current.MainWindow.FindName("TrustedCanvas");
			Point point = Mouse.GetPosition(canvas);

			vm.X = (int)point.X;
			vm.Y = (int)point.Y;
			
			undoRedoController.AddAndExecute(new AddShapeCommand(vm));
		}
	}
}
