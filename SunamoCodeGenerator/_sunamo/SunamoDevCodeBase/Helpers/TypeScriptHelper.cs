namespace SunamoDevCode.Helpers;

internal class TypeScriptHelper
{
    private static Dictionary<string, string> ___defaultValueForType = new Dictionary<string, string>();

    static TypeScriptHelper()
    {
        ___defaultValueForType.Add("string", "\"\"");
        ___defaultValueForType.Add("number", "0");
        ___defaultValueForType.Add("boolean", "false");
        ___defaultValueForType.Add("Date", "dt");
    }

    public static string DefaultValueForType(string typeName, string prefixIfString = "", /*bool isArgNumber = false,*/ string nameArgMethod = "")
    {
        if (typeName.EndsWith("[]"))
        {
            return "[]";
        }

        if (___defaultValueForType.ContainsKey(typeName))
        {
            var result = ___defaultValueForType[typeName];
            if (typeName == "string")
            {
                result = result.Insert(1, prefixIfString);
                if (nameArgMethod != "")
                {
                    result += " + " + nameArgMethod;
                }
            }
            else if (typeName == "number")
            {
                if (nameArgMethod != "")
                {
                    result = "+" + nameArgMethod;
                }
            }

            return result;
        }

        ThrowEx.NotImplementedCase(typeName);
        return "";
    }
}
