using System.Collections.Generic;
using System.Linq;
using Core.Shared.Models.Entities;

namespace Core.Shared.Helpers
{
    public class Pagination<TSource> where TSource : BaseModel
    {
        // ======================================= //
        public int ResultsCount { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalLeft { get; private set; }
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }
        public ICollection<TSource> Results { get; private set; }
        // ======================================= /
        public Pagination(params TSource[] results) => this.Results = results;
        public Pagination(int totalItems, int currentPage = 1)
        {
            this.CurrentPage = currentPage;
            this.TotalItems = totalItems;
        }
        // ======================================= /
        public Pagination<TSource> Build(ICollection<TSource> collection)
        {
            this.Results = collection;
            this.ResultsCount = collection.Count;
            this.TotalPages = this.TotalItems / this.ResultsCount;
            this.TotalLeft = this.TotalItems - (this.CurrentPage * this.ResultsCount);
            return this;
        }
        // ======================================= /

    }
}