using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	class JoinVM : ShapeBaseViewModel {

		public JoinVM() {
			Shape = new JoinM();
		}

		public JoinVM(int Id, int Width, int Height, int X, int Y, string Description) {
			Shape = new JoinM();
			this.Id = Id; this.Width = Width; this.Height = Height; this.X = X; this.Y = Y; this.Description = Description;
		}

		public override string ToString() {
			return "JOI" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}
	}
}
