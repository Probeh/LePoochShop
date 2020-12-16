using Microsoft.AspNetCore.Http;
using Core.Shared.Helpers;
using Core.Shared.Models.Entities;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static void SetPagination<TResponse>(this HttpResponse response, Pagination<TResponse> result) where TResponse : BaseModel
        {
            // ======================================= //
            response.Headers.Add("X-Results-Count"    , result.ResultsCount.ToString());
            response.Headers.Add("X-Results-Total"    , result.TotalItems  .ToString());
            response.Headers.Add("X-Results-Pages"    , result.TotalPages  .ToString());
            response.Headers.Add("X-Results-Remaining", result.TotalLeft   .ToString());
            response.Headers.Add("X-Results-Current"  , result.CurrentPage .ToString());
            // ======================================= //
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Count" );
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Total" );
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Pages" );
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Remaining");
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Current" );
            // ======================================= //
        }
    }
}