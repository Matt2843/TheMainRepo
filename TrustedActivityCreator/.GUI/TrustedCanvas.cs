﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
	public class TrustedCanvas : Canvas {

		public static readonly DependencyProperty numOfVerticalLines = DependencyProperty.Register("NumOfVerticalLines", typeof(int), typeof(TrustedCanvas), new PropertyMetadata(8));
		public static readonly DependencyProperty numOfHorizontalLines = DependencyProperty.Register("NumOfHorizontalLines", typeof(int), typeof(TrustedCanvas), new PropertyMetadata(8));
		public static readonly DependencyProperty linesThickness = DependencyProperty.Register("LineThickness", typeof(int), typeof(TrustedCanvas), new PropertyMetadata(1));

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
			CellHeight = ActualHeight / NumOfVerticalLines;
			CellWidth = ActualWidth / NumOfHorizontalLines;

            double vOffset = CellWidth, hOffset = CellHeight;

			Brush brush = new SolidColorBrush(Colors.Black);

            Pen pen = new Pen(brush, LineThickness);
            pen.DashStyle = DashStyles.Dash;

			for(int i = 0; i < NumOfVerticalLines - 1; i++) {
				dc.DrawLine(pen, new Point(vOffset, 0), new Point(vOffset, ActualHeight));
				vOffset += CellWidth;
			}

			for(int i = 0; i < NumOfHorizontalLines - 1; i++) {
				dc.DrawLine(pen, new Point(0, hOffset), new Point(ActualWidth, hOffset));
				hOffset += CellHeight;
			}
		}
	}
}
