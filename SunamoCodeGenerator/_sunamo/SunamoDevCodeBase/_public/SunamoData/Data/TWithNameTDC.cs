namespace SunamoDevCode._sunamo.SunamoDevCodeBase._public.SunamoData.Data;

/// <summary>
/// Represents the t with name TDC t type.
/// </summary>
public class TWithNameTDC<T>
{
    /// <summary>
    /// The name.
    /// </summary>
    public string name = string.Empty;
    /// <summary>
    /// The t.
    /// </summary>
    public T t = default!;

    /// <summary>
    /// T with name TDC.
    /// </summary>
    /// <returns>The t with name TDC result.</returns>
    public TWithNameTDC()
    {
    }

    /// <summary>
    /// T with name TDC.
    /// </summary>
    /// <returns>The t with name TDC result.</returns>
    public TWithNameTDC(string name, T value)
    {
        this.name = name;
        this.t = value;
    }

    /// <summary>
    /// Initializes a new instance of the to string class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public override string ToString() => name;

    /// <summary>
    /// Get.
    /// </summary>
    /// <returns>The get result.</returns>
    public static TWithNameTDC<T> Get(string name) => new() { name = name };
}