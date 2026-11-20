namespace SunamoDevCode.CodeGenerator;

/// <summary>
/// Represents the generator cpp type.
/// </summary>
public class GeneratorCpp : GeneratorCodeAbstract
{
    /// <summary>
    /// Map string string.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    /// <param name="mapName">The map name.</param>
    /// <param name="nameCommentEnums">The name comment enums.</param>
    public void MapStringString(int tabCount, string mapName, Dictionary<string, string> nameCommentEnums)
    {
        string typeName = "map<string, string>";
        NewVariable(tabCount, typeName, mapName);
        foreach (var item in nameCommentEnums)
        {
            AppendLine(tabCount, mapName + ".insert({\"" + item.Key + "\", \"" + item.Value + "\"});");
        }
    }

    private void NewVariable(int tabCount, string typeName, string name)
    {
        AddTab2(tabCount, " ");
        sb.AddItem(typeName);
        sb.AppendLine(name + ";");
    }

    /// <summary>
    /// Map non string non string.
    /// </summary>
    /// <param name="tabCount">The tab count.</param>
    /// <param name="mapName">The map name.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="valueType">The value type.</param>
    /// <param name="nameCommentEnums">The name comment enums.</param>
    public void MapNonStringNonString(int tabCount, string mapName, string keyType, string valueType, Dictionary<string, string> nameCommentEnums)
    {
        string typeName = "map<" + keyType + ", " + valueType + ">";
        NewVariable(tabCount, typeName, mapName);
        foreach (var item in nameCommentEnums)
        {
            AppendLine(tabCount, mapName + ".insert({" + item.Key + ", " + item.Value + "});");
        }
    }

    /// <summary>
    /// Vector custom.
    /// </summary>
    /// <param name="tabsCount">The tabs count.</param>
    /// <param name="vectorName">The vector name.</param>
    /// <param name="customType">The custom type.</param>
    /// <param name="dictionary">The dictionary.</param>
    public void VectorCustom(int tabsCount, string vectorName, string customType, Dictionary<string, string> dictionary)
    {
        string typeName = "vector<" + customType + ">";
        NewVariable(tabsCount, typeName, vectorName);
        Append(tabsCount, vectorName + "=");
        Append(0, "{");
        foreach (var item in dictionary)
        {
            Append(0, "{\"" + item.Key + "\", \"" + item.Value + "\"}" + ",");
        }
        AppendLine(0, "};");
    }

    /// <summary>
    /// Array.
    /// </summary>
    /// <param name="tabsCount">The tabs count.</param>
    /// <param name="arrayName">The array name.</param>
    /// <param name="customType">The custom type.</param>
    /// <param name="dictionary">The dictionary.</param>
    public void Array(int tabsCount, string arrayName, string customType, Dictionary<string, string> dictionary)
    {
        AddTab2(tabsCount, " ");
        sb.AddItem(customType);
        Append(tabsCount, arrayName + "[" + dictionary.Count + "]=");
        Append(0, "{");
        foreach (var item in dictionary)
        {
            string separator = item.Key == dictionary.Last().Key ? "" : ",";
            Append(0, "{\"" + item.Key + "\", \"" + item.Value + "\"}" + separator);
        }
        AppendLine(0, "};");
    }
}
