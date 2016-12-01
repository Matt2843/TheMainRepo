using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrustedActivityCreator.GUI;

namespace TrustedActivityCreator.View {
	/// <summary>
	/// Interaction logic for ConditionUC.xaml
	/// </summary>
	public partial class ConditionUC : ShapeBase {

		private Grid RotatedGrid;

		public ConditionUC() {
			InitializeComponent();
			
			Binding XBind = new Binding("X");
			Binding YBind = new Binding("Y");
			Binding WidthBind = new Binding("Width");
			Binding HeightBind = new Binding("Height");

			XBind.Source = Canvas.LeftProperty;
			YBind.Source = Canvas.TopProperty;
			WidthBind.Source = WidthProperty;
			HeightBind.Source = HeightProperty;

			placeComponents();
		}

		private void placeComponents() {
			RotatedGrid = new Grid();
			Description.Margin = new Thickness(10, 10, 10, 10);
			ShapeGeometry.Margin = new Thickness(3, 3, 3, 3);

			// Rotated grid for Rectangle and anchorpoints
			RotatedGrid.RenderTransformOrigin = new Point(0.5,0.5);
			RotatedGrid.RenderTransform = new RotateTransform(45);

			Console.WriteLine(BottomAnchor.Width);

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
