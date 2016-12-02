using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustedActivityCreator.ViewModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Model {
	class TrustedCollection {
		public static ObservableCollection<ShapeBaseViewModel> Shapes { get; } = new ObservableCollection<ShapeBaseViewModel>();
		public static ObservableCollection<TrustedConnectionVM> Connections { get; } = new ObservableCollection<TrustedConnectionVM>();

		private static Shape selectedShape;

		public static Shape SelectedShape { get { return selectedShape; } set { selectedShape = value; } }

	}
}
