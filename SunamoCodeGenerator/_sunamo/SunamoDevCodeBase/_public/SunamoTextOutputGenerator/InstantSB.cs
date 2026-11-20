namespace SunamoDevCode._sunamo.SunamoDevCodeBase._public.SunamoTextOutputGenerator;

/// <summary>
/// Represents the instant SB type.
/// </summary>
public class InstantSB
{
    /// <summary>
    /// Gets or sets the string builder.
    /// </summary>
    public StringBuilder StringBuilder { get; set; } = new StringBuilder();
    private string _tokensDelimiter;

    /// <summary>
    /// Instant SB.
    /// </summary>
    /// <returns>The instant SB result.</returns>
    public InstantSB(string delimiter)
    {
        _tokensDelimiter = delimiter;
    }

    /// <summary>
    /// Gets the length.
    /// </summary>
    public int Length => StringBuilder.Length;

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        string result = StringBuilder.ToString();
        return result;
    }

    /// <summary>
    /// Add item.
    /// </summary>
    /// <returns>The add item result.</returns>
    public void AddItem(string value)
    {
        string text = value.ToString();
        if (text != _tokensDelimiter && text != "")
        {
            StringBuilder.Append(text + _tokensDelimiter);
        }
    }

    /// <summary>
    /// Initializes a new instance of the add raw class.
    /// </summary>
    /// <param name="!">The !.</param>
    public void AddRaw(object content)
    {
        StringBuilder.Append(content.ToString());
    }

    /// <summary>
    /// Add items.
    /// </summary>
    /// <param name="content">The content.</param>
    public void AddItems(params string[] items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    /// <summary>
    /// Initializes a new instance of the end line class.
    /// </summary>
    /// <param name="items">The items.</param>
    public void EndLine(object content)
    {
        string text = content.ToString()!;
        if (text != _tokensDelimiter && text != "")
        {
            StringBuilder.Append(text);
        }
    }

    /// <summary>
    /// Initializes a new instance of the append line class.
    /// </summary>
    /// <param name="!">The !.</param>
    public void AppendLine(string text)
    {
        EndLine(text + Environment.NewLine);
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="text">The text.</param>
    public void AppendLine()
    {
        EndLine(Environment.NewLine);
    }

    /// <summary>
    /// Remove end delimiter.
    /// </summary>
    public void RemoveEndDelimiter()
    {
        StringBuilder.Remove(StringBuilder.Length - _tokensDelimiter.Length, _tokensDelimiter.Length);
    }

    /// <summary>
    /// Clear.
    /// </summary>
    public void Clear()
    {
        StringBuilder.Clear();
    }
}