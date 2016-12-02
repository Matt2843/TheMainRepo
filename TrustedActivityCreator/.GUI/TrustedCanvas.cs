using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
	public class FrameworkElement : Canvas {

		public static readonly DependencyProperty numOfVerticalLines = DependencyProperty.Register("NumOfVerticalLines", typeof(int), typeof(FrameworkElement), new PropertyMetadata(24));
		public static readonly DependencyProperty numOfHorizontalLines = DependencyProperty.Register("NumOfHorizontalLines", typeof(int), typeof(FrameworkElement), new PropertyMetadata(24));
		public static readonly DependencyProperty linesThickness = DependencyProperty.Register("LineThickness", typeof(int), typeof(FrameworkElement), new PropertyMetadata(1));

		public int LineThickness {
			get { return (int)GetValue(linesThickness); }
			set { SetValue(linesThickness, value); }
		}

		public int NumOfVerticalLines {
			get { return (int)GetValue(numOfVerticalLines); }
			set { SetValue(numOfVerticalLines, value); }
		}

		public int NumOfHorizontalLines {
			get { return (int)GetValue(numOfHorizontalLines); }
			set { SetValue(numOfHorizontalLines, value); }
		}

		private double CellHeight;
		private double CellWidth;

		protected override void OnRender(DrawingContext dc) {
			base.OnRender(dc);

			double Ratio = ActualHeight / ActualWidth;

			CellWidth = ActualWidth / 25;
			CellHeight = CellWidth;
			

            double vOffset = CellWidth, hOffset = CellHeight;

			Brush brush = new SolidColorBrush(Colors.Black);
			brush.Opacity = 0.1;

            Pen pen = new Pen(brush, LineThickness);
			pen.DashStyle = DashStyles.Dash;

			while(vOffset < ActualWidth - (CellWidth / 5)) {
				dc.DrawLine(pen, new Point(vOffset, 0), new Point(vOffset, ActualHeight));
				vOffset += CellWidth;
			}

			while(hOffset < ActualHeight - (CellHeight / 5)) {
				dc.DrawLine(pen, new Point(0, hOffset), new Point(ActualWidth, hOffset));
				hOffset += CellHeight;
			}
		}
	}
}
