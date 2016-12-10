using TrustedActivityCreator.Model;
using GalaSoft.MvvmLight;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class SelectedShapeController : ObservableObject {

		public static SelectedShapeController Instance { get; } = new SelectedShapeController();

		private SelectedShapeController() { }

		private ShapeBaseViewModel selectedShape;

		public ShapeBaseViewModel SelectedShape {
			get { return selectedShape; }
			set {
				if(selectedShape != null) {
					selectedShape.Selected = false;
				}
				selectedShape = value;
				selectedShape.Selected = true;
				RaisePropertyChanged();
			}
		}
	}
}
