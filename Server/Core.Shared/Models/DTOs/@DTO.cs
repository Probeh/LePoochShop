namespace Core.Shared.Models.DTOs
{
    public abstract class BaseDTO<TModel> where TModel : BaseDTO<TModel>
    { }
}