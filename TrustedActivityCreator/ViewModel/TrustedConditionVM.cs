using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	public class TrustedConditionVM : ShapeBaseViewModel {

		public TrustedConditionVM() {
			Shape = new ConditionM();
		}

		public TrustedConditionVM(int Id, int Width, int Height, int X, int Y, string Description) : base(Id, Width, Height, X, Y, Description) {
		}

		public override string ToString() {
			return "CON" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}

	}
}
