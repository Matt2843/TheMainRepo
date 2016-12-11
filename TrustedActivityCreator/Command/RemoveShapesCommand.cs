using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
    class RemoveShapesCommand : IUndoRedoCommand {

		private ObservableCollection<ShapeBaseViewModel> Shapes { get; } = TrustedCollection.Shapes;
		private ObservableCollection<TrustedConnectionVM> Connections { get; } = TrustedCollection.Connections;

		private List<ShapeBaseViewModel> shapesToRemove;

		private List<TrustedConnectionVM> connectionsToRemove;

		public RemoveShapesCommand(List<ShapeBaseViewModel> shapesToRemove) {
            this.shapesToRemove = shapesToRemove;
			this.connectionsToRemove = Connections.Where(c => shapesToRemove.Any(s => s.Id == c.From.Id || s.Id == c.To.Id)).ToList();
		}

        public void Execute() {
			shapesToRemove.ForEach(x => Shapes.Remove(x));
			connectionsToRemove.ForEach(x => Connections.Remove(x));
		}

        public void UnExecute() {
			shapesToRemove.ForEach(x => Shapes.Add(x));
			connectionsToRemove.ForEach(x => Connections.Add(x));
		}
    }
}
