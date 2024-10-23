using Microsoft.CodeAnalysis;

namespace ReillyDigital.Terminal.Gui.Xaml.Generation.ProvidedClasses
{
	/// <summary>
	/// Base class for source generation of a provided class.
	/// </summary>
	public abstract class ProvidedClassBase
	{
		/// <summary>
		/// The file name of the provided class.
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// The source code of the provided class.
		/// </summary>
		public abstract string Source { get; }

		public void RegisterOutput(IncrementalGeneratorPostInitializationContext context) =>
			context.AddSource(Name, Source);
	}
}
