using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	public abstract class Shape : ObservableObject {

		private int id;
		private int width = 75;
		private int height = 75;
		private int x;
		private int y;

		public int Id {
			get { return id; }
		}

		public int Width {
			get { return width; }
			set {
				if (value != width) {
					width = value;
					RaisePropertyChanged();
				}
			}
		}

		public int Height {
			get { return height; }
			set {
				if (value != height) {
					height = value;
					RaisePropertyChanged();
				}
			}
		}

		public int X {
			get { return x; }
			set {
				if (value != x) {
					x = value;
					RaisePropertyChanged();
				}
			}
		}

		public int Y {
			get { return y; }
			set {
				if (value != y) {
					y = value;
					RaisePropertyChanged();
				}
			}
		}

	}
}
