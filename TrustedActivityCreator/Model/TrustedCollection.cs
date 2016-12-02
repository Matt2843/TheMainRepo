using System.Collections.ObjectModel;
using TrustedActivityCreator.ViewModel;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Windows.Forms;

namespace TrustedActivityCreator.Model {
	public class TrustedCollection {
		public static ObservableCollection<ShapeBaseViewModel> Shapes { get; } = new ObservableCollection<ShapeBaseViewModel>();
		public static ObservableCollection<TrustedConnectionVM> Connections { get; } = new ObservableCollection<TrustedConnectionVM>();

		/*
		 * XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<TrustedConnectionVM>));
				using (StreamWriter sw = new StreamWriter(saveFileDialog.SafeFileName)) {
						xs.Serialize(sw, Connections);				
				}
		 * 
		 */


		public static void saveToFile() {
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Trusted file (*.trst)|*.trst";
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName)) {

					writer.WriteLine("TYPE,ID,WIDTH,HEIGHT,X,Y,DESCRIPTION");
					foreach (ShapeBaseViewModel s in Shapes) {
						writer.WriteLine(s.ToString());
					}
				}
			}
		}

		public static void loadFromFile() {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Trusted file (*.trst)|*.trst";
			if(openFileDialog.ShowDialog() == DialogResult.OK) {
				using (StreamReader reader = new StreamReader(openFileDialog.FileName)) {
					string line;
					while ((line = reader.ReadLine()) != null) {
						string[] splt = line.Split(',');
						switch (splt[0]) {
							case "ACT":
								Shapes.Add(new ActivityVM(Int32.Parse(splt[1]), Int32.Parse(splt[2]), Int32.Parse(splt[3]), Int32.Parse(splt[4]), Int32.Parse(splt[5]), splt[6]));
								break;
							case "CON":
								Shapes.Add(new TrustedConditionVM(Int32.Parse(splt[1]), Int32.Parse(splt[2]), Int32.Parse(splt[3]), Int32.Parse(splt[4]), Int32.Parse(splt[5]), splt[6]));
								break;
							case "TYPE":
								break;
							default:
								break;
						}
					}				

				}
			}
		}

	}
}
