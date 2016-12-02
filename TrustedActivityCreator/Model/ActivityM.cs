using System;
using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	class ActivityM : Shape {
		public ActivityM() { }
		public ActivityM(int id, int width, int height, int x, int y) : base(id, width, height, x, y) { }

		public override void setProperties() {
			Width = 100;
			Height = 40;
			Description = "Activity";
		}

	}
}
