namespace Demo.Model;

public class ApiResponse
{
    public int Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; }

    public static ApiResponse Ok(object data)
    {
        return new ApiResponse { Data = data };
    }

    public static ApiResponse Ok()
    {
        return new ApiResponse { Data = null };
    }

    public static ApiResponse Failed(string message)
    {
        return Failed(message, 500);
    }

    public static ApiResponse Failed(string message, int code)
    {
        return new ApiResponse { Message = message, Data = null, Code = code };
    }
}