using System;
using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	public class Connections : ObservableObject {

		private Shape from;
		private Shape to;

		public Connections(Shape from, Shape to) {
			From = from;
			To = to;
		}

		public Shape From { get { return from; } set { from = value; RaisePropertyChanged(); } }

		public Shape To { get { return to; } internal set { to = value; RaisePropertyChanged(); } }

	}
}
