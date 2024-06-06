namespace Maple2.File.IO.Nif;

public class NifVersionNotSupportedException : NotSupportedException {
    public NifVersionNotSupportedException(string? message) : base(message) {
    }

    public NifVersionNotSupportedException(string? message, Exception nested) : base(message, nested) {
    }
}
