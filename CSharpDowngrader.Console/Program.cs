using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Redacted.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            using (var sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("CSharpDowngrader.Console.CSharp8Sample.cs")))
                text = sr.ReadToEnd();

            var tree = CSharpSyntaxTree.ParseText(text);
            SyntaxNode rootNode = tree.GetRoot();
            foreach (var nullableTypeSyntaxNode in rootNode.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.NullableTypeSyntax>())
            {
                rootNode = rootNode.ReplaceNode(nullableTypeSyntaxNode, nullableTypeSyntaxNode.ElementType);
            }

            var result = rootNode.ToFullString();
        }
    }
}
