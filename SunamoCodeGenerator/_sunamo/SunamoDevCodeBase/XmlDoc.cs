namespace SunamoDevCode._sunamo.SunamoDevCodeBase;

/// <summary>
/// Represents the xml doc type.
/// </summary>
public class XmlDoc
{
    private readonly InstantSB _stringBuilder;

    /// <summary>
    /// Initializes a new instance of the xml doc class.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    public XmlDoc(InstantSB stringBuilder)
    {
        _stringBuilder = stringBuilder;
    }

    /// <summary>
    /// Summary start.
    /// </summary>
    public void SummaryStart()
    {
        Prefix("<summary>");
    }

    private void Prefix(string text)
    {
        text = text.Replace("\r", "");
        var lines = text.Split('\n');

        foreach (var line in lines) _stringBuilder.AppendLine("/// " + line);
    }

    /// <summary>
    /// Summary end.
    /// </summary>
    /// <param name="appendLine">The append line.</param>
    public void SummaryEnd(bool appendLine = true)
    {
        Prefix("</summary>");
        if (appendLine) _stringBuilder.AppendLine();
    }

    /// <summary>
    /// Raw.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Raw(string text)
    {
        Prefix(text);
    }
}