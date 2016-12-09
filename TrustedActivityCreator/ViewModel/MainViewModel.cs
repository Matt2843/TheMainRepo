using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrustedActivityCreator.Command;
using TrustedActivityCreator.Model;
using TrustedActivityCreator.View;

namespace TrustedActivityCreator.ViewModel {
    class MainViewModel {

		private UndoRedoController undoRedoController = UndoRedoController.Instance;
		private SelectedShapeController selectedShape = SelectedShapeController.Instance;

		public ICommand UndoCommand { get; }
		public ICommand RedoCommand { get; }
		public ICommand AddShapeCommand { get; }
		public ICommand DeleteCommand { get; }
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
			AddShapeCommand = new RelayCommand(AddShape);
			DeleteCommand = new RelayCommand(DeleteShape);
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

		private void AddShape() {
			undoRedoController.AddAndExecute(new AddShapeCommand(new ActivityVM()));
		}

		private void DeleteShape() {
			undoRedoController.AddAndExecute(new RemoveShapesCommand(new List<ShapeBaseViewModel>(){ selectedShape.SelectedShape }));
		}
	}
}
