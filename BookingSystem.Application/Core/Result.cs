namespace BookingSystem.Application.Core;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T? Value { get; set; }
    public string? Error { get; set; }
    public int Code { get; set; }
    public string? Message { get; set; } = string.Empty;

    public static Result<T> Success(T value, string? message = null) => new() { IsSuccess = true, Value = value, Message = message };
    public static Result<T> Failure(string error, int code) => new()
    {
        IsSuccess = false,
        Error = error,
        Code = code
    };
}
