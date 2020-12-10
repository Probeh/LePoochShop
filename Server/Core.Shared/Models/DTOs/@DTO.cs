using System;
using System.Runtime.InteropServices;
using Core.Shared.Entities;
using Newtonsoft.Json;

namespace Core.Shared.Models.DTOs
{
    public abstract class BaseDTO<TModel> where TModel : BaseDTO<TModel>
    {
        public int Id { get; set; }
        // ======================================= //
        protected BaseDTO(int? id) => this.Id = id ?? (int) id;
        // ======================================= //
        public virtual TSource ToSource<TSource>() where TSource : BaseModel<TSource> =>
            // ======================================= //
            // /* Intended For Individual Overrides  */
            // ======================================= //
            JsonConvert.DeserializeObject<TSource>(JsonConvert.SerializeObject(this)) as TSource;
        public abstract TModel FromSource<TSource>(TSource source) where TSource : BaseModel<TSource>;
        // ======================================= //
        // /* Intended For Virtual Implementation  */
        // ======================================= //
        public static TModel FromSource<TSource>(TSource source, [Optional] Func<TModel> builder) where TSource : BaseModel<TSource> =>
            // ======================================= //
            // /* Perfect just the way it is */
            // ======================================= //
            builder != null ? builder?.Invoke() as TModel : JsonConvert.DeserializeObject<TModel>(JsonConvert.SerializeObject(source)) as TModel;
    }
}