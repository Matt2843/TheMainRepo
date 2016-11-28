using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
    class AddShapeCommand : IUndoRedoCommand {

        ObservableCollection<Shape> shapes;
        private Shape shape;

        public AddShapeCommand(ObservableCollection<Shape> shapes, Shape shape) {
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
