using GalaSoft.MvvmLight;
using System;

namespace TrustedActivityCreator.Model {
	public abstract class Shape : ObservableObject {

		private int id;
		private int width;
		private int height;
		private int x;
		private int y;
		private String description;

		public Shape() {
			Id = 0; Width = 0; Height = 0; X = 0; Y = 0; Description = "";
			setProperties();
		}

		public Shape(int id, int width, int height, int x, int y) {
			this.id = id; this.width = width; this.height = height; this.x = x; this.y = y;
		}

		public abstract void setProperties();

		public int Id {
			get { return id; }
			set {
				if(value != id) {
					id = value;
					RaisePropertyChanged();
				}
			}
		}

		public int Width {
			get { return width; }
			set {
				if (value != width) {
					width = value;
					RaisePropertyChanged();
				}
			}
		}

		public int Height {
			get { return height; }
			set {
				if (value != height) {
					height = value;
					RaisePropertyChanged();
				}
			}
		}

		public int X {
			get { return x; }
			set {
				if (value != x) {
					x = value;
					RaisePropertyChanged();
				}
			}
		}

		public int Y {
			get { return y; }
			set {
				if (value != y) {
					y = value;
					RaisePropertyChanged();
				}
			}
		}

		public string Description {
			get { return description; }
			set {
				if (value != description) {
					description = value;
					RaisePropertyChanged();
				}
			}
		}

		public int XMiddle {
			get { return (int) (X + Width / 2); }
		}

		public int YMiddle {
			get { return (int) (Y + Height / 2); }
		}
	}
}
