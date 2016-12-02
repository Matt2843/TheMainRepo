using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using System.Windows.Controls;
using System;

namespace TrustedActivityCreator.Model {
    class CanvasM : ObservableObject {

		private double width;
		private double height;

		public CanvasM() {
			//width = 500;
			//height = width * Math.Sqrt(2);
		}

		public double Height {
			get { return height; }
			set {
				if (height != value) {
					height = value;
					RaisePropertyChanged();
				}
			}
		}

		public double Width {
			get { return width; }
			set {
				if (width != value) {
					width = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
