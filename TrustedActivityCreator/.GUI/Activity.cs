using System.Windows;
using System.Windows.Controls;

namespace TrustedActivityCreator.GUI {

	public partial class Activity : ShapeBase {

		public Activity() {
			ShapeGeometry.RadiusX = 5;
			ShapeGeometry.RadiusY = 5;

			ShapeGeometry.Margin = new Thickness(3, 3, 3, 3);
			Description.Margin = new Thickness(5, 5, 5, 5);

			BottomAnchor.VerticalAlignment = VerticalAlignment.Bottom;
			BottomAnchor.HorizontalAlignment = HorizontalAlignment.Center;

			LeftAnchor.VerticalAlignment = VerticalAlignment.Center;
			LeftAnchor.HorizontalAlignment = HorizontalAlignment.Left;

			RightAnchor.VerticalAlignment = VerticalAlignment.Center;
			RightAnchor.HorizontalAlignment = HorizontalAlignment.Right;

			TopAnchor.VerticalAlignment = VerticalAlignment.Top;
			TopAnchor.HorizontalAlignment = HorizontalAlignment.Center;

			Panel.SetZIndex(Description, 3000);

			//Add Stuff to rootGrid;		
			rootGrid.Children.Add(LeftAnchor);
			rootGrid.Children.Add(RightAnchor);
			rootGrid.Children.Add(BottomAnchor);
			rootGrid.Children.Add(TopAnchor);		
			rootGrid.Children.Add(ShapeGeometry);
			rootGrid.Children.Add(Description);
		}
	}
}
