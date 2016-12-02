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
				selectedShape = value;
				RaisePropertyChanged();
			}
		}
	}
}
