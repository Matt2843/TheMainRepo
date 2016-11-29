using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.ViewModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
	class QuickPanelVM : ObservableObject {

		public ObservableCollection<ActivityVM> Shapes { get; set; }

		public QuickPanelVM() {
			Shapes = new ObservableCollection<ActivityVM>() { new ActivityVM(), new ActivityVM(), new ActivityVM() };
		}
	}
}
