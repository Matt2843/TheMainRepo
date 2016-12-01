﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TrustedActivityCreator.Model {
    class Canvas : ObservableObject{

		/// <summary>
		/// A4 std format.
		/// </summary>
		private double width;
		private double height;

		public Canvas() {
			width = 500;
			height = width * Math.Sqrt(2);
		}
        
        public double Height {
            get { return height; }
            set {
                if(height != value) {
                    height = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double Width {
            get { return width; }
            set {
                if(width != value) {
                    width = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
