using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Helpers
{
    public class SearchParams
    {
        public string Name { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Id { get; set; } = -1;

        [Range(0, 1)]
        public int IsActive { get; set; } = -1;

        [Range(0, 20)]
        public int Results { get; set; } = 12;

        [Range(1, Int32.MaxValue)]
        public int CurrentPage { get; set; }

        [Range(1, 2)]
        public int OrderBy { get; set; } = 1;

        [DataType(DataType.Date)]
        public DateTime? MinDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MaxDate { get; set; }
    }
}