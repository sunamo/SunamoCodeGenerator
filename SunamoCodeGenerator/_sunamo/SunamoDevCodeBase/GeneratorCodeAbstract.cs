namespace SunamoDevCode._sunamo.SunamoDevCodeBase;

public abstract class GeneratorCodeAbstract
{
    // Use ToString() instead of public access
    protected string Final = "";

    protected InstantSB sb = new(" ");
    public XmlDoc xmlDoc;

    public GeneratorCodeAbstract()
    {
        xmlDoc = new XmlDoc(sb);
    }

    public void AddTab2(int tabCount, string text)
    {
        sb.AddItem(AddTab(tabCount, text));
    }

    // Ends a brace and adds a new line. After calling this method for elements like methods, properties, or constructors, it's recommended to also call sb.AppendLine().
    public void EndBrace(int tabCount)
    {
        AddTab(tabCount);
        sb.AppendLine("}");
    }

    // Starts a brace. This is the only method here that adds a new line at the beginning.
    public void StartBrace(int tabCount)
    {
        // Line always ending previous command
        AddTab(tabCount);
        sb.AppendLine("{");
    }

    public void StartParenthesis()
    {
        sb.AddItem("(");
    }

    public void EndParenthesis()
    {
        sb.AddItem(")");
    }

    public void AppendLine()
    {
        sb.AppendLine();
    }

    // Appends a formatted line with tabs
    public void AppendLine(int tabCount, string format, params object[] args)
    {
        if (args.Length != 0)
            sb.AppendLine(AddTab(tabCount, string.Format(format, args)));
        else
            sb.AppendLine(AddTab(tabCount, format));
    }

    // Appends formatted text with tabs (without newline)
    public void Append(int tabCount, string format, params object[] args)
    {
        if (args.Length != 0)
            sb.AddItem(AddTab(tabCount, string.Format(format, args)));
        else
            sb.AddItem(AddTab(tabCount, format));
    }

    // Assigns a value to a property/field, converting it to string
    public void AssignValue(int tabCount, string objectName, string variableName, object value, bool addToHyphens)
    {
        string valueString;
        if (value.GetType() == typeof(bool))
            valueString = value.ToString()!.ToLower();
        else
            valueString = value.ToString()!;
        AssignValue(tabCount, objectName, variableName, valueString, addToHyphens);
    }

    // Returns the generated code and resets the string builder
    public override string ToString()
    {
        var result = sb.ToString();
        sb = new InstantSB(" ");
        return result;
    }

    public void AddTab(int tabCount)
    {
        for (var index = 0; index < tabCount; index++) sb.AddRaw("\t");
    }

    // Adds tabs to each line of the text
    public static string AddTab(int tabCount, string text)
    {
        var lines = SHGetLines.GetLines(text);
        for (var index = 0; index < lines.Count; index++)
        {
            lines[index] = lines[index].Trim();
            for (var tabIndex = 0; tabIndex < tabCount; tabIndex++) lines[index] = "\t" + lines[index];
        }

        var result = string.Join(Environment.NewLine, lines);
        return result;
    }
}