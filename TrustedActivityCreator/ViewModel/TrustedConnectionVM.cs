using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		private PointCollection path = new PointCollection();

		public TrustedConnectionVM() {
			connection = new Connection();
		}

		public void raise(object sender, PropertyChangedEventArgs e){
			Console.WriteLine(Path.ToString());
			this.RaisePropertyChanged("Path");
		}

		public ShapeBaseViewModel From { get { return connection.From; } set { connection.From = value; RaisePropertyChanged(); } }
		public ShapeBaseViewModel To { get { return connection.To; } internal set { connection.To = value; RaisePropertyChanged(); } }

		public PointCollection Path { get { return path; } set { path = value; RaisePropertyChanged(); } }
		//return new PointCollection() { new Point(connection.From.X, connection.From.Y), new Point(connection.To.X, connection.To.Y) }

		public void Connect(ShapeBaseViewModel from, ShapeBaseViewModel to) {
			From = from;
			To = to;
			From.PropertyChanged += new PropertyChangedEventHandler(raise);
			To.PropertyChanged += new PropertyChangedEventHandler(raise);
			undoRedoController.AddAndExecute(new AddConnectionCommand(this));
		}


	}
}

