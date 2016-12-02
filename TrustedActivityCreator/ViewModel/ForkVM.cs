using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	class ForkVM : ShapeBaseViewModel {

		public ForkVM() {
			Shape = new ForkM();
		}

		public ForkVM(int Id, int Width, int Height, int X, int Y, string Description) {
			Shape = new ForkM();
			this.Id = Id; this.Width = Width; this.Height = Height; this.X = X; this.Y = Y; this.Description = Description;
		}

		public override string ToString() {
			return "FOR" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}

	}
}
