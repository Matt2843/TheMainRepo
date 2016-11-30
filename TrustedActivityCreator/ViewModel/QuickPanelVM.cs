using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TrustedActivityCreator.Command;
using System.Windows;
using System.Xml.Linq;

namespace TrustedActivityCreator.ViewModel {
	class QuickPanelVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		public ICommand AddShapeCommand { get; }

		private int pos = 0;

		public QuickPanelVM() {
			AddShapeCommand = new RelayCommand(AddShape);
		}

		private void AddShape() {
			//Point point = XElement.TransformToVisual(root).Transform(new Point(50, 50));

			ActivityVM shape = new ActivityVM();
			shape.X = pos;//(int)point.X;
			shape.Y = pos;//(int)point.Y;
			pos += 75;

			undoRedoController.AddAndExecute(new AddShapeCommand(shape));
		}
	}
}
