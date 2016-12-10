using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.View;

namespace TrustedActivityCreator.ViewModel {
    class MainViewModel {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;
		private SelectedShapeController selectedShape = SelectedShapeController.Instance;
		private ClipboardController clipboardController = ClipboardController.Instance;

		public ICommand UndoCommand { get; }
		public ICommand RedoCommand { get; }
		public ICommand DeleteCommand { get; }
		public ICommand CopyCommand { get; }
		public ICommand CutCommand { get; }
		public ICommand PasteCommand { get; }
		public ICommand SaveAsFile { get; }
		public ICommand LoadCommand { get; }
		public ICommand SaveCommand { get; }
		public ICommand Shutdown { get; }
		public ICommand NewDocument { get; }


		public QuickPanelVM QuickPanel { get; }
		public CanvasVM TrustedCanvas { get; }

		public MainViewModel() {
			UndoCommand = new RelayCommand(undoRedoController.Undo, undoRedoController.CanUndo);
			RedoCommand = new RelayCommand(undoRedoController.Redo, undoRedoController.CanRedo);
			DeleteCommand = new RelayCommand(DeleteShape);
			CopyCommand = new RelayCommand(CopyShape);
			CutCommand = new RelayCommand(CutShape);
			PasteCommand = new RelayCommand(PasteShape);
			SaveAsFile = new RelayCommand(SaveAsFileFunction);
			LoadCommand = new RelayCommand(LoadFile);
			SaveCommand = new RelayCommand(Save);
			Shutdown = new RelayCommand(Shutd);
			NewDocument = new RelayCommand(NewDocumentF);
			QuickPanel = new QuickPanelVM();
			TrustedCanvas = new CanvasVM();
		}

		private void LoadFile() {
			TrustedCollection.loadFromFile();
		}

		private void SaveAsFileFunction() {
			TrustedCollection.saveToFile();
		}

		private void Save() {
			TrustedCollection.save();
		}

		private void Shutd() {
			App.ShutdownNow();
		}

		private void NewDocumentF() {
			TrustedCollection.Shapes.Clear();
			TrustedCollection.Connections.Clear();
		}

		private void DeleteShape() {
			if(selectedShape.SelectedShape != null) {
				undoRedoController.AddAndExecute(new RemoveShapesCommand(new List<ShapeBaseViewModel>() { selectedShape.SelectedShape }));
			}
			selectedShape.SelectedShape = null;
		}

		private void CopyShape() {
			if(selectedShape.SelectedShape != null) {
				clipboardController.Clipboard = selectedShape.SelectedShape.Clone();
			}
		}

		private void CutShape() {
			CopyShape();
			DeleteShape();
		}

		private void PasteShape() {
			if(clipboardController.Clipboard != null) {
				ShapeBaseViewModel shape = clipboardController.Clipboard.Clone();
				Point pos = shape.RelativeMousePosition();
				if(pos.X > 0 && pos.Y > 0) {
					shape.X = (int)(pos.X - shape.Width / 2); shape.Y = (int)(pos.Y - shape.Height / 2);
					undoRedoController.AddAndExecute(new AddShapeCommand(shape));
				}
			}
		}
	}
}
