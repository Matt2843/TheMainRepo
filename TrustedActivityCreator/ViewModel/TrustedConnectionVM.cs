using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	class TrustedConnectionVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		private Connection connection;

		private PointCollection path;

		public TrustedConnectionVM() {

			ActivityVM vm1 = new ActivityVM();
			ActivityVM vm2 = new ActivityVM();

			undoRedoController.AddAndExecute(new AddShapeCommand(vm1));

			undoRedoController.AddAndExecute(new AddShapeCommand(vm2));

			connection = new Connection(vm1, vm2);

			Path = new PointCollection() { new Point(connection.From.X, connection.From.Y), new Point(connection.To.X, connection.To.Y) };

			//Path += new vm1.PropertyChangedHandler(ListChanged);

			undoRedoController.AddAndExecute(new AddConnectionCommand(this));
			RaisePropertyChanged("Path");
		}

		public ShapeBaseViewModel From { get { return connection.From; } set { connection.From = value; RaisePropertyChanged(); } }
		public ShapeBaseViewModel To { get { return connection.To; } internal set { connection.To = value; RaisePropertyChanged(); } }

		public PointCollection Path { get { return path; } set { path = value; RaisePropertyChanged(); } }
	}
}

