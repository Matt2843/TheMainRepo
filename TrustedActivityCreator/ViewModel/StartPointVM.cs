using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	public class StartPointVM : ShapeBaseViewModel {

		public StartPointVM() {
			Shape = new StartPointM();
		}

		public StartPointVM(int Id, int Width, int Height, int X, int Y, string Description) {
			Shape = new StartPointM();
			this.Id = Id; this.Width = Width; this.Height = Height; this.X = X; this.Y = Y; this.Description = Description;
		}

		public override string ToString() {
			return "STP" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}
	}
}
