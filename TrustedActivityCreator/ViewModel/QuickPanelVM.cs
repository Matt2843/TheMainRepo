using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TrustedActivityCreator.Command;
using System.Windows;
using TrustedActivityCreator.Model;
using System;

namespace TrustedActivityCreator.ViewModel {
	class QuickPanelVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		public ICommand AddActivityCommand { get; }
		public ICommand AddConditionCommand { get; }

		public string Description {
			get {
				if(TrustedCollection.SelectedShape != null) {
					Console.WriteLine("Success");
					return TrustedCollection.SelectedShape.Description;
				} else {
					Console.WriteLine("Fail");
					return "aa";
				}		
			}
		}

		private FrameworkElement canvas;

		public QuickPanelVM() {
			AddActivityCommand = new RelayCommand(AddActivity);
			AddConditionCommand = new RelayCommand(AddCondition);
		}

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
