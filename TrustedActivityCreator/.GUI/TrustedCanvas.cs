using System;
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

        private int CellHeight;
        private int CellWidth;

        protected override void OnRender(DrawingContext dc) {
            base.OnRender(dc);
            CellHeight = (int)ActualHeight / NumOfVerticalLines;
            CellWidth = (int)ActualWidth / NumOfHorizontalLines;

            double vOffset = 0, hOffset = 0;

            Brush brush = new SolidColorBrush(Colors.Black);

            Pen pen = new Pen(brush, LineThickness);
            //pen.DashStyle = DashStyles.Dash;

            for (int i = 0; i < NumOfHorizontalLines; i++) {
                for (int j = 0; j < NumOfVerticalLines; j++) {

                    dc.DrawLine(pen, new Point(hOffset, vOffset), new Point(hOffset, CellHeight + vOffset));
                    vOffset += CellHeight;
                }
                hOffset += CellWidth;
                vOffset = 0;
            }
            hOffset = 0;
            vOffset = 0;

            for (int i = 0; i < NumOfVerticalLines; i++) {
                for (int j = 0; j < NumOfHorizontalLines; j++) {
                    dc.DrawLine(pen, new Point(hOffset, vOffset), new Point(CellWidth + hOffset, vOffset));
                    hOffset += CellWidth;
                }
                vOffset += CellHeight;
                hOffset = 0;
            }

        }

    }
}
