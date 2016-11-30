using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using System.Windows.Controls;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.GUI;
using TrustedActivityCreator.View;

namespace TrustedActivityCreator.ViewModel {
	class ActivityVM : ShapeBaseViewModel {
		
		/// <summary>
		/// The command properties
		/// </summary>
		public ActivityVM() {
			Shape = new Activity();
		}


	}
}
