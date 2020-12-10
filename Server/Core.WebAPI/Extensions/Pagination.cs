using Core.Shared.Entities;
using Core.Shared.Helpers;
using Microsoft.AspNetCore.Http;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static void SetPagination<TSource>(this HttpResponse response, Pagination<TSource> result) where TSource : BaseModel<TSource>
        {
            // ======================================= //
            response.Headers.Add("X-Results-Limit"    , result.ResultsPerPage.ToString());
            response.Headers.Add("X-Results-Total"    , result.TotalItems    .ToString());
            response.Headers.Add("X-Results-Pages"    , result.TotalPages    .ToString());
            response.Headers.Add("X-Results-Remaining", result.TotalLeft     .ToString());
            response.Headers.Add("X-Results-Current"  , result.CurrentPage   .ToString());
            // ======================================= //
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Limit"    );
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Total"    );
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Pages"    );
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Remaining");
            response.Headers.Add("Access-Control-Expose-Headers", "X-Results-Current"  );
            // ======================================= //
        }
    }
}