using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	class CanvasM : ObservableObject {

		private double width;
		private double height;

		public CanvasM() {
			//width = 500;
			//height = width * Math.Sqrt(2);
		}

		public double Height {
			get { return height; }
			set {
				if (height != value) {
					height = value;
					RaisePropertyChanged();
				}
			}
		}

		public double Width {
			get { return width; }
			set {
				if (width != value) {
					width = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
