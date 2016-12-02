using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
	public partial class Fork : ShapeBase {

		public Fork() {
			ShapeGeometry.Fill = Brushes.Black;

			BottomAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			BottomAnchor.HorizontalAlignment = HorizontalAlignment.Center;
			BottomAnchor.Margin = new Thickness(50,0,0,0);

			LeftAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			LeftAnchor.HorizontalAlignment = HorizontalAlignment.Left;

			RightAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			RightAnchor.HorizontalAlignment = HorizontalAlignment.Right;

			TopAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			TopAnchor.HorizontalAlignment = HorizontalAlignment.Center;
			TopAnchor.Margin = new Thickness(0, 0, 50, 0);

			rootGrid.Children.Add(LeftAnchor);
			rootGrid.Children.Add(RightAnchor);
			rootGrid.Children.Add(BottomAnchor);
			rootGrid.Children.Add(TopAnchor);
			rootGrid.Children.Add(ShapeGeometry);
		}
	}
}
