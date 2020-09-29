# CSharpDowngrader
Roslyn-based tool to transform C# code to compile on older compiler versions

In its initial milestone, the key use will be to take valid C# 8+ code with nullable annotations,
and remove those such that they compile on C# 6+.
