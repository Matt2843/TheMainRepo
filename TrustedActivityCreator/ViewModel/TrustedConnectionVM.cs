using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	class TrustedConnectionVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		private Connection connection;

		public TrustedConnectionVM() {

			ActivityVM vm1 = new ActivityVM();
			ActivityVM vm2 = new ActivityVM();

			undoRedoController.AddAndExecute(new AddShapeCommand(vm1));

			undoRedoController.AddAndExecute(new AddShapeCommand(vm2));

			connection = new Connection(vm1, vm2);

			undoRedoController.AddAndExecute(new AddConnectionCommand(this));

		}

		public ShapeBaseViewModel From { get { return connection.From; } set { connection.From = value; RaisePropertyChanged(); } }
		public ShapeBaseViewModel To { get { return connection.To; } internal set { connection.To = value; RaisePropertyChanged(); } }

	}
}
