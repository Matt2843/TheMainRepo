using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedActivityCreator.Command {
	class SelectedShapeController {

		public static SelectedShapeController Instance { get; } = new SelectedShapeController();

		private SelectedShapeController() { }
	}
}
