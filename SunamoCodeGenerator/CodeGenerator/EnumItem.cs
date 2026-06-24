namespace SunamoDevCode.CodeGenerator;

public class EnumItem
{
    // Hex value without the initial 0x prefix
    public string Hex { get; set; } = "";

    public Dictionary<string, string>? Attributes { get; set; } = null;

    public string Name { get; set; } = "";

    public string Comment { get; set; } = string.Empty;
}
