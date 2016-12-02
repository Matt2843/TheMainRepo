using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class ConnectionController : ObservableObject {

		private ShapeBaseViewModel from;

		public String FromAnchor { get; set; }
		public String ToAnchor { get; set; }

		public static ConnectionController Connecter { get; } = new ConnectionController();

		public bool Inprogress { get { return From != null; } }

		public ShapeBaseViewModel From {
			get { return from; }
			set {
				if(from != null && value != null) {
					Console.WriteLine("something");
					TrustedConnectionVM connection = new TrustedConnectionVM();
					connection.FromAnchor = FromAnchor;
					connection.ToAnchor = ToAnchor;
					connection.Connect(from, value);
					from = null;
					RaisePropertyChanged("Inprogress");
				} else {
					Console.WriteLine("null");
					from = value;
				}; 
			}
		}
	}
}
