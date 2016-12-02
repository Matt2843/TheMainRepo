using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	public class TrustedConditionVM : ShapeBaseViewModel {

		public TrustedConditionVM() {
			Shape = new ConditionM();
		}

		public TrustedConditionVM(int Id, int Width, int Height, int X, int Y, string Description) {
			Shape = new ConditionM();
			this.Id = Id; this.Width = Width; this.Height = Height; this.X = X; this.Y = Y; this.Description = Description;
		}

		public override string ToString() {
			return "CON" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}

	}
}
