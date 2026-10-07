namespace SunamoDevCode._sunamo.SunamoDevCodeBase._public.SunamoData.Data;

public class TWithNameTDC<T>
{
    public string name = string.Empty;
    public T t = default!;

    public TWithNameTDC()
    {
    }

    public TWithNameTDC(string name, T value)
    {
        this.name = name;
        this.t = value;
    }

    public override string ToString() => name;

    public static TWithNameTDC<T> Get(string name) => new() { name = name };
}