﻿using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TrustedActivityCreator.Command;
using System.Windows;
using System.Xml.Linq;

namespace TrustedActivityCreator.ViewModel {
	class QuickPanelVM : ObservableObject {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;

		public ICommand AddShapeCommand { get; }

		private FrameworkElement canvas;

		public QuickPanelVM() {
			AddShapeCommand = new RelayCommand(AddShape);
			canvas = (FrameworkElement)(new FrameworkElement()).FindName("TrustedCanvas");
		}

		private void AddShape() {
			Point point = Mouse.GetPosition(canvas);

			ActivityVM shape = new ActivityVM();
			shape.X = (int)point.X;
			shape.Y = (int)point.Y;
			
			undoRedoController.AddAndExecute(new AddShapeCommand(shape));
		}
	}
}
