using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	public class Connections : ObservableObject {

		private Shape from;
		private Shape to;

		public Shape From { get { return from; } set { from = value; } }

		public Shape To { get { return to; } internal set { to = value; } }

	}
}
