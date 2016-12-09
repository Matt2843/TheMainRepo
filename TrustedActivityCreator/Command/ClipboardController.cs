using GalaSoft.MvvmLight;
using TrustedActivityCreator.ViewModel;

namespace TrustedActivityCreator.Command {
	class ClipboardController : ObservableObject {

		public static ClipboardController Instance { get; } = new ClipboardController();

		private SelectedShapeController SelectedController = SelectedShapeController.Instance;

		private ClipboardController() { }

		private ShapeBaseViewModel clipboard;

		public ShapeBaseViewModel Clipboard {
			get { return clipboard; }
			set {
				clipboard = value;
				RaisePropertyChanged();
			}
		}
	}
}
