namespace CheetahToolbox.Exceptions;

public class VersionNotFoundException : Exception
{
    public override IDictionary Data => base.Data;

    public override string? HelpLink { get => base.HelpLink; set => base.HelpLink = value; }

    public override string Message => base.Message;

    public override string? Source { get => base.Source; set => base.Source = value; }

    public override string? StackTrace => base.StackTrace;

    public override bool Equals(object? obj) => base.Equals(obj);
    public override Exception GetBaseException() => base.GetBaseException();
    public override int GetHashCode() => base.GetHashCode();
    public override string ToString() => base.ToString();
}