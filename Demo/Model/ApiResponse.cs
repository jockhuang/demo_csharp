namespace Demo.Model;

public class ApiResponse
{
    public static ApiResponse Ok(object data){
        return new ApiResponse{Data=data};
    }

    public static ApiResponse Ok(){
        return new ApiResponse{Data=null};
    }

    public static ApiResponse Failed(string message){
        return new ApiResponse{Message=message,Data=null};
    }

    public int Code { get; set; } = 0;
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; }
}