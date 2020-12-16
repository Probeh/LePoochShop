namespace Core.Shared.Models.Enums
{
    public enum HttpCode
    {
        Success        = 200,
        NoResults      = 204,
        Unregistered   = 401,
        MissingRoles   = 403,
        UnknownParam   = 405,
        InvalidInput   = 406,
        UserNameExists = 409,
        ServerError    = 500,
        AuthRequired   = 511
    }
}