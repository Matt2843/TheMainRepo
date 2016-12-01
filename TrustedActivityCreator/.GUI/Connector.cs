﻿using System.Windows;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
	public class Connector : ConnectorBase {
		public static readonly DependencyProperty X1Property = DependencyProperty.Register("X1", typeof(double), typeof(Connector), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty Y1Property = DependencyProperty.Register("Y1", typeof(double), typeof(Connector), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty X2Property = DependencyProperty.Register("X2", typeof(double), typeof(Connector), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty Y2Property = DependencyProperty.Register("Y2", typeof(double), typeof(Connector), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

		public double X1 {
			get { return (double)GetValue(X1Property); }
			set { SetValue(X1Property, value); }
		}

		public double Y1 {
			get { return (double)GetValue(Y1Property); }
			set { SetValue(Y1Property, value); }
		}

		public double X2 {
			get { return (double)GetValue(X2Property); }
			set { SetValue(X2Property, value); }
		}

		public double Y2 {
			get { return (double)GetValue(Y2Property); }
			set { SetValue(Y2Property, value); }
		}

		protected override Geometry DefiningGeometry {
			get {
				pg.Figures.Clear();

				pathConnector.StartPoint = new Point(X1, Y1);
				segConnector.Points.Clear();
				segConnector.Points.Add(new Point(X2, Y2));
				pg.Figures.Add(pathConnector);

				return base.DefiningGeometry;
			}
		}


	}
}
