using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ReillyDigital.Terminal.Gui.Xaml.Generation.ProvidedClasses;
using ReillyDigital.Terminal.Gui.Xaml.Generation.Sources;

namespace ReillyDigital.Terminal.Gui.Xaml.Generation
{
	/// <summary>
	/// Entry class for source generation.
	/// </summary>
	[Generator]
	public class SourceGenerator : IIncrementalGenerator
	{
		/// <summary>
		/// Entry method for source generation.
		/// </summary>
		/// <param name="initContext">The initialization context.</param>
		public void Initialize(IncrementalGeneratorInitializationContext initContext)
		{
			initContext.RegisterSourceOutput(
				initContext
					.SyntaxProvider
					.CreateSyntaxProvider(
						predicate: (node, cancellationToken) =>
							node is ClassDeclarationSyntax && node.SyntaxTree.FilePath.EndsWith(".xaml.cs"),
						transform: (context, cancellationToken) => (ClassDeclarationSyntax)context.Node
					),
				(context, node) =>
				{
					var source = new ClassSource(node);
					context.AddSource(
						source.FileName,
						SyntaxFactory
							.ParseCompilationUnit(source.ToString())
							.NormalizeWhitespace(indentation: "\t")
							.GetText(encoding: Encoding.UTF8)
					);
				}
			);
			initContext.RegisterPostInitializationOutput((context) =>
			{
				new ITerminalXamlViewProvidedClass().RegisterOutput(context);
				new RoutedViewHostProvidedClass().RegisterOutput(context);
			});
		}
	}
}
