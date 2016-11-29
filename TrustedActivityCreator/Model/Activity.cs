using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
	class Activity : Shape {

		private int activityId;
		private string activityDescription = "Activity";

		public int ActivityId {
			get { return activityId; }
			set {
				if (value != activityId) {
					activityId = value;
					RaisePropertyChanged();
				}
			}
		}

		public string ActivityDescription {
			get { return activityDescription; }
			set {
				if (value != activityDescription) {
					activityDescription = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
