using System.Windows;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
	class PolyConnector : ConnectorBase {

		public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points", typeof(PointCollection), typeof(PolyConnector), new FrameworkPropertyMetadata(new PointCollection(), FrameworkPropertyMetadataOptions.AffectsMeasure));

		public PointCollection Points {
			get { return (PointCollection)GetValue(PointsProperty); }
			set { SetValue(PointsProperty, value); }
		}

		//public PolyConnector() {
		//	Points = new PointCollection();
		//}

		protected override Geometry DefiningGeometry {
			get {
				pg.Figures.Clear();

				if(Points.Count > 0) {
					pathConnector.StartPoint = Points[0];
					segConnector.Points.Clear();

					for(int i = 1; i < Points.Count; i++) {
						segConnector.Points.Add(Points[i]);
					}

					pg.Figures.Add(pathConnector);
				}

				return base.DefiningGeometry;
			}
		}

	}
}
