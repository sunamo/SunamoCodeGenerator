namespace SunamoDevCode._sunamo.SunamoCSharp;

internal partial class CSharpGenerator : GeneratorCodeAbstract //, ICSharpGenerator
{
    public void StartClass(int tabCount, AccessModifiers accessModifier, bool isStatic, string className, params string[] derivedTypes)
    {
        AddTab(tabCount);
        PublicStatic(accessModifier, isStatic);
        sb.AddItem(" class " + className);
        if (derivedTypes.Length != 0)
        {
            sb.AddItem(":");
            for (var index = 0; index < derivedTypes.Length - 1; index++)
                sb.AddItem(derivedTypes[index] + ",");
            sb.AddItem(derivedTypes[derivedTypes.Length - 1]);
        }

        StartBrace(tabCount);
    }

    private void PublicStatic(AccessModifiers accessModifier, bool isStatic)
    {
        WriteAccessModifiers(accessModifier);
        if (isStatic)
            sb.AddItem("static");
    }

    private void WriteAccessModifiers(AccessModifiers accessModifier)
    {
        if (accessModifier == AccessModifiers.Public)
        {
            sb.AddItem("public");
        }
        else if (accessModifier == AccessModifiers.Protected)
        {
            sb.AddItem("protected");
        }
        else if (accessModifier == AccessModifiers.Private)
        {
            // Private is default - no keyword needed
        }
        else if (accessModifier == AccessModifiers.Internal)
        {
            sb.AddItem("public");
        }
        else
        {
            ThrowEx.NotImplementedCase(accessModifier);
        }
    }

    public void Field(int tabCount, AccessModifiers accessModifier, bool isStatic, VariableModifiers variableModifiers, string type, string name, bool isAddingHyphensToValue, string value)
    {
        var initializationOption = ObjectInitializationOptions.Original;
        if (isAddingHyphensToValue)
            initializationOption = ObjectInitializationOptions.Hyphens;
        Field(tabCount, accessModifier, isStatic, variableModifiers, type, name, initializationOption, value);
    }

    public void Field(int tabCount, AccessModifiers accessModifier, bool isStatic, VariableModifiers variableModifiers, string type, string name, ObjectInitializationOptions initializationOption, string value)
    {
        AddTab(tabCount);
        ModifiersField(accessModifier, isStatic, variableModifiers);
        ReturnTypeName(type, name);
        sb.AddItem("=");
        if (initializationOption == ObjectInitializationOptions.Hyphens)
            value = "\"" + value + "\"";
        else if (initializationOption == ObjectInitializationOptions.NewAssign)
            value = "new " + type + "()";
        var statement = value + ";";
        sb.AddItem(statement);
        sb.AppendLine();
    }

    private void ModifiersField(AccessModifiers accessModifier, bool isStatic, VariableModifiers variableModifiers)
    {
        WriteAccessModifiers(accessModifier);
        if (variableModifiers == VariableModifiers.Mapped)
        {
            sb.AddItem("const");
        }
        else
        {
            if (isStatic && variableModifiers == VariableModifiers.ReadOnly)
            {
                sb.AddItem("const");
            }
            else
            {
                if (isStatic)
                    sb.AddItem("static");
                if (variableModifiers == VariableModifiers.ReadOnly)
                    sb.AddItem("readonly");
            }
        }
    }

    public void Ctor(int tabCount, ModifiersConstructor modifierType, string constructorName, string bodyContent, params string[] parameters)
    {
        AddTab(tabCount);
        var modifierStringBuilder = new StringBuilder(modifierType.ToString());
        modifierStringBuilder[0] = char.ToLower(modifierStringBuilder[0]);
        sb.AddItem(modifierStringBuilder.ToString());
        sb.AddItem(constructorName);
        StartParenthesis();
        var parameterNames = new List<string>(parameters.Length / 2);
        for (var index = 0; index < parameters.Length; index++)
        {
            sb.AddItem(parameters[index]);
            var parameterName = parameters[++index];
            parameterNames.Add(parameterName);
            if (index != parameters.Length - 1)
                sb.AddItem(parameterName + ",");
            else
                sb.AddItem(parameterName);
        }

        EndParenthesis();
        StartBrace(tabCount);
        Append(tabCount + 1, bodyContent);
        EndBrace(tabCount - 2);
        sb.AppendLine();
    }
}