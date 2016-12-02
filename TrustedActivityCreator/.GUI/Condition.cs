using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {

	public partial class Condition : ShapeBase {

		private Grid RotatedGrid;

		public Condition() {
			RotatedGrid = new Grid();
			Description.Margin = new Thickness(10, 10, 10, 10);
			ShapeGeometry.Margin = new Thickness(3, 3, 3, 3);

			// Rotated grid for Rectangle and anchorpoints
			RotatedGrid.RenderTransformOrigin = new Point(0.5, 0.5);
			RotatedGrid.RenderTransform = new RotateTransform(45);

			BottomAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			BottomAnchor.HorizontalAlignment = HorizontalAlignment.Right;

			LeftAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			LeftAnchor.HorizontalAlignment = HorizontalAlignment.Left;

			RightAnchor.VerticalAlignment = VerticalAlignment.Top;
			RightAnchor.HorizontalAlignment = HorizontalAlignment.Right;

			TopAnchor.VerticalAlignment = VerticalAlignment.Top;
			TopAnchor.HorizontalAlignment = HorizontalAlignment.Left;

			//Add anchorpoints and rectangle to the rotated coordinate-system
			RotatedGrid.Children.Add(BottomAnchor);
			RotatedGrid.Children.Add(LeftAnchor);
			RotatedGrid.Children.Add(TopAnchor);
			RotatedGrid.Children.Add(RightAnchor);
			RotatedGrid.Children.Add(ShapeGeometry);

			//Add rotated coordinate-system to normal system
			rootGrid.Children.Add(RotatedGrid);
			rootGrid.Children.Add(Description);
		}

	}
}
