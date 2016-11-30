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

namespace TrustedActivityCreator.Model {
	class TrustedCollection {
		public static ObservableCollection<ActivityVM> Shapes { get; } = new ObservableCollection<ActivityVM>();
	}
}
