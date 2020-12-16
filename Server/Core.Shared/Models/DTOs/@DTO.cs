namespace Core.Shared.Models.DTOs
{
    public abstract class BaseDTO {}
    public abstract class BaseDTO<TModel> : BaseDTO where TModel : BaseDTO<TModel> { }
}