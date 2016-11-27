using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
    class TrustedCanvas : Canvas {

        public static readonly DependencyProperty NumOfVerticalLines = DependencyProperty.Register("NumOfVerticalLines", typeof(int), typeof(TrustedCanvas), new UIPropertyMetadata(24));
        public static readonly DependencyProperty NumOfHorizontalLines = DependencyProperty.Register("NumOfHorizontalLines", typeof(int), typeof(TrustedCanvas), new UIPropertyMetadata(24));
        public static readonly DependencyProperty LinesThickness = DependencyProperty.Register("LineThickness", typeof(int), typeof(TrustedCanvas), new UIPropertyMetadata(2));
        
        public int LINETHICKNESS {
            get { return (int)GetValue(LinesThickness); }
        }

        public int NUMBEROFVERTICALLINES {
            get { return (int)GetValue(NumOfVerticalLines); }
        }

        public int NUMBEROFHORIZONTALLINES {
            get { return (int)GetValue(NumOfHorizontalLines); }
        }

        private int CellHeight;
        private int CellWidth;

        protected override void OnRender(DrawingContext dc) {
            base.OnRender(dc);
            CellHeight = (int)ActualHeight / NUMBEROFVERTICALLINES;
            CellWidth = (int)ActualWidth / NUMBEROFHORIZONTALLINES;

            double vOffset = 0, hOffset = 0;
            float[] dashValues = { 5, 2, 15, 4 };

            Brush brush = new SolidColorBrush(Colors.Black);

            Pen pen = new Pen(brush, LINETHICKNESS);
            pen.DashStyle = DashStyles.Dash;
            
            for(int i = 0; i < NUMBEROFHORIZONTALLINES; i++) {
                for(int j = 0; j < NUMBEROFVERTICALLINES; j++) {
                    dc.DrawLine(pen, new Point(hOffset, vOffset), new Point(hOffset, CellHeight + vOffset));
                    vOffset += CellHeight;
                }
                hOffset += CellWidth;
                vOffset = 0;
            }

            hOffset = 0;

            for(int i = 0; i < NUMBEROFVERTICALLINES; i++) {
                for(int j = 0; j < NUMBEROFHORIZONTALLINES; i++) {
                    dc.DrawLine(pen, new Point(hOffset, vOffset), new Point(CellWidth + hOffset, vOffset));
                    hOffset += CellWidth;
                }
                vOffset += CellHeight;
                hOffset = 0;
            }

        }
    }
}
