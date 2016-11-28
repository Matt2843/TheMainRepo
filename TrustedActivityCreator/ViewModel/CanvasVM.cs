using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace TrustedActivityCreator.ViewModel {
	public class CanvasVM : ObservableObject {

		private bool isAddingLine = false;

		private ICommand activityMouseDownCommand;
		private ICommand activityMouseMoveCommand;
		private ICommand activityMouseUpCommand;


	}
}
