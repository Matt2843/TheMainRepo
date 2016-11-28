using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
	class MoveShapeCommand : IUndoRedoCommand {
		private ShapeM shape;

		private double offsetX;
		private double offsetY;

		public MoveShapeCommand(ShapeM shape, double offsetX, double offsetY) {
			this.shape = shape;
			this.offsetX = offsetX;
			this.offsetY = offsetY;
		}

		public void Execute() {
			shape.X += (int)offsetX;
			shape.Y += (int)offsetY;
		}

		// For undoing the command.
		public void UnExecute() {
			shape.X -= (int)offsetX;
			shape.Y -= (int)offsetY;
		}
	}
}
