using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.ViewModel;
using TrustedActivityCreator.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TrustedActivityCreator.Command;

namespace TrustedActivityCreator.ViewModel {
	class QuickPanelVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		public ICommand AddShapeCommand { get; }

		public QuickPanelVM() {
			AddShapeCommand = new RelayCommand(AddShape);
		}

		private void AddShape() {
			undoRedoController.AddAndExecute(new AddShapeCommand(new ActivityVM()));
		}


	}
}
