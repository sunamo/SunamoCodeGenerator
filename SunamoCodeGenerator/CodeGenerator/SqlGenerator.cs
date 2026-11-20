namespace SunamoDevCode.CodeGenerator;

// Generator for SQL queries.
/// <summary>
/// Represents the sql generator type.
/// </summary>
public class SqlGenerator
{
    private StringBuilder stringBuilder = new StringBuilder();

    /// <summary>
    /// Select.
    /// </summary>
    /// <param name="table">The table.</param>
    public void Select(string table)
    {
        stringBuilder.AppendLine("select * from " + table);
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString() => stringBuilder.ToString();
}
