using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.GUI;
using TrustedActivityCreator.ViewModel;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Media;
using System.Linq;

namespace TrustedActivityCreator.ViewModel {
	class CanvasVM : ObservableObject {

		public ObservableCollection<ActivityVM> Shapes { get; set; }

		public double Width { get { return Canvas.Width; } set { Canvas.Width = value; RaisePropertyChanged(); } }
		public double Height { get { return Canvas.Height; } set { Canvas.Height = value; RaisePropertyChanged(); } }

		public CanvasVM() {
			Shapes = new ObservableCollection<ActivityVM>() { new ActivityVM() };
			Canvas = new Canvas();
		}

		private Canvas canvas;
		public Canvas Canvas {
			get { return canvas;  }
			set {
				if (value != canvas) {
					canvas = value;
					RaisePropertyChanged();
				}
			}
		}


	}
}
