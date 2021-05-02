using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HCL.DTO
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResponseStatus
    {
        Success = 200,
        AccessDenied = 401,
        BadRequest = 400,
        Conflict = 409,
        Error = 422,
        TokenExpired = 423,
        InvalidToken = 424
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageCode
    {
        Required,
        MaxLengthExceeded,
        AccessDenied,
        Exception,
        Invalid,
        Duplicate,
        DependencyDataExist,
        ValidationFailed,
        TokenExpired,
        InvalidToken,
        RedemptionExceeded
    }


    public enum TokenGrantType
    {
        Authorization = 0,
        RefreshToken = 1
    }
}
