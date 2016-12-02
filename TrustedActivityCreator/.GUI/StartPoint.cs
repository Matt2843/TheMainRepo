using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TrustedActivityCreator.GUI {
	public partial class StartPoint : ShapeBase {

		private Ellipse startPoint;

		public StartPoint() {
			startPoint = new Ellipse();

			startPoint.Fill = Brushes.Black;

			BottomAnchor.HorizontalAlignment = HorizontalAlignment.Center;
			BottomAnchor.HorizontalAlignment = HorizontalAlignment.Center;

			tryHandles(startPoint);

			rootGrid.Children.Add(BottomAnchor);
			rootGrid.Children.Add(startPoint);
		}

	}
}
