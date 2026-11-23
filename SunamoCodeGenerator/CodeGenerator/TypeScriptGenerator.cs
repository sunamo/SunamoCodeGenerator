namespace SunamoDevCode.CodeGenerator;

// Generator for TypeScript code.
/// <summary>
/// Represents the type script generator type.
/// </summary>
public class TypeScriptGenerator
{
    private StringBuilder stringBuilder = new StringBuilder();

    /// <summary>
    /// Interface.
    /// </summary>
    /// <param name="isExporting">The is exporting.</param>
    /// <param name="name">The name.</param>
    /// <param name="properties">The properties.</param>
    public void Interface(bool isExporting, string name, params TWithNameTDC<string>[] properties)
    {
        if (isExporting)
        {
            stringBuilder.Append("export ");
        }
        stringBuilder.Append("interface ");
        stringBuilder.AppendLine(name);
        stringBuilder.AppendLine("{");
        foreach (var item in properties)
        {
            stringBuilder.AppendLine(item.name + ": " + item.t + ";");
        }
        stringBuilder.AppendLine("}");
        stringBuilder.AppendLine();
    }

    /// <summary>
    /// Append.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Append(string text)
    {
        stringBuilder.Append(text);
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="text">The text.</param>
    public void AppendLine(string text)
    {
        stringBuilder.AppendLine(text);
    }

    /// <summary>
    /// Class variable.
    /// </summary>
    /// <param name="isExporting">The is exporting.</param>
    /// <param name="type">The type.</param>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public void ClassVariable(bool isExporting, TypesTs type, string name, string value)
    {
        if (isExporting)
        {
            stringBuilder.Append("export ");
        }

        stringBuilder.Append(type.ToString().TrimStart('_') + " ");

        stringBuilder.Append(name);
        stringBuilder.Append(" = ");
        if (type == TypesTs._string)
        {
            value = SH.WrapWithQm(value);
        }
        stringBuilder.Append(value);
        stringBuilder.Append(";");
    }

    /// <summary>
    /// Array with key value object start.
    /// </summary>
    /// <param name="itemType">The item type.</param>
    /// <param name="values">The values.</param>
    public void ArrayWithKeyValueObjectStart(string itemType, params string[] values)
    {
        if (itemType == "string")
        {
            for (int index = 0; index < values.Length; index++)
            {
                values[index] = SH.WrapWithQm(values[index]);
            }
        }

        stringBuilder.AppendLine("const arr : " + itemType + "[] = [" + string.Join(", ", values) + "]");
    }

    /// <summary>
    /// Array with key value object end.
    /// </summary>
    public void ArrayWithKeyValueObjectEnd()
    {
        stringBuilder.AppendLine("];");
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString() => stringBuilder.ToString();

    private const string LetKeyword = "let";
    private const string ConstKeyword = "const";

    /// <summary>
    /// Const.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="type">The type.</param>
    public void Const(string name, string type)
    {
        Field(ConstKeyword, name, type);
    }

    /// <summary>
    /// Let.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="type">The type.</param>
    public void Let(string name, string type)
    {
        Field(LetKeyword, name, type);
    }

    private void Field(string keyword, string name, string type)
    {
        stringBuilder.AppendLine(keyword + " " + name + ":" + type + "= " + TypeScriptHelper.DefaultValueForType(type));
    }

    /// <summary>
    /// Append line.
    /// </summary>
    public void AppendLine()
    {
        stringBuilder.AppendLine();
    }
}
