namespace SunamoDevCode._sunamo.SunamoCSharp;

internal partial class CSharpGenerator : GeneratorCodeAbstract //, ICSharpGenerator
{

    private void ReturnTypeName(string returnType, string name)
    {
        sb.AddItem(returnType);
        sb.AddItem(name);
    }
}