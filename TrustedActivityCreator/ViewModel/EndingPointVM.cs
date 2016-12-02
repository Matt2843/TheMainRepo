using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {

	public class EndingPointVM : ShapeBaseViewModel {

		public EndingPointVM() {
			Shape = new EndingPointM();
		}

		public EndingPointVM(int Id, int Width, int Height, int X, int Y, string Description) {
			Shape = new EndingPointM();
			this.Id = Id; this.Width = Width; this.Height = Height; this.X = X; this.Y = Y; this.Description = Description;
		}

		public override string ToString() {
			return "EDP" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}
	}
}
