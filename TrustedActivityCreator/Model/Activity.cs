using GalaSoft.MvvmLight;
namespace TrustedActivityCreator.Model {
    class Activity : ObservableObject {

        private int activityId;
        private string activityDescription;

        private int width;
        private int height;
        private int x;
        private int y;

        public Activity() {
            width = 100;
            height = 50;
            activityDescription = "Activity";
        }

        public int ActivityId {
            get { return activityId; }
            set {
                if(value != activityId) {
                    activityId = value;
                    RaisePropertyChanged("ActivityId");
                }
            }
        }

        public string ActivityDescription {
            get { return activityDescription; }
            set {
                if(value != activityDescription) {
                    activityDescription = value;
                    RaisePropertyChanged("ActivityDescription");
                }
            }
        }

        public int Width {
            get { return width; }
            set {
                if (value != width) {
                    width = value;
                    RaisePropertyChanged("Width");
                }
            }
        }

        public int Height {
            get { return height; }
            set {
                if (value != height) {
                    height = value;
                    RaisePropertyChanged("Height");
                }
            }
        }

        public int X {
            get { return x; }
            set {
                if (value != x) {
                    x = value;
                    RaisePropertyChanged("X");
                }
            }
        }

        public int Y {
            get { return y; }
            set {
                if (value != y) {
                    y = value;
                    RaisePropertyChanged("Y");
                }
            }
        }
    }
}
