using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedActivityCreator.Model {
	class Condition : Shape {

		public Condition() { }
		public Condition(int id, int width, int height, int x, int y) : base(id, width, height, x, y) { }

		public override void setProperties() {
			Width = 75;
			Height = 75;
			Description = "Condition";
		}
	}
}
