namespace SunamoDevCode.CodeGenerator;

// Generator for C# classes. Generation of single element is in CSharpHelper.
/// <summary>
/// Represents the c sharp classes generator type.
/// </summary>
public class CSharpClassesGenerator
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type Type = typeof(CSharpClassesGenerator);

    /// <summary>
    /// Dictionary.
    /// </summary>
    /// <param name="CSharpClassesGenerator">The c sharp classes generator.</param>
    /// <returns>The dictionary result.</returns>
    public static string Dictionary(string className, List<string> keys, Func<string> randomValue)
    {
        List<string> values = new();
        for (int index = 0; index < keys.Count; index++)
        {
            values.Add(randomValue());
        }

        return Dictionary(className, keys, values);
    }

    /// <summary>
    /// Dictionary.
    /// </summary>
    /// <param name="className">The class name.</param>
    /// <param name="keys">The keys.</param>
    /// <param name="values">The values.</param>
    /// <returns>The dictionary result.</returns>
    public static string Dictionary(string className, List<string> keys, List<string> values)
    {

        ThrowEx.DifferentCountInLists(nameof(keys), keys.Count, nameof(values), values.Count);


        CSharpGenerator generator = new CSharpGenerator();
        generator.StartClass(0, AccessModifiers.Private, false, className);
        generator.Field(1, AccessModifiers.Private, false, VariableModifiers.None, "Dictionary<string, string>", "dict", false, "new Dictionary<string, string>()");
        CSharpGenerator inner = new CSharpGenerator();
        for (int index = 0; index < keys.Count; index++)
        {
            inner.AppendLine(2, "dict.Add(\"{0}\", \"{1}\");", keys[index], values[index]);
        }
        generator.Ctor(1, ModifiersConstructor.Private, className, inner.ToString());
        generator.EndBrace(0);
        return generator.ToString();
    }

    // switchKeysAndValues: If true, switches keys and values in the dictionary.
    /// <summary>
    /// Dictionary pascal convention.
    /// </summary>
    /// <param name="className">The class name.</param>
    /// <param name="list">The list.</param>
    /// <param name="switchKeysAndValues">The switch keys and values.</param>
    /// <returns>The dictionary pascal convention result.</returns>
    public static string DictionaryPascalConvention(string className, List<string> list, bool switchKeysAndValues)
    {
        List<string> values = new();
        for (int index = 0; index < list.Count; index++)
        {
            values.Add(ConvertPascalConvention.ToConvention(list[index]));
        }

        if (switchKeysAndValues)
        {
            return Dictionary(className, values, list);
        }
        else
        {
            return Dictionary(className, list, values);
        }
    }
}
