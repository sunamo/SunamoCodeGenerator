namespace SunamoDevCode.CodeGenerator;

/// <summary>
/// Represents the enum item type.
/// </summary>
public class EnumItem
{
    // Hex value without the initial 0x prefix
    /// <summary>
    /// Gets or sets the hex.
    /// </summary>
    public string Hex { get; set; } = "";

    /// <summary>
    /// Gets or sets the attributes.
    /// </summary>
    public Dictionary<string, string>? Attributes { get; set; } = null;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets the comment.
    /// </summary>
    public string Comment { get; set; } = string.Empty;
}
