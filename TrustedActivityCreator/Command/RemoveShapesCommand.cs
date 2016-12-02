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

		private List<Connection> connectionsToRemove;

		public RemoveShapesCommand(ObservableCollection<Shape> shapes, ObservableCollection<Connection> connections, List<Shape> shapesToRemove) {
            this.shapes = shapes;
            this.shapesToRemove = shapesToRemove;
			this.connectionsToRemove = connections.Where(c => shapesToRemove.Any(s => s.Id == c.From.Id || s.Id == c.To.Id)).ToList();
		}

        public void Execute() {
			shapesToRemove.ForEach(x => shapesToRemove.Remove(x));
        }

        public void UnExecute() {
			shapesToRemove.ForEach(x => shapesToRemove.Add(x));
        }
    }
}
