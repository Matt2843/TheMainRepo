using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
	class RemoveShapesCommand : IUndoRedoCommand {

		private ObservableCollection<Shape> shapes;

		private List<Shape> shapesToRemove;

		private List<Connections> connectionsToRemove;

		public RemoveShapesCommand(ObservableCollection<Shape> shapes, ObservableCollection<Connections> connections, List<Shape> shapesToRemove) {
			this.shapes = shapes;
			this.shapesToRemove = shapesToRemove;
			this.connectionsToRemove = connections.Where(x => shapesToRemove.Any(y => y.Id == x.From.Id || y.Id == x.To.Id)).ToList();
		}

		public void Execute() {
			shapesToRemove.ForEach(x => shapesToRemove.Remove(x));
		}

		public void UnExecute() {
			shapesToRemove.ForEach(x => shapesToRemove.Add(x));
		}
	}
}
