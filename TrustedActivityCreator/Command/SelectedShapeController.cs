using TrustedActivityCreator.Model;
using GalaSoft.MvvmLight;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class SelectedShapeController : ObservableObject {

		public static SelectedShapeController Instance { get; } = new SelectedShapeController();

		public void raise() {
			RaisePropertyChanged();
		}

		private SelectedShapeController() { }

		private ShapeBaseViewModel selectedShape;

		public ShapeBaseViewModel SelectedShape {
			get { return selectedShape; }
			set {
				if(selectedShape != null) { selectedShape.Selected = false; }
				selectedShape = value;
				if(selectedShape != null) { selectedShape.Selected = true; }
				RaisePropertyChanged();
			}
		}
	}
}
