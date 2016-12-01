using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class ConnectionController {

		private ShapeBaseViewModel from;

		public static ConnectionController Connecter { get; } = new ConnectionController();

		public ShapeBaseViewModel From {
			get { return from; }
			set {
				if(from != null && value != null) {
					Console.WriteLine("something");
					TrustedConnectionVM connection = new TrustedConnectionVM();
					connection.Connect(from, value);
					from = null;
				} else {
					Console.WriteLine("null");
					from = value;
				};
			}
		}
	}
}
