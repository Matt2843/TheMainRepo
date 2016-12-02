using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TrustedActivityCreator.GUI {
	public partial class EndingPoint : ShapeBase {

		private Ellipse innerCircle, outerCircle;

		public EndingPoint() {
			innerCircle = new Ellipse();
			outerCircle = new Ellipse();

			innerCircle.Fill = Brushes.Black;
			innerCircle.Margin = new Thickness(5, 5, 5, 5);

			outerCircle.Fill = Brushes.White;
			outerCircle.Stroke = Brushes.Black;
			outerCircle.StrokeThickness = 2;
			outerCircle.Margin = new Thickness(2, 2, 2, 2);

			LeftAnchor.HorizontalAlignment = HorizontalAlignment.Left;
			LeftAnchor.VerticalAlignment = VerticalAlignment.Center;

			RightAnchor.HorizontalAlignment = HorizontalAlignment.Right;
			RightAnchor.VerticalAlignment = VerticalAlignment.Center;

			BottomAnchor.HorizontalAlignment = HorizontalAlignment.Center;
			BottomAnchor.VerticalAlignment = VerticalAlignment.Bottom;

			TopAnchor.HorizontalAlignment = HorizontalAlignment.Center;
			TopAnchor.VerticalAlignment = VerticalAlignment.Top;

			tryHandles(innerCircle);
			tryHandles(outerCircle);

			rootGrid.Children.Add(LeftAnchor);
			rootGrid.Children.Add(TopAnchor);
			rootGrid.Children.Add(RightAnchor);
			rootGrid.Children.Add(BottomAnchor);
			rootGrid.Children.Add(outerCircle);
			rootGrid.Children.Add(innerCircle);
		}
	}
}
