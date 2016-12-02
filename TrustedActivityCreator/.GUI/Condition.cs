using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {

	public partial class Condition : ShapeBase {

		private Grid RotatedGrid;
		private TextBlock True, False;

		public Condition() {
			RotatedGrid = new Grid();
			True = new TextBlock();
			False = new TextBlock();
			Description.Margin = new Thickness(-75, -30, 10, 10);
			ShapeGeometry.Margin = new Thickness(3, 3, 3, 3);

			True.Text = "1"; True.VerticalAlignment = VerticalAlignment.Bottom; True.HorizontalAlignment = HorizontalAlignment.Left;
			True.RenderTransform = new RotateTransform(-45);
			True.Margin = new Thickness(-100, 0, 0, 0);
			False.Text = "0"; False.VerticalAlignment = VerticalAlignment.Bottom; True.HorizontalAlignment = HorizontalAlignment.Right;
			False.RenderTransform = new RotateTransform(-45);
			False.Margin = new Thickness(0, 0, 0, -15);

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
			RotatedGrid.Children.Add(True);
			RotatedGrid.Children.Add(False);
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
