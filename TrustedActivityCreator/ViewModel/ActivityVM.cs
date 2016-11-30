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
		/// The current activity information.
		/// </summary>
		private Activity activity;
		public string ActivityDescription { get { return Activity.ActivityDescription; } set { Activity.ActivityDescription = value; RaisePropertyChanged(); } }

		/// <summary>
		/// The command properties
		/// </summary>

		public ActivityVM() {
			Activity = new Activity();
		}

		public Activity Activity {
			get { return activity; }
			set {
				if (value != activity) {
					activity = value;
					RaisePropertyChanged();
				}
			}
		} 


	}
}
