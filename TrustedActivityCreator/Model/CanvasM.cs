using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
    class CanvasM : ObservableObject{

		/// <summary>
		/// A4 std format.
		/// </summary>
		//private double width;
		//private double height;

		public static readonly DependencyProperty width = DependencyProperty.Register("Width", typeof(double), typeof(CanvasM), new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty height = DependencyProperty.Register("Height", typeof(double), typeof(CanvasM), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		public CanvasM() {
			//width = 500;
			//height = width * Math.Sqrt(2);
		}
        
        public double Height {
            get { return (double) GetValue(height); }
            set { SetValue(height, value); RaisePropertyChanged(); }
            }
        }

		public double Width {
			get { return (double) GetValue(width); }
			set { SetValue(width, value); RaisePropertyChanged(); }
			}
		}
    }
}
