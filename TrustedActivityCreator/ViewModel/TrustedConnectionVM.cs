using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	public class TrustedConnectionVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		private Connection connection;

		public Ellipse FromAnchor { get; set; }
		public Ellipse ToAnchor { get; set; }


		private PointCollection path = new PointCollection();

		public TrustedConnectionVM() {
			connection = new Connection();
		}

		public void raise(object sender, PropertyChangedEventArgs e){
			Console.WriteLine(Path.ToString());
			this.RaisePropertyChanged("Path");
		}

		public ShapeBaseViewModel From { get { return connection.From; } set { connection.From = value; RaisePropertyChanged(); } }
		public ShapeBaseViewModel To { get { return connection.To; } set { connection.To = value; RaisePropertyChanged(); } }

		public PointCollection Path { get { return new PointCollection() { connection.From.BottomAnchor, connection.To.TopAnchor }; } set { path = value; RaisePropertyChanged(); } }


		public void Connect(ShapeBaseViewModel from, ShapeBaseViewModel to) {
			From = from;
			To = to;
			From.PropertyChanged += new PropertyChangedEventHandler(raise);
			To.PropertyChanged += new PropertyChangedEventHandler(raise);
			undoRedoController.AddAndExecute(new AddConnectionCommand(this));
		}
	}
}

