using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System;

namespace TrustedActivityCreator.GUI {
	public abstract class ConnectorBase : Shape {

		protected PathGeometry pg;
		protected PathFigure pathConnector;
		protected PolyLineSegment segConnector;

		PathFigure figureHeadA;
		PolyLineSegment segmentHeadA;
		PathFigure figureHeadB;
		PolyLineSegment segmentHeadB;

		public static readonly DependencyProperty ConnectorAngleProperty = DependencyProperty.Register("ConnectorAngle", typeof(double), typeof(ConnectorBase), new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty ConnectorLengthProperty = DependencyProperty.Register("ConnectorLength", typeof(double), typeof(ConnectorBase), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty ConnectorEndsProperty = DependencyProperty.Register("ConnectorEnds", typeof(ConnectorEnds), typeof(ConnectorBase), new FrameworkPropertyMetadata(ConnectorEnds.End, FrameworkPropertyMetadataOptions.AffectsMeasure));
		public static readonly DependencyProperty IsConnectorClosedProperty = DependencyProperty.Register("IsConnectorClose", typeof(bool), typeof(ConnectorBase), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));

		public double ConnectorAngle {
			get { return (double)GetValue(ConnectorAngleProperty); }
			set { SetValue(ConnectorAngleProperty, value); }
		}

		public double ConnectorLength {
			get { return (double)GetValue(ConnectorLengthProperty); }
			set { SetValue(ConnectorLengthProperty, value); }
		}

		public ConnectorEnds ConnectorEnds {
			get { return (ConnectorEnds)GetValue(ConnectorEndsProperty); }
			set { SetValue(ConnectorEndsProperty, value); }
		}

		public bool IsConnectorClosed {
			get { return (bool)GetValue(IsConnectorClosedProperty); }
			set { SetValue(IsConnectorClosedProperty, value); }
		}

		public ConnectorBase() {
			pg = new PathGeometry();

			pathConnector = new PathFigure();
			segConnector = new PolyLineSegment();
			pathConnector.Segments.Add(segConnector);

			figureHeadA = new PathFigure();
			segmentHeadA = new PolyLineSegment();
			figureHeadA.Segments.Add(segmentHeadA);

			figureHeadB = new PathFigure();
			segmentHeadB = new PolyLineSegment();
			figureHeadB.Segments.Add(segmentHeadB);
		}

		protected override Geometry DefiningGeometry {
			get {
				int count = segConnector.Points.Count;

				if(count > 0) {
					if((ConnectorEnds & ConnectorEnds.Start) == ConnectorEnds.Start) {
						Point p1 = pathConnector.StartPoint;
						Point p2 = segConnector.Points[0];
						pg.Figures.Add(CalculateConnector(figureHeadA, p2, p1));
					}

					if((ConnectorEnds & ConnectorEnds.End) == ConnectorEnds.End) {
						Point p1 = count == 1 ? pathConnector.StartPoint : segConnector.Points[count - 2];
						Point p2 = segConnector.Points[count - 1];
						pg.Figures.Add(CalculateConnector(figureHeadB, p1, p2));
					}
				}
				return pg;
			}
		}

		private PathFigure CalculateConnector(PathFigure figurehead, Point p1, Point p2) {
			Matrix m = new Matrix();
			Vector v = p1 - p2;
			v.Normalize();
			v *= ConnectorLength;

			PolyLineSegment pls = figurehead.Segments[0] as PolyLineSegment;
			pls.Points.Clear();
			m.Rotate(ConnectorAngle / 2);
			figurehead.StartPoint = p2 + v * m;
			pls.Points.Add(p2);

			m.Rotate(-ConnectorAngle);
			pls.Points.Add(p2 + v * m);
			figurehead.IsClosed = IsConnectorClosed;

			return figurehead;
		}


	}
}
