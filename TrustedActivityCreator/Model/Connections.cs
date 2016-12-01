using System;
using GalaSoft.MvvmLight;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Model {
	class Connection : ObservableObject {

		private ShapeBaseViewModel from;
		private ShapeBaseViewModel to;

		public Connection(ShapeBaseViewModel from, ShapeBaseViewModel to) {
			From = from;
			To = to;
		}

		public ShapeBaseViewModel From { get { return from; } set { from = value; RaisePropertyChanged(); } }

		public ShapeBaseViewModel To { get { return to; } internal set { to = value; RaisePropertyChanged(); } }

	}
}
