using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.IO;
using DungeonsAndCodeWizards.IO.Interfaces;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main()
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			Engine engine = new Engine(reader, writer);
		    engine.Run();
		}
	}
}