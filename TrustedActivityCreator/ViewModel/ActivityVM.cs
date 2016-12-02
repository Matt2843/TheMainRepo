using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;
using System.Windows.Controls;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.View;
using System;
using System.Xml.Serialization;

namespace TrustedActivityCreator.ViewModel {

	[Serializable]
	[XmlInclude(typeof(ActivityVM))]
	public class ActivityVM : ShapeBaseViewModel {

		/// <summary>
		/// The command properties
		/// </summary>
		public ActivityVM() {
			Shape = new ActivityM();
		}

		public ActivityVM(int Id, int Width, int Height, int X, int Y, string Description) : base(Id, Width, Height, X, Y, Description) {
		}

		public override string ToString() {
			return "ACT" + "," + Id.ToString() + "," + Width.ToString() + "," + Height.ToString() + "," + X.ToString() + "," + Y.ToString() + "," + Description;
		}


	}
}
