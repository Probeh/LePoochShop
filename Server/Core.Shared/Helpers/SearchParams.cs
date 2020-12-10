using System;
using System.ComponentModel.DataAnnotations;
using Core.Shared.Models.Enums;

namespace Core.Shared.Helpers
{
    public class SearchParams
    {
        public string Name { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        [Range(0, 1)]
        public int IsActive { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Results { get; set; }

        [EnumDataType(typeof(OrderLevel))]
        public string OrderBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MinDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MaxDate { get; set; }
    }
}