using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class AddConnectionCommand : IUndoRedoCommand {

		private ObservableCollection<TrustedConnectionVM> Connections { get; } = TrustedCollection.Connections;
		private TrustedConnectionVM connection;

		public AddConnectionCommand(TrustedConnectionVM connection) {
			this.connection = connection;
		}

		public void Execute() {
			Connections.Add(connection);
		}

		public void UnExecute() {
			Connections.Remove(connection);
		}
	}
}