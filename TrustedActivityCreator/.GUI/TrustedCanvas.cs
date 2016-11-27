using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrustedActivityCreator.GUI {
    class TrustedCanvas : Canvas {

        public static readonly DependencyProperty NumOfVerticalLines = DependencyProperty.Register("NumOfVerticalLines", typeof(int), typeof(TrustedCanvas), new PropertyMetadata(false));
        public static readonly DependencyProperty NumOfHorizontalLines = DependencyProperty.Register("NumOfHorizontalLines", typeof(int), typeof(TrustedCanvas), new PropertyMetadata(false));
        public static readonly DependencyProperty LinesThickness = DependencyProperty.Register("LineThickness", typeof(int), typeof(TrustedCanvas), new PropertyMetadata(false));
        
        public int LTVAL {
            get { return (int)GetValue(LinesThickness); }
        }

        public int NOVLVAL {
            get { return (int)GetValue(NumOfVerticalLines); }
        }

        public int NOHLVAL {
            get { return (int)GetValue(NumOfHorizontalLines); }
        }

        private int CellHeight;
        private int CellWidth;

        protected override void OnRender(DrawingContext dc) {
            base.OnRender(dc);
            CellHeight = (int)ActualHeight / NOVLVAL;
            CellWidth = (int)ActualWidth / NOHLVAL;

            double vOffset = 0, hOffset = 0;

            Pen pen = new Pen();
            pen.Thickness = LTVAL;
            

        }
    }
}
