using GalaSoft.MvvmLight;
using System;
namespace TrustedActivityCreator.Model {
    class Activity : ObservableObject {

        private int activityId;
        private string activityDescription = "Activity";

        private int width = 100;
        private int height = 50;
        private int x;
        private int y;

        public int ActivityId {
            get { return activityId; }
            set {
                if(value != activityId) {
                    activityId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ActivityDescription {
            get { return activityDescription; }
            set {
                if(value != activityDescription) {
                    activityDescription = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Width {
            get { return width; }
            set {
                if (value != width) {
                    width = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Height {
            get { return height; }
            set {
                if (value != height) {
                    height = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int X {
            get { return x; }
            set {
                if (value != x) {
                    x = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Y {
            get { return y; }
            set {
                if (value != y) {
                    y = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
