namespace DotConnectOracle.CastError.Sample.Entities;

public class Unused
{
    public static readonly Unused Yes = new("Y");
    public static readonly Unused No = new("N");

    public string Value { get; }

    private Unused(string value) => this.Value = value;

    public static implicit operator Unused(string value)
    {
        return value switch
        {
            "Y" => Yes,
            "N" => No,
            _ => throw new NotImplementedException()
        };
    }
}