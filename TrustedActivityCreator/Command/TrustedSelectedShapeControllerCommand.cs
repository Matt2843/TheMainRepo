using TrustedActivityCreator.Model;


namespace TrustedActivityCreator.Command {
	class TrustedSelectedShapeControllerCommand {

		public static TrustedSelectedShapeControllerCommand Instance { get; } = new TrustedSelectedShapeControllerCommand();

		public Shape selectedShape { get; set; }

	}
}
