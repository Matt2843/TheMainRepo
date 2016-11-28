using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
    class AddShapeCommand : IUndoRedoCommand {

        ObservableCollection<ShapeM> shapes;
        private ShapeM shape;

        public AddShapeCommand(ObservableCollection<ShapeM> shapes, ShapeM shape) {
            this.shapes = shapes;
            this.shape = shape;
        }

        public void Execute() {
			shapes.Add(shape);
        }

        public void UnExecute() {
			shapes.Remove(shape);
        }
    }
}
