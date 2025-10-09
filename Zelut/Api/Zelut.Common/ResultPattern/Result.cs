public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class ResultData<TData>
{
    public TData? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}