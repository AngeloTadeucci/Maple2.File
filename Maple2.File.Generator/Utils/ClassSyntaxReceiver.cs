using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Maple2.File.Generator.Utils;

internal class ClassSyntaxReceiver : ISyntaxReceiver {
    public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
        // any interface is a candidate for property generation
        if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax) {
            Classes.Add(classDeclarationSyntax);
        }
    }
}
