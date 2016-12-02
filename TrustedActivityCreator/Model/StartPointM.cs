using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustedActivityCreator.Model {
	class StartPointM : Shape {

		public StartPointM() { }
		public StartPointM(int id, int width, int height, int x, int y) : base(id, width, height, x, y) { }

		public override void setProperties() {
			Width = 15;
			Height = 15;
		}

	}
}
