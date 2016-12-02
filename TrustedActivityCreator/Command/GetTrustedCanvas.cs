using TrustedActivityCreator.GUI;

namespace TrustedActivityCreator.Command {
	class GetTrustedCanvas {

		public TrustedCanvas Canvas { get; set; }

		public static GetTrustedCanvas Instance { get; } = new GetTrustedCanvas();

		private GetTrustedCanvas() { }

	}
}
