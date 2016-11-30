using System;
using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	class Activity : Shape {
		public Activity() { }
		public Activity(int id, int width, int height, int x, int y) : base(id, width, height, x, y) { }

		public override void setProperties() {
			Width = 100;
			Height = 40;
			Description = "Activity";
		}




	}
}
