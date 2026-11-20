namespace SunamoDevCode._sunamo.SunamoDevCodeBase;

/// <summary>
/// Represents the generator code abstract type.
/// </summary>
public abstract class GeneratorCodeAbstract
{
    // Use ToString() instead of public access
    /// <summary>
    /// The final.
    /// </summary>
    protected string Final = "";

    /// <summary>
    /// The sb.
    /// </summary>
    protected InstantSB sb = new(" ");
    /// <summary>
    /// The xml doc.
    /// </summary>
    public XmlDoc xmlDoc;

    /// <summary>
    /// Generator code abstract.
    /// </summary>
    /// <param name=""">The ".</param>
    /// <returns>The generator code abstract result.</returns>
    public GeneratorCodeAbstract()
    {
        xmlDoc = new XmlDoc(sb);
    }

    /// <summary>
    /// Add tab 2.
    /// </summary>
    /// <returns>The add tab 2 result.</returns>
    public void AddTab2(int tabCount, string text)
    {
        sb.AddItem(AddTab(tabCount, text));
    }

    // Ends a brace and adds a new line. After calling this method for elements like methods, properties, or constructors, it's recommended to also call sb.AppendLine().
    /// <summary>
    /// End brace.
    /// </summary>
    /// <param name="sb">The sb.</param>
    /// <returns>The end brace result.</returns>
    public void EndBrace(int tabCount)
    {
        AddTab(tabCount);
        sb.AppendLine("}");
    }

    // Starts a brace. This is the only method here that adds a new line at the beginning.
    /// <summary>
    /// Start brace.
    /// </summary>
    /// <returns>The start brace result.</returns>
    public void StartBrace(int tabCount)
    {
        // Line always ending previous command
        AddTab(tabCount);
        sb.AppendLine("{");
    }

    /// <summary>
    /// Start parenthesis.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    /// <returns>The start parenthesis result.</returns>
    public void StartParenthesis()
    {
        sb.AddItem("(");
    }

    /// <summary>
    /// Initializes a new instance of the end parenthesis class.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    public void EndParenthesis()
    {
        sb.AddItem(")");
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="sb.AddItem(")"">The sb add item.</param>
    /// <returns>The append line result.</returns>
    public void AppendLine()
    {
        sb.AppendLine();
    }

    // Appends a formatted line with tabs
    /// <summary>
    /// Initializes a new instance of the append line class.
    /// </summary>
    /// <param name=""">The ".</param>
    public void AppendLine(int tabCount, string format, params object[] args)
    {
        if (args.Length != 0)
            sb.AppendLine(AddTab(tabCount, string.Format(format, args)));
        else
            sb.AppendLine(AddTab(tabCount, format));
    }

    // Appends formatted text with tabs (without newline)
    /// <summary>
    /// Append.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The args.</param>
    public void Append(int tabCount, string format, params object[] args)
    {
        if (args.Length != 0)
            sb.AddItem(AddTab(tabCount, string.Format(format, args)));
        else
            sb.AddItem(AddTab(tabCount, format));
    }

    // Assigns a value to a property/field, converting it to string
    /// <summary>
    /// Assign value.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The args.</param>
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
    /// <summary>
    /// To string.
    /// </summary>
    /// <param name="value.GetType()">The value get type.</param>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        var result = sb.ToString();
        sb = new InstantSB(" ");
        return result;
    }

    /// <summary>
    /// Add tab.
    /// </summary>
    /// <returns>The add tab result.</returns>
    public void AddTab(int tabCount)
    {
        for (var index = 0; index < tabCount; index++) sb.AddRaw("\t");
    }

    // Adds tabs to each line of the text
    /// <summary>
    /// Add tab.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    /// <returns>The add tab result.</returns>
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