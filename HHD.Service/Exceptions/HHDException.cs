namespace HHD.Service.Exceptions;

public class HHDException : Exception
{
    public int StatusCode { get; set; }
    public HHDException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
