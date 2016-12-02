using System.Collections.ObjectModel;
using TrustedActivityCreator.ViewModel;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Windows.Forms;
using TrustedActivityCreator.Command;

namespace TrustedActivityCreator.Model {
	public class TrustedCollection {
		public static ObservableCollection<ShapeBaseViewModel> Shapes { get; } = new ObservableCollection<ShapeBaseViewModel>();
		public static ObservableCollection<TrustedConnectionVM> Connections { get; } = new ObservableCollection<TrustedConnectionVM>();

		public static int idCounter = 0;
		public static string gotFileName = "";

		public static void save() {
			if(gotFileName != "") {
				File.WriteAllText(gotFileName, "");
				using (StreamWriter writer = new StreamWriter(gotFileName)) {
					writer.WriteLine("------------SHAPES-----------------");
					writer.WriteLine("TYPE,ID,WIDTH,HEIGHT,X,Y,DESCRIPTION");
					foreach (ShapeBaseViewModel s in Shapes) {
						writer.WriteLine(s.ToString());
					}
					writer.WriteLine("----------CONNECTIONS---------------");
					writer.WriteLine("TYPE,FROMANCHOR,TOANCHOR,FROMID,TOID");
					foreach (TrustedConnectionVM c in Connections) {
						writer.WriteLine(c.ToString());
					}
					writer.Close();
				}
			} else {
				saveToFile();
			}
		}

		public static void saveToFile() {
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Trusted file (*.trst)|*.trst";
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				gotFileName = saveFileDialog.FileName;
				using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName)) {

					writer.WriteLine("------------SHAPES-----------------");
					writer.WriteLine("TYPE,ID,WIDTH,HEIGHT,X,Y,DESCRIPTION");
					foreach (ShapeBaseViewModel s in Shapes) {
						writer.WriteLine(s.ToString());
					}
					writer.WriteLine("----------CONNECTIONS---------------");
					writer.WriteLine("TYPE,FROMANCHOR,TOANCHOR,FROMID,TOID");
					foreach (TrustedConnectionVM c in Connections) {
						writer.WriteLine(c.ToString());
					}
					writer.Close();
				}
			}
		}

		public static void loadFromFile() {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Trusted file (*.trst)|*.trst";
			if(openFileDialog.ShowDialog() == DialogResult.OK) {
				Shapes.Clear();
				Connections.Clear();
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
							case "EDP":
								Shapes.Add(new EndingPointVM(Int32.Parse(splt[1]), Int32.Parse(splt[2]), Int32.Parse(splt[3]), Int32.Parse(splt[4]), Int32.Parse(splt[5]), splt[6]));
								break;
							case "TYPE":
								break;
							case "CNT":
								ShapeBaseViewModel from = new ShapeBaseViewModel();
								ShapeBaseViewModel to = new ShapeBaseViewModel();
								foreach (ShapeBaseViewModel vm in Shapes) {
									if(vm.Id == Int32.Parse(splt[3])) {
										from = vm;
									}
									if(vm.Id == Int32.Parse(splt[4])) {
										to = vm;
									}
								}
								Console.WriteLine(splt[1] + " " + splt[2] + " " + from + " " + to);

								TrustedConnectionVM con = new TrustedConnectionVM(splt[1], splt[2], from, to);
								Connections.Add(con);
								break;
							default:
								break;
						}
					}
					reader.Close();
				}

				foreach(ShapeBaseViewModel vm in Shapes) {
					vm.raise("Path");
				}
			}
		}

	}
}
