using System.Collections.Generic;
using Core.Shared.Entities;

namespace Core.Shared.Helpers
{
    public class Pagination<TSource> where TSource : BaseModel<TSource>
    {
        // ======================================= //
        public int ResultsPerPage { get; } = 12;
        public int TotalItems { get; set; }
        public int TotalLeft { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; } = 1;
        public ICollection<TSource> Results { get; set; }
        // ======================================= /
        public Pagination(params TSource[] results) => this.Results = results;
        // ======================================= /
        public Pagination<TSource> Build(int totalItems)
        {
            this.TotalItems = totalItems;
            this.TotalPages = this.TotalItems / this.ResultsPerPage;
            this.TotalLeft = this.TotalItems - (this.CurrentPage * this.CurrentPage);
            return this;
        }
        public Pagination<TSource> Build(ICollection<TSource> results)
        {
            this.Results = results;
            this.TotalItems = results.Count;
            return this.Build(this.TotalItems);
        }
        // ======================================= /

    }
}