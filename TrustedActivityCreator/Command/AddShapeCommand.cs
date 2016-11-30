using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
    class AddShapeCommand : IUndoRedoCommand {

		private ObservableCollection<ActivityVM> Shapes { get; } = TrustedCollection.Shapes;
		private ActivityVM shape;

        public AddShapeCommand(ActivityVM shape) {
            this.shape = shape;
        }

        public void Execute() {
			Shapes.Add(shape);
        }

        public void UnExecute() {
			Shapes.Remove(shape);
        }
    }
}
