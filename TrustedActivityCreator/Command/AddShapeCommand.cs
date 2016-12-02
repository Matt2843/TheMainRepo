using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
    class AddShapeCommand : IUndoRedoCommand {

		private ObservableCollection<ShapeBaseViewModel> Shapes { get; } = TrustedCollection.Shapes;
		private ShapeBaseViewModel shape;

        public AddShapeCommand(ShapeBaseViewModel shape) {
            this.shape = shape;
			this.shape.Id = TrustedCollection.idCounter++;
        }

        public void Execute() {
			Shapes.Add(shape);
        }

        public void UnExecute() {
			Shapes.Remove(shape);
        }
    }
}
