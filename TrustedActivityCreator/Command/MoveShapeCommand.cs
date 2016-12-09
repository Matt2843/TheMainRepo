using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class MoveShapeCommand : IUndoRedoCommand {
		private ShapeBaseViewModel shape;

		private double offsetX;
		private double offsetY;

		public MoveShapeCommand(ShapeBaseViewModel shape, double offsetX, double offsetY) {
			this.shape = shape;
			this.offsetX = offsetX;
			this.offsetY = offsetY;
			this.shape.raise();
		}

		public void Execute() {
			shape.X += (int)offsetX;
			shape.Y += (int)offsetY;
			shape.raise();
		}

		// For undoing the command.
		public void UnExecute() {
			shape.X -= (int)offsetX;
			shape.Y -= (int)offsetY;
			shape.raise();
		}
	}
}
