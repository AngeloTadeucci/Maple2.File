using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Maple2.File.Generator.Utils;

internal class AttributeSyntaxReceiver : ISyntaxReceiver {
    public List<FieldDeclarationSyntax> Fields { get; } = new List<FieldDeclarationSyntax>();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
        // any field with at least one attribute is a candidate for property generation
        if (syntaxNode is FieldDeclarationSyntax fieldDeclarationSyntax
            && fieldDeclarationSyntax.AttributeLists.Count > 0) {
            Fields.Add(fieldDeclarationSyntax);
        }
    }
}
