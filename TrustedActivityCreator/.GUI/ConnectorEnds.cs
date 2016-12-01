using System;

namespace TrustedActivityCreator.GUI {

	[Flags]
	public enum ConnectorEnds {
		None = 0,
		Start = 1,
		End = 2,
		Both = 3
	}
}
